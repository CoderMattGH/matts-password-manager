using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MattsPasswordManager.DTOs;
using MattsPasswordManager.Services;

public class FileServiceTests
{
    public class LoadPasswordFileTests
    {
        private readonly FileService _fileService;

        public LoadPasswordFileTests()
        {
            this._fileService = new FileService(new EncryptionService());
        }

        [Fact]
        public void LoadValidPasswordFile_ReturnsEntries()
        {
            string filePath = "TestMPM.mpm";
            string password = "password";

            List<Entry> result = _fileService.LoadPasswordFile(filePath, password);

            Assert.Equal(2, result.Count());
            Assert.Equal("TestEntry1", result[0].Description);
            Assert.Equal("Matt", result[0].Username);
            Assert.Equal("password", result[0].Password);
        }

        [Fact]
        public void IncorrectPassword_ThrowsException()
        {
            string filePath = "TestMPM.mpm";
            string password = "invalidpassword";

            Exception ex = Assert.Throws<Exception>(
                () => _fileService.LoadPasswordFile(filePath, password)
            );

            Assert.Equal("Incorrect password or file is corrupt!", ex.Message);
        }

        [Fact]
        public void FileDoesntExist_ThrowsException()
        {
            string filePath = "FileNotFound.mpm";
            string password = "password";

            Exception ex = Assert.Throws<Exception>(
                () => _fileService.LoadPasswordFile(filePath, password)
            );

            Assert.Equal("Error opening file!", ex.Message);
        }

        [Fact]
        public void CorruptedFile_ThrowsException()
        {
            string filePath = "TestCorruptMPM.mpm";
            string password = "password";

            Exception ex = Assert.Throws<Exception>(
                () => _fileService.LoadPasswordFile(filePath, password)
            );

            Assert.Equal("An unknown decryption error occurred!", ex.Message);
        }
    }

    public class SavePasswordFile : IDisposable
    {
        private readonly string _testFilePath;
        private readonly FileService _fileService;

        public SavePasswordFile()
        {
            this._fileService = new FileService(new EncryptionService());
            this._testFilePath = Path.GetTempFileName();
        }

        public void Dispose()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }

        [Fact]
        public void SaveValidPasswordFile_SavesFile()
        {
            string filePath = _testFilePath;
            string password = "password";

            List<Entry> entries =
            [
                new Entry()
                {
                    Description = "Test1",
                    Username = "Matt",
                    Password = "password"
                },
                new Entry()
                {
                    Description = "Test2",
                    Username = "Matt",
                    Password = "password"
                }
            ];

            _fileService.SavePasswordFile(filePath, entries, password);

            Assert.True(File.Exists(filePath));
        }

        [Fact]
        public void SaveValidPasswordFile_SavesValidFile()
        {
            string filePath = _testFilePath;
            string password = "password";

            List<Entry> entries =
            [
                new Entry()
                {
                    Description = "Test1",
                    Username = "Matt",
                    Password = "password"
                },
                new Entry()
                {
                    Description = "Test2",
                    Username = "Matt",
                    Password = "password"
                }
            ];

            _fileService.SavePasswordFile(filePath, entries, password);
            Assert.True(File.Exists(filePath));

            // Try and open file.
            List<Entry> result = _fileService.LoadPasswordFile(filePath, password);

            Assert.True(result.SequenceEqual(result));
        }

        [Fact]
        public void SaveToAlreadyExistsFile_SavesFile()
        {
            string filePath = _testFilePath;
            string password = "password";

            List<Entry> entries =
            [
                new Entry()
                {
                    Description = "Test1",
                    Username = "Matt",
                    Password = "password"
                },
                new Entry()
                {
                    Description = "Test2",
                    Username = "Matt",
                    Password = "password"
                }
            ];

            // Create file
            File.WriteAllText(filePath, "TESTING TESTING");

            // Now try and save to file
            _fileService.SavePasswordFile(filePath, entries, password);
        }

        [Fact]
        public void SaveToAlreadyOpenFile_ThrowsException()
        {
            string filePath = _testFilePath;
            string password = "password";

            List<Entry> entries =
            [
                new Entry()
                {
                    Description = "Test1",
                    Username = "Matt",
                    Password = "password"
                },
                new Entry()
                {
                    Description = "Test2",
                    Username = "Matt",
                    Password = "password"
                }
            ];

            // Create file
            File.WriteAllText(filePath, "TESTING TESTING");

            // Open file
            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                var exception = Assert.Throws<Exception>(
                    () => _fileService.SavePasswordFile(filePath, entries, password)
                );

                Assert.Equal("Error saving file!", exception.Message);
            }
        }
    }
}
