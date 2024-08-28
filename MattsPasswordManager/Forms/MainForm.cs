using MattsPasswordManager.DTOs;
using MattsPasswordManager.Forms;
using MattsPasswordManager.Services;

namespace MattsPasswordManager.Forms
{
    public partial class MainForm : Form
    {
        public static readonly string FILE_EXT_FILTER = "MPM Files (*.mpm)|*.mpm";

        private string _openFilePath = "";
        private Boolean _isModified = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void FileNewClickHandler(object sender, EventArgs e)
        {
            _openFilePath = "";
            _isModified = false;
            passwordTable.Rows.Clear();
        }

        private void FileExitClickHandler(object sender, EventArgs e)
        {
            if (CloseAppPrep())
            {
                this.Close();
            }
        }

        private void CloseButtonHandler(object sender, FormClosingEventArgs e)
        {
            if (!CloseAppPrep())
            {
                e.Cancel = true;
            }
        }

        private void FileLoadClickHandler(object sender, EventArgs e)
        {
            _isModified = false;

            // Get filename
            OpenFileDialog openFileDialog =
                new() { Filter = FILE_EXT_FILTER, Title = "Select a file" };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Clear the table
                passwordTable.Rows.Clear();

                string filePath = this._openFilePath = openFileDialog.FileName;

                List<Entry> data;
                try
                {
                    data = FileService.LoadPasswordFile(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        this,
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                foreach (Entry entry in data)
                {
                    AddEntryToTable(entry);
                }
            }
        }

        private void FileSaveClickHandler(object sender, EventArgs e)
        {
            try
            {
                SaveTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    this,
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void FileSaveAsClickHandler(object sender, EventArgs e)
        {
            try
            {
                SaveTable(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    this,
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void AddEntryClickHandler(object sender, EventArgs e)
        {
            Entry entry = new();
            AddEntryForm addEntryForm = new(entry);

            if (addEntryForm.ShowDialog() == DialogResult.OK)
            {
                AddEntryToTable(entry);
                _isModified = true;
            }
        }

        private void EditEntryClickhandler(object sender, EventArgs e)
        {
            // Get values from selected row.
            DataGridViewRow row = passwordTable.CurrentRow;

            if (row == null)
            {
                MessageBox.Show(
                    this,
                    "No rows selected!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

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

            EditEntryForm editEntryForm = new(entry);
            if (editEntryForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            // Update row
            row.Cells[0].Value = entry.Description;
            row.Cells[1].Value = entry.Username;
            row.Cells[2].Value = entry.Password;

            _isModified = true;
        }

        private void RemoveEntryClickHandler(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = passwordTable.CurrentRow;

            if (selectedRow == null)
            {
                MessageBox.Show(
                    this,
                    "No row selected!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            // Confirm delete
            DialogResult result = MessageBox.Show(
                this,
                "Are you sure you want to remove this entry?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                passwordTable.Rows.RemoveAt(selectedRow.Index);
                _isModified = true;
            }
        }

        private void AddEntryToTable(Entry entry)
        {
            passwordTable.Rows.Add(entry.Description, entry.Username, entry.Password);
        }

        private Boolean SaveTable(Boolean forceSaveToNewFile = false)
        {
            // Convert all the table entrys to Entry objects
            List<Entry> entries = [];

            for (int i = 0; i < passwordTable.Rows.Count; i++)
            {
                DataGridViewRow row = passwordTable.Rows[i];

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

                entries.Add(entry);
            }

            if (this._openFilePath == "" || forceSaveToNewFile)
            {
                SaveFileDialog saveFileDialog =
                    new() { Filter = FILE_EXT_FILTER, Title = "Save a file" };

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return false;
                }

                this._openFilePath = saveFileDialog.FileName;
            }

            try
            {
                FileService.SavePasswordFile(this._openFilePath, entries);
                _isModified = false;
            }
            catch (Exception)
            {
                throw new Exception("Error saving file!");
            }

            return true;
        }

        private Boolean CloseAppPrep()
        {
            if (_isModified)
            {
                DialogResult result = MessageBox.Show(
                    this,
                    "Would you like to save any changes before you exit?",
                    "Question",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Cancel)
                {
                    return false;
                }

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (!SaveTable())
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            this,
                            ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                        return false;
                    }
                }
            }

            return true;
        }
    }
}
