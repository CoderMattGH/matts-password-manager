using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MattsPasswordManager.DTOs;
using MattsPasswordManager.Forms;
using MattsPasswordManager.Models;
using MattsPasswordManager.Services;

namespace MattsPasswordManager.Presenters
{
    internal class MainPresenter
    {
        private readonly IMainForm _mainForm;
        private readonly FileService _fileService;
        private readonly MainModel _mainModel;

        public MainPresenter(IMainForm mainForm, MainModel mainModel, FileService fileService)
        {
            this._mainForm = mainForm;
            this._mainModel = mainModel;
            this._fileService = fileService;

            _mainForm.CloseButtonClick += ProcessCloseApp;
            _mainForm.FileNewClick += NewRepo;
            _mainForm.FileLoadClick += LoadRepo;
            _mainForm.FileSaveClick += SaveRepo;
            _mainForm.FileSaveAsClick += SaveAsRepo;
            _mainForm.ActionChangeRepoPasswordClick += ChangeRepoPassword;
            _mainForm.AddEntryClick += AddEntry;
            _mainForm.EditEntryClick += EditEntry;
            _mainForm.RemoveEntryClick += RemoveEntry;
            _mainForm.SearchBoxType += FilterSearchResults;
        }

        public void NewRepo(object? sender, EventArgs e)
        {
            if (_mainModel.IsModified)
            {
                DialogResult result = _mainForm.ShowConfirmationDialog(
                    "Would you like to save any changes to the current file?"
                );

                if (result == DialogResult.Yes)
                {
                    if (!ProcessSaveRepo())
                    {
                        return;
                    }
                }

                if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            _mainModel.OpenFilePath = "";
            _mainModel.IsModified = false;
            _mainModel.EncPassword = "";
            _mainModel.ClearEntries();

            _mainForm.UpdateFilename("");
            _mainForm.SetSearchBoxText("");
            _mainForm.SetTable(_mainModel.Entries);
        }

        public void LoadRepo(object? sender, EventArgs e)
        {
            String? filePath = _mainForm.ShowOpenFileDialog();

            if (filePath == null)
            {
                return;
            }

            // Get repo password
            EncPassword encPassword = new();
            DialogResult result = _mainForm.ShowEnterEncPasswordForm(encPassword);

            if (result != DialogResult.OK)
            {
                return;
            }

            _mainForm.ShowProgBarForm();

            List<Entry> data = [];
            Task.Run(() =>
            {
                try
                {
                    data = _fileService.LoadPasswordFile(filePath, encPassword.Password);
                }
                catch (Exception ex)
                {
                    _mainForm.UpdateProgBarForm(100);
                    _mainForm.HideProgBarForm();

                    _mainForm.ShowErrorDialog(ex.Message);

                    return;
                }

                _mainForm.UpdateProgBarForm(50);

                _mainModel.ClearEntries();

                _mainModel.Entries = data;
                _mainForm.SetTable(data);

                _mainModel.IsModified = false;
                _mainModel.EncPassword = encPassword.Password;
                _mainModel.OpenFilePath = filePath;
                _mainForm.UpdateFilename(Path.GetFileName(filePath));

                _mainForm.UpdateProgBarForm(100);
                _mainForm.HideProgBarForm();
            });
        }

        public void SaveRepo(object? sender, EventArgs e)
        {
            Task.Run(() =>
            {
                ProcessSaveRepo(false);
            });
        }

        public void SaveAsRepo(object? sender, EventArgs e)
        {
            Task.Run(() =>
            {
                ProcessSaveRepo(true);
            });
        }

        public void ProcessCloseApp(object? sender, FormClosingEventArgs e)
        {
            if (!CloseAppPrep() && e != null)
            {
                e.Cancel = true;
            }
        }

        public void ChangeRepoPassword(object? sender, EventArgs e)
        {
            EncPassword encPassword = new();

            DialogResult result = _mainForm.ShowEditEncPasswordForm(encPassword);

            if (result != DialogResult.OK)
            {
                return;
            }

            _mainModel.EncPassword = encPassword.Password;
            _mainModel.IsModified = true;
        }

        public void AddEntry(object? sender, EventArgs e)
        {
            Entry entry = new();

            List<Entry> entries = _mainModel.Entries;
            DialogResult result = _mainForm.ShowAddEntryForm(entry, entries);

            if (result != DialogResult.OK)
            {
                return;
            }

            _mainModel.AddEntry(entry);
            _mainModel.IsModified = true;

            FilterSearchResults();
        }

        public void EditEntry(object? sender, EventArgs e)
        {
            DataGridViewRow row = _mainForm.GetSelectedRow();

            if (row == null)
            {
                _mainForm.ShowErrorDialog("No row selected!");

                return;
            }

            Entry? rowEntry = row.Tag as Entry;

            if (rowEntry == null)
            {
                _mainForm.ShowErrorDialog("Error editing entry!");

                return;
            }

            List<Entry> entries = _mainModel.Entries;

            DialogResult result = _mainForm.ShowEditEntryForm(rowEntry, entries);

            if (result != DialogResult.OK)
            {
                return;
            }

            FilterSearchResults();

            _mainModel.IsModified = true;
        }

        public void RemoveEntry(object? sender, EventArgs e)
        {
            DataGridViewRow row = _mainForm.GetSelectedRow();

            if (row == null)
            {
                _mainForm.ShowErrorDialog("No row selected!");

                return;
            }

            // Confirm delete
            DialogResult result = _mainForm.ShowConfirmationDialog(
                "Are you sure you want to remove this entry?"
            );

            Entry? rowEntry = row.Tag as Entry;

            if (rowEntry == null)
            {
                _mainForm.ShowErrorDialog("Error deleting row!");

                return;
            }

            if (result == DialogResult.Yes)
            {
                _mainModel.RemoveEntry(rowEntry);
                _mainModel.IsModified = true;

                FilterSearchResults();
            }
        }

        public void FilterSearchResults(object? sender, EventArgs e)
        {
            FilterSearchResults();
        }

        public void FilterSearchResults()
        {
            // Get text from search box
            string searchString = _mainForm.GetSearchBoxText();

            // Filter results
            List<Entry> filteredEntries = _mainModel
                .Entries.Where(e =>
                    e.Description != null
                    && e.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                )
                .ToList();

            _mainForm.SetTable(filteredEntries);
        }

        private bool CloseAppPrep()
        {
            if (_mainModel.IsModified)
            {
                DialogResult result = _mainForm.ShowConfirmationDialog(
                    "Would you like to save any changes before you exit?"
                );

                if (result == DialogResult.Cancel)
                {
                    return false;
                }

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (!ProcessSaveRepo())
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        _mainForm.ShowErrorDialog(ex.Message);

                        return false;
                    }
                }
            }

            return true;
        }

        private bool ProcessSaveRepo(bool forceSaveToNewFile = false)
        {
            if (_mainModel.EncPassword == "")
            {
                EncPassword encPassword = new();

                if (_mainForm.ShowAddEncPasswordForm(encPassword) != DialogResult.OK)
                {
                    return false;
                }

                _mainModel.EncPassword = encPassword.Password;
            }

            List<Entry> entries = _mainModel.Entries;

            string? filePath = null;
            if (_mainModel.OpenFilePath == "" || forceSaveToNewFile)
            {
                filePath = _mainForm.ShowSaveFileDialog();

                if (filePath == null)
                {
                    return false;
                }
            }

            try
            {
                _fileService.SavePasswordFile(
                    filePath ?? _mainModel.OpenFilePath,
                    entries,
                    _mainModel.EncPassword
                );
            }
            catch (Exception)
            {
                _mainForm.ShowErrorDialog("Error saving file!");

                return false;
            }

            _mainModel.IsModified = false;

            if (filePath != null)
            {
                _mainModel.OpenFilePath = filePath;
                _mainForm.UpdateFilename(Path.GetFileName(filePath));
            }

            return true;
        }
    }
}
