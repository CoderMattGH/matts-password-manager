using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MattsPasswordManager.Services;
using Xunit.Abstractions;

public class EncryptionServiceTests
{
    public class EncryptStringTests
    {
        private EncryptionService _encryptionService;

        public EncryptStringTests()
        {
            this._encryptionService = new EncryptionService();
        }

        [Fact]
        public void ValidKey_ReturnsCipherText()
        {
            string plainText = "This is a string to be encrypted";
            string key = "key";

            var result = _encryptionService.EncryptString(plainText, key);

            Assert.NotEmpty(result);
        }

        [Fact]
        public void EmptyPlainText_ReturnsCipherText()
        {
            string plainText = "";
            string key = "key";

            var result = _encryptionService.EncryptString(plainText, key);

            Assert.NotEmpty(result);
        }

        [Fact]
        public void ValidKey_ReturnsValidCiperText()
        {
            string plainText = "This is a string to be encrypted";
            string key = "mykey";

            var encResult = _encryptionService.EncryptString(plainText, key);

            var decResult = _encryptionService.DecryptString(encResult, key);

            Assert.Equal(plainText, decResult);
        }

        [Fact]
        public void TooLongKey_ThrowsArgumentException()
        {
            string plainText = "This is a string to be encrypted";
            string key =
                "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";

            var exception = Assert.Throws<ArgumentException>(
                () => _encryptionService.EncryptString(plainText, key)
            );

            Assert.Equal("Key must be 16 bytes or less.", exception.Message);
        }
    }

    public class DecryptStringTests
    {
        private EncryptionService _encryptionService;

        public DecryptStringTests()
        {
            _encryptionService = new EncryptionService();
        }

        [Fact]
        public void ValidKey_ReturnsPlainText()
        {
            string cipherText =
                "PEgk3u7RmGRnZMY/4R0KZ8Vhd8y5JdZBqAIJ12i+pFEE1CsptuQydK/af35NvsyBv0tNZBHtAzoP4BFwMYSabA==";
            string key = "key";

            var result = _encryptionService.DecryptString(cipherText, key);

            Assert.Equal("This is a string to be encrypted", result);
        }

        [Fact]
        public void InvalidKey_ThrowsCryptographicException()
        {
            string cipherText =
                "PEgk3u7RmGRnZMY/4R0KZ8Vhd8y5JdZBqAIJ12i+pFEE1CsptuQydK/af35NvsyBv0tNZBHtAzoP4BFwMYSabA==";
            string key = "wrongkey";

            Assert.Throws<CryptographicException>(
                () => _encryptionService.DecryptString(cipherText, key)
            );
        }

        [Fact]
        public void TooLongKey_ThrowsArgumentException()
        {
            string cipherText =
                "PEgk3u7RmGRnZMY/4R0KZ8Vhd8y5JdZBqAIJ12i+pFEE1CsptuQydK/af35NvsyBv0tNZBHtAzoP4BFwMYSabA==";
            string key =
                "DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD";

            var exception = Assert.Throws<ArgumentException>(
                () => _encryptionService.EncryptString(cipherText, key)
            );

            Assert.Equal("Key must be 16 bytes or less.", exception.Message);
        }
    }
}
