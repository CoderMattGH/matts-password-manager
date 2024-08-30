using System;
using System.Collections.Generic;
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
        private readonly MainForm _mainForm;
        private readonly FileService _fileService;
        private readonly MainModel _mainModel;

        public MainPresenter(FileService fileService, MainModel mainModel, MainForm mainForm)
        {
            this._fileService = fileService;
            this._mainModel = mainModel;
            this._mainForm = mainForm;

            _mainForm.CloseButtonClick += ProcessCloseApp;
            _mainForm.FileNewClick += NewRepo;
            _mainForm.FileLoadClick += LoadRepo;
            _mainForm.FileSaveClick += SaveRepo;
            _mainForm.FileSaveAsClick += SaveRepo;
            _mainForm.ActionChangeRepoPasswordClick += ChangeRepoPassword;
            _mainForm.AddEntryClick += AddEntry;
            _mainForm.EditEntryClick += EditEntry;
            _mainForm.RemoveEntryClick += RemoveEntry;
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

            _mainForm.ClearTable();
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

            // Clear the table
            _mainForm.ClearTable();

            List<Entry> data;
            try
            {
                data = _fileService.LoadPasswordFile(filePath, encPassword.Password);
            }
            catch (Exception ex)
            {
                _mainForm.ShowErrorDialog(ex.Message);

                return;
            }

            foreach (Entry entry in data)
            {
                _mainForm.AddEntryToTable(entry);
            }

            _mainModel.IsModified = false;
            _mainModel.EncPassword = encPassword.Password;
            _mainModel.OpenFilePath = filePath;
        }

        public void SaveRepo(object? sender, EventArgs e)
        {
            ProcessSaveRepo(false);
        }

        public void SaveAsRepo(object? sender, EventArgs e)
        {
            ProcessSaveRepo(true);
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

            DialogResult result = _mainForm.ShowAddEntryForm(entry);

            if (result != DialogResult.OK)
            {
                return;
            }

            _mainForm.AddEntryToTable(entry);
            _mainModel.IsModified = true;
        }

        public void EditEntry(object? sender, EventArgs e)
        {
            DataGridViewRow row = _mainForm.GetSelectedRow();

            if (row == null)
            {
                _mainForm.ShowErrorDialog("No row selected!");

                return;
            }

            string description = row.Cells[0].Value.ToString() ?? "";
            string username = row.Cells[1].Value.ToString() ?? "";
            string password = row.Cells[2].Value.ToString() ?? "";

            Entry entry =
                new()
                {
                    Description = description,
                    Username = username,
                    Password = password
                };

            DialogResult result = _mainForm.ShowEditEntryForm(entry);

            if (result != DialogResult.OK)
            {
                return;
            }

            // Update row
            row.Cells[0].Value = entry.Description;
            row.Cells[1].Value = entry.Username;
            row.Cells[2].Value = entry.Password;

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

            if (result == DialogResult.Yes)
            {
                _mainForm.RemoveEntryInTable(row.Index);
                _mainModel.IsModified = true;
            }
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

            List<Entry> entries = _mainForm.GetTableEntries();

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
            }

            return true;
        }
    }
}
