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

            EncryptionService encryptionService = new EncryptionService();
            FileService fileService = new(encryptionService);

            MainModel mainModel = new();

            MainPresenter mainPresenter = new(fileService, mainModel);
            MainForm mainForm = new(mainPresenter);

            mainPresenter.MainForm = mainForm;

            Application.Run(mainForm);
        }
    }
}
