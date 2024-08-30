using MattsPasswordManager.Forms;
using MattsPasswordManager.Models;
using MattsPasswordManager.Presenters;
using MattsPasswordManager.Services;

namespace MattsPasswordManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            EncryptionService encryptionService = new();
            FileService fileService = new(encryptionService);

            MainForm mainForm = new();
            MainModel mainModel = new();

            MainPresenter mainPresenter = new(mainForm, mainModel, fileService);

            Application.Run(mainForm);
        }
    }
}
