using MattsPasswordManager.DTOs;
using MattsPasswordManager.Forms;
using MattsPasswordManager.Presenters;
using MattsPasswordManager.Services;

namespace MattsPasswordManager.Forms
{
    internal partial class MainForm : Form
    {
        public static readonly string FILE_EXT_FILTER = "MPM Files (*.mpm)|*.mpm";

        private readonly MainPresenter _mainPresenter;

        public MainForm(MainPresenter mainPresenter)
        {
            this._mainPresenter = mainPresenter;
            this.Icon = new Icon("MPM.ico");
            InitializeComponent();
        }

        private void FileNewClickHandler(object sender, EventArgs e)
        {
            _mainPresenter.NewRepo();
        }

        private void FileExitClickHandler(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CloseButtonHandler(object sender, FormClosingEventArgs e)
        {
            _mainPresenter.ProcessCloseApp(e);
        }

        private void FileLoadClickHandler(object sender, EventArgs e)
        {
            _mainPresenter.LoadRepo();
        }

        private void FileSaveClickHandler(object sender, EventArgs e)
        {
            _mainPresenter?.SaveRepo();
        }

        private void FileSaveAsClickHandler(object sender, EventArgs e)
        {
            _mainPresenter.SaveRepo(true);
        }

        private void ActionChangeRepoPasswordClickHandler(object sender, EventArgs e)
        {
            _mainPresenter.ChangeRepoPassword();
        }

        private void AddEntryClickHandler(object sender, EventArgs e)
        {
            _mainPresenter.AddEntry();
        }

        private void EditEntryClickhandler(object sender, EventArgs e)
        {
            _mainPresenter.EditEntry();
        }

        private void RemoveEntryClickHandler(object sender, EventArgs e)
        {
            _mainPresenter.RemoveEntry();
        }

        private void AboutVersionClickHandler(object sender, EventArgs e)
        {
            new VersionForm().ShowDialog();
        }

        public DialogResult ShowConfirmationDialog(string message)
        {
            DialogResult result = MessageBox.Show(
                message,
                "Question",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );

            return result;
        }

        public void ShowErrorDialog(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public string? ShowSaveFileDialog()
        {
            SaveFileDialog saveFileDialog =
                new()
                {
                    Filter = FILE_EXT_FILTER,
                    Title = "Save a file",
                    OverwritePrompt = true
                };

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }
            else
            {
                return null;
            }
        }

        public string? ShowOpenFileDialog()
        {
            OpenFileDialog openFileDialog =
                new() { Filter = FILE_EXT_FILTER, Title = "Select a file" };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return openFileDialog.FileName;
        }

        public DialogResult ShowAddEntryForm(Entry entry)
        {
            AddEntryForm addEntryForm = new(entry);

            return addEntryForm.ShowDialog();
        }

        public DialogResult ShowEditEntryForm(Entry entry)
        {
            EditEntryForm editEntryForm = new(entry);

            return editEntryForm.ShowDialog();
        }

        public DialogResult ShowEditEncPasswordForm(EncPassword encPassword)
        {
            EditEncPassForm editEncPassForm = new(encPassword);

            return editEncPassForm.ShowDialog();
        }

        public DialogResult ShowAddEncPasswordForm(EncPassword encPassword)
        {
            AddEncPassForm addEncPassForm = new(encPassword);

            return addEncPassForm.ShowDialog();
        }

        public DialogResult ShowEnterEncPasswordForm(EncPassword encPassword)
        {
            EnterPasswordForm enterPasswordForm = new(encPassword);

            return enterPasswordForm.ShowDialog();
        }

        public List<Entry> GetTableEntries()
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

            return entries;
        }

        public DataGridViewRow GetSelectedRow()
        {
            return passwordTable.CurrentRow;
        }

        public void AddEntryToTable(Entry entry)
        {
            passwordTable.Rows.Add(entry.Description, entry.Username, entry.Password);
        }

        public void RemoveEntryInTable(int index)
        {
            passwordTable.Rows.RemoveAt(index);
        }

        public void ClearTable()
        {
            passwordTable.Rows.Clear();
        }
    }
}
