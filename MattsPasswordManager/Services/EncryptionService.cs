using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;

namespace MattsPasswordManager.Services
{
    internal class EncryptionService
    {
        private EncryptionService() { }

        public static string EncryptString(string plainText, string key)
        {
            byte[] iv;
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = PadKeyTo16Bytes(key);
                aesAlg.GenerateIV();
                iv = aesAlg.IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new())
                {
                    using (
                        CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write)
                    )
                    using (StreamWriter swEncrypt = new(csEncrypt))
                    {
                        // Prepend the IV to the encrypted message
                        msEncrypt.Write(iv, 0, iv.Length);
                        swEncrypt.Write(plainText);
                    }

                    encrypted = msEncrypt.ToArray();
                }
            }

            return Convert.ToBase64String(encrypted);
        }

        public static string DecryptString(string cipherTextCombined, string key)
        {
            string? plainText = null;
            byte[] fullCipher = Convert.FromBase64String(cipherTextCombined);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = PadKeyTo16Bytes(key);

                // Extract the IV from the beginning of the cipher text
                byte[] iv = new byte[aesAlg.BlockSize / 8];
                Array.Copy(fullCipher, 0, iv, 0, iv.Length);
                aesAlg.IV = iv;

                // Extract the actual cipher text
                byte[] cipherText = new byte[fullCipher.Length - iv.Length];
                Array.Copy(fullCipher, iv.Length, cipherText, 0, cipherText.Length);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new(cipherText))
                using (CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (StreamReader srDecrypt = new(csDecrypt))
                {
                    plainText = srDecrypt.ReadToEnd();
                }
            }

            return plainText;
        }

        private static byte[] PadKeyTo16Bytes(string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            if (keyBytes.Length > 16)
            {
                throw new ArgumentException("Key must be 16 bytes or less.");
            }

            Array.Resize(ref keyBytes, 16);

            return keyBytes;
        }
    }
}
