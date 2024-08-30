using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MattsPasswordManager.DTOs;

namespace MattsPasswordManager.Services
{
    internal class FileService
    {
        private FileService() { }

        public static List<Entry> LoadPasswordFile(string filePath, string encPassword)
        {
            // Load file
            string content;
            try
            {
                content = File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                throw new Exception("Error opening file!");
            }

            // Decrypt
            string decContent;
            try
            {
                decContent = EncryptionService.DecryptString(content, encPassword);
            }
            catch (CryptographicException)
            {
                throw new Exception("Incorrect password or file is corrupt!");
            }
            catch (Exception)
            {
                throw new Exception("An unknown decryption error occurred!");
            }

            // Parse JSON
            List<Entry>? entries;
            try
            {
                entries = JsonSerializer.Deserialize<List<Entry>>(decContent) ?? ([]);
            }
            catch (Exception)
            {
                throw new Exception("File data seems to be corrupted!");
            }

            return entries;
        }

        public static void SavePasswordFile(
            string filePath,
            List<Entry> entries,
            string encPassword
        )
        {
            // Convert to JSON
            string jsonString = JsonSerializer.Serialize(entries);

            string encJsonString;
            try
            {
                encJsonString = EncryptionService.EncryptString(jsonString, encPassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                throw new Exception("Error encrypting file!");
            }

            try
            {
                File.WriteAllText(filePath, encJsonString);
            }
            catch (Exception)
            {
                throw new Exception("Error saving file!");
            }
        }
    }
}
