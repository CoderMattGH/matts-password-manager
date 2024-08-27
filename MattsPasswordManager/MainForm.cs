using MattsPasswordManager.DTOs;
using MattsPasswordManager.Forms;

namespace MattsPasswordManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void FileLoadClickHandler(object sender, EventArgs e)
        {
            // Get filename
            OpenFileDialog openFileDialog =
                new() { Filter = "MPM Files (*.mpm)|*.mpm", Title = "Select a file" };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Clear the table
                passwordTable.Rows.Clear();

                string filePath = openFileDialog.FileName;

                List<Entry> data;
                try
                {
                    data = FileService.LoadPasswordFile(filePath);
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "Error opening file!", "Error");

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
            MessageBox.Show(this, "Clicked save!");
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

            passwordTable.Rows.RemoveAt(selectedRow.Index);
        }

        private void AddEntryToTable(Entry entry)
        {
            passwordTable.Rows.Add(entry.Description, entry.Username, entry.Password);
        }
    }
}
