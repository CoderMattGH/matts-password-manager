using System;
using System.Collections.Generic;
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
        [Fact]
        public void LoadValidPasswordFile_ReturnsEntries()
        {
            string filePath = "TestMPM.mpm";
            string password = "password";

            List<Entry> result = FileService.LoadPasswordFile(filePath, password);

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
                () => FileService.LoadPasswordFile(filePath, password)
            );

            Assert.Equal("Incorrect password or file is corrupt!", ex.Message);
        }

        [Fact]
        public void FileDoesntExist_ThrowsException()
        {
            string filePath = "FileNotFound.mpm";
            string password = "password";

            Exception ex = Assert.Throws<Exception>(
                () => FileService.LoadPasswordFile(filePath, password)
            );

            Assert.Equal("Error opening file!", ex.Message);
        }

        [Fact]
        public void CorruptedFile_ThrowsException()
        {
            string filePath = "TestCorruptMPM.mpm";
            string password = "password";

            Exception ex = Assert.Throws<Exception>(
                () => FileService.LoadPasswordFile(filePath, password)
            );

            Assert.Equal("An unknown decryption error occurred!", ex.Message);
        }
    }
}
