using MattsPasswordManager.DTOs;

internal interface IMainForm
{
    event EventHandler? FileNewClick,
        FileLoadClick,
        FileSaveClick,
        FileSaveAsClick,
        ActionChangeRepoPasswordClick,
        AddEntryClick,
        EditEntryClick,
        RemoveEntryClick;

    event FormClosingEventHandler? CloseButtonClick;

    void FileNewClickHandler(object sender, EventArgs e);
    void FileExitClickHandler(object sender, EventArgs e);
    void CloseButtonHandler(object sender, FormClosingEventArgs e);
    void FileLoadClickHandler(object sender, EventArgs e);
    void FileSaveClickHandler(object sender, EventArgs e);
    void FileSaveAsClickHandler(object sender, EventArgs e);
    void ActionChangeRepoPasswordClickHandler(object sender, EventArgs e);
    void AddEntryClickHandler(object sender, EventArgs e);
    void EditEntryClickhandler(object sender, EventArgs e);
    void RemoveEntryClickHandler(object sender, EventArgs e);
    void AboutVersionClickHandler(object sender, EventArgs e);
    DialogResult ShowConfirmationDialog(string message);
    void ShowErrorDialog(string message);
    string? ShowSaveFileDialog();
    string? ShowOpenFileDialog();
    DialogResult ShowAddEntryForm(Entry entry);
    DialogResult ShowEditEntryForm(Entry entry);
    DialogResult ShowEditEncPasswordForm(EncPassword encPassword);
    DialogResult ShowAddEncPasswordForm(EncPassword encPassword);
    DialogResult ShowEnterEncPasswordForm(EncPassword encPassword);
    List<Entry> GetTableEntries();
    DataGridViewRow GetSelectedRow();
    void AddEntryToTable(Entry entry);
    void RemoveEntryInTable(int index);
    void ClearTable();
}
