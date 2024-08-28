using MattsPasswordManager.DTOs;
using MattsPasswordManager.Forms;
using MattsPasswordManager.Services;

namespace MattsPasswordManager.Forms
{
    public partial class MainForm : Form
    {
        public static readonly string FILE_EXT_FILTER = "MPM Files (*.mpm)|*.mpm";

        private string _openFilePath = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void FileLoadClickHandler(object sender, EventArgs e)
        {
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
            // Convert all the table entrys to Entry objects
            List<Entry> entries = [];

            for (int i = 0; i < passwordTable.Rows.Count; i++)
            {
                DataGridViewRow row = passwordTable.Rows[i];

                string description = row.Cells[0].Value.ToString() ?? "";
                string username = row.Cells[1].Value.ToString() ?? "";
                string password = row.Cells[1].Value.ToString() ?? "";

                Entry entry =
                    new()
                    {
                        Description = description,
                        Username = username,
                        Password = password
                    };

                entries.Add(entry);
            }

            if (this._openFilePath == "")
            {
                SaveFileDialog saveFileDialog =
                    new() { Filter = FILE_EXT_FILTER, Title = "Save a file" };

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                this._openFilePath = saveFileDialog.FileName;
            }

            try
            {
                FileService.SavePasswordFile(this._openFilePath, entries);
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
            }
        }

        private void AddEntryToTable(Entry entry)
        {
            passwordTable.Rows.Add(entry.Description, entry.Username, entry.Password);
        }
    }
}
