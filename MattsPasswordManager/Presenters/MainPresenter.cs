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
        public MainForm? MainForm { get; set; }

        private FileService _fileService;
        private MainModel _mainModel;

        public MainPresenter(FileService fileService, MainModel mainModel)
        {
            this._fileService = fileService;
            this._mainModel = mainModel;
        }

        public void CheckMainFormSet()
        {
            if (MainForm == null)
            {
                throw new InvalidOperationException("MainForm view has not been set!");
            }
        }

        public void NewRepo()
        {
            CheckMainFormSet();

            if (_mainModel.IsModified)
            {
                DialogResult result = MainForm.ShowConfirmationDialog(
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

            MainForm.ClearTable();
        }

        public void LoadRepo()
        {
            CheckMainFormSet();

            String? filePath = MainForm.ShowOpenFileDialog();

            if (filePath == null)
            {
                return;
            }

            // Get repo password
            EncPassword encPassword = new();
            DialogResult result = MainForm.ShowEnterEncPasswordForm(encPassword);

            if (result != DialogResult.OK)
            {
                return;
            }

            // Clear the table
            MainForm.ClearTable();

            List<Entry> data;
            try
            {
                data = _fileService.LoadPasswordFile(filePath, encPassword.Password);
            }
            catch (Exception ex)
            {
                MainForm.ShowErrorDialog(ex.Message);

                return;
            }

            foreach (Entry entry in data)
            {
                MainForm.AddEntryToTable(entry);
            }

            _mainModel.IsModified = false;
            _mainModel.EncPassword = encPassword.Password;
            _mainModel.OpenFilePath = filePath;
        }

        public void SaveRepo(bool forceSave = false)
        {
            CheckMainFormSet();

            ProcessSaveRepo(forceSave);
        }

        public void ProcessCloseApp(FormClosingEventArgs? e = null)
        {
            CheckMainFormSet();

            if (!CloseAppPrep() && e != null)
            {
                e.Cancel = true;
            }
        }

        public void ChangeRepoPassword()
        {
            CheckMainFormSet();

            EncPassword encPassword = new();

            DialogResult result = MainForm.ShowEditEncPasswordForm(encPassword);

            if (result != DialogResult.OK)
            {
                return;
            }

            _mainModel.EncPassword = encPassword.Password;
            _mainModel.IsModified = true;
        }

        public void AddEntry()
        {
            CheckMainFormSet();

            Entry entry = new();

            DialogResult result = MainForm.ShowAddEntryForm(entry);

            if (result != DialogResult.OK)
            {
                return;
            }

            MainForm.AddEntryToTable(entry);
            _mainModel.IsModified = true;
        }

        public void EditEntry()
        {
            CheckMainFormSet();

            DataGridViewRow row = MainForm.GetSelectedRow();

            if (row == null)
            {
                MainForm.ShowErrorDialog("No row selected!");

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

            DialogResult result = MainForm.ShowEditEntryForm(entry);

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

        public void RemoveEntry()
        {
            CheckMainFormSet();

            DataGridViewRow row = MainForm.GetSelectedRow();

            if (row == null)
            {
                MainForm.ShowErrorDialog("No row selected!");

                return;
            }

            // Confirm delete
            DialogResult result = MainForm.ShowConfirmationDialog(
                "Are you sure you want to remove this entry?"
            );

            if (result == DialogResult.Yes)
            {
                MainForm.RemoveEntryInTable(row.Index);
                _mainModel.IsModified = true;
            }
        }

        private bool CloseAppPrep()
        {
            if (_mainModel.IsModified)
            {
                DialogResult result = MainForm.ShowConfirmationDialog(
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
                        MainForm.ShowErrorDialog(ex.Message);

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

                if (MainForm.ShowAddEncPasswordForm(encPassword) != DialogResult.OK)
                {
                    return false;
                }

                _mainModel.EncPassword = encPassword.Password;
            }

            List<Entry> entries = MainForm.GetTableEntries();

            string? filePath = null;
            if (_mainModel.OpenFilePath == "" || forceSaveToNewFile)
            {
                filePath = MainForm.ShowSaveFileDialog();

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
                MainForm.ShowErrorDialog("Error saving file!");

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
