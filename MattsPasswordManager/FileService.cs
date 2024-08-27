using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MattsPasswordManager.DTOs;

namespace MattsPasswordManager
{
    internal class FileService
    {
        public static List<Entry> LoadPasswordFile(string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath);

                // Parse JSON
                List<Entry>? entries = JsonSerializer.Deserialize<List<Entry>>(content) ?? ([]);

                return entries;
            }
            catch (Exception)
            {
                throw new Exception("Error loading file!");
            }
        }

        public static void SavePasswordFile(string filePath)
        {
            Console.WriteLine("Saving password file...");

            Console.WriteLine("Finished saving!");
        }
    }
}
