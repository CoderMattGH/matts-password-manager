using MattsPasswordManager.DTOs;

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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MPM Files (*.mpm)|*.mpm";
            openFileDialog.Title = "Select a file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Clear the table
                passwordTable.Rows.Clear();

                string filePath = openFileDialog.FileName;
                MessageBox.Show(filePath);

                List<Entry> data;
                try
                {
                    data = FileService.LoadPasswordFile(filePath);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error opening file!");

                    return;
                }

                foreach (Entry entry in data)
                {
                    AddEntryToTable(entry);
                }
            }
        }

        private void AddEntryToTable(Entry entry)
        {
            passwordTable.Rows.Add(entry.Description, entry.Username, entry.Password);
        }

        private void FileSaveClickHandler(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked save!");
        }
    }
}
