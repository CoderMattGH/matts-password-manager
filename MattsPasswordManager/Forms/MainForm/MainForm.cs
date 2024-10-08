using MattsPasswordManager.DTOs;
using MattsPasswordManager.Forms;
using MattsPasswordManager.Models;
using MattsPasswordManager.Presenters;
using MattsPasswordManager.Services;

namespace MattsPasswordManager.Forms
{
    internal partial class MainForm : Form, IMainForm
    {
        public static readonly string FILE_EXT_FILTER = "MPM Files (*.mpm)|*.mpm";

        public event EventHandler? FileNewClick,
            FileLoadClick,
            FileSaveClick,
            FileSaveAsClick,
            ActionChangeRepoPasswordClick,
            AddEntryClick,
            EditEntryClick,
            RemoveEntryClick,
            SearchBoxType;

        public event FormClosingEventHandler? CloseButtonClick;

        private ProgBarForm? _progBarForm;

        public MainForm()
        {
            this.Icon = new Icon("MPM.ico");
            InitializeComponent();
        }

        public void FileNewClickHandler(object sender, EventArgs e)
        {
            FileNewClick?.Invoke(this, EventArgs.Empty);
        }

        public void FileExitClickHandler(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void CloseButtonHandler(object sender, FormClosingEventArgs e)
        {
            CloseButtonClick?.Invoke(this, e);
        }

        public void FileLoadClickHandler(object sender, EventArgs e)
        {
            FileLoadClick?.Invoke(this, EventArgs.Empty);
        }

        public void FileSaveClickHandler(object sender, EventArgs e)
        {
            FileSaveClick?.Invoke(this, EventArgs.Empty);
        }

        public void FileSaveAsClickHandler(object sender, EventArgs e)
        {
            FileSaveAsClick?.Invoke(this, EventArgs.Empty);
        }

        public void ActionChangeRepoPasswordClickHandler(object sender, EventArgs e)
        {
            ActionChangeRepoPasswordClick?.Invoke(this, EventArgs.Empty);
        }

        public void AddEntryClickHandler(object sender, EventArgs e)
        {
            AddEntryClick?.Invoke(this, EventArgs.Empty);
        }

        public void EditEntryClickhandler(object sender, EventArgs e)
        {
            EditEntryClick?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveEntryClickHandler(object sender, EventArgs e)
        {
            RemoveEntryClick?.Invoke(this, EventArgs.Empty);
        }

        public void AboutVersionClickHandler(object sender, EventArgs e)
        {
            new VersionForm().ShowDialog();
        }

        public void SearchBoxTypeHandler(object sender, EventArgs e)
        {
            SearchBoxType?.Invoke(this, EventArgs.Empty);
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

        public DialogResult ShowAddEntryForm(Entry entry, List<Entry> entries)
        {
            AddEntryForm addEntryForm = new(entry, entries);

            return addEntryForm.ShowDialog();
        }

        public DialogResult ShowEditEntryForm(Entry entry, List<Entry> entries)
        {
            EditEntryForm editEntryForm = new(entry, entries);

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

        public void ShowProgBarForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ShowProgBarForm));
            }
            else
            {
                this.Enabled = false;
                this._progBarForm = new();
                this._progBarForm.SetProgressPercentage(0);
                this._progBarForm.Show();
            }
        }

        public void HideProgBarForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(HideProgBarForm));
            }
            else
            {
                if (this._progBarForm != null)
                {
                    this.Enabled = true;
                    this._progBarForm.CloseForm();
                    this._progBarForm = null;
                }
            }
        }

        public void UpdateProgBarForm(int percentage)
        {
            this._progBarForm?.SetProgressPercentage(percentage);
        }

        public DataGridViewRow GetSelectedRow()
        {
            return passwordTable.CurrentRow;
        }

        public void AddEntryToTable(Entry entry)
        {
            int rowIndex = passwordTable.Rows.Add(
                entry.Description,
                entry.Username,
                entry.Password
            );
            passwordTable.Rows[rowIndex].Tag = entry;
        }

        public void RemoveEntryInTable(int index)
        {
            passwordTable.Rows.RemoveAt(index);
        }

        public void SetTable(List<Entry> entries)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<List<Entry>>(SetTable), entries);
            }
            else
            {
                ClearTable();

                foreach (Entry entry in entries)
                {
                    AddEntryToTable(entry);
                }
            }
        }

        public void ClearTable()
        {
            passwordTable.Rows.Clear();
        }

        public void UpdateFilename(string filename)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(UpdateFilename), filename);
            }
            else
            {
                string title = "Matts Password Manager";

                if (filename != "")
                {
                    title += $" [{filename}]";
                }

                this.Text = title;
            }
        }

        public string GetSearchBoxText()
        {
            return searchBox.Text;
        }

        public void SetSearchBoxText(string text)
        {
            searchBox.Text = text;
        }
    }
}
