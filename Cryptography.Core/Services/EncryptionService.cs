using System.Security.Cryptography;
using Cryptography.Core.Models;

namespace Cryptography.Core.Services
{
    internal class EncryptionService
    {

        public static string Encrypt(string plainText, EncryptionKeys encryptionKeys)
        {
            
            if (encryptionKeys.SymmetricKey is not null)
            {
                return EncryptAES(plainText, encryptionKeys.SymmetricKey);
            }
            if (encryptionKeys.AsymmetricKey is not null)
            {
                return EncryptRSA(plainText, encryptionKeys.AsymmetricKey);
            }

            throw new CryptographicException("Unknows encryption keys");
        }

        #region AES
        public static SymmetricKeyAES CreateSymmetricKey()
        {
            var aes = Aes.Create();

            aes.GenerateIV();
            aes.GenerateKey();

            return new SymmetricKeyAES
            {
                Key = Convert.ToBase64String(aes.Key),
                IV = Convert.ToBase64String(aes.IV)
            };
        }
        public static string EncryptAES(string plainText, SymmetricKeyAES symmetricKeyAES)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException(nameof(plainText));

            if (symmetricKeyAES.IV is null || symmetricKeyAES.Key is null)
                throw new ArgumentNullException(nameof(symmetricKeyAES));

            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Convert.FromBase64String(symmetricKeyAES.Key);
                aesAlg.IV = Convert.FromBase64String(symmetricKeyAES.IV);

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using MemoryStream msEncrypt = new();
                using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (StreamWriter swEncrypt = new(csEncrypt))
                {
                    //Write all data to the stream.
                    swEncrypt.Write(plainText);
                }

                encrypted = msEncrypt.ToArray();
            }

            return Convert.ToBase64String(encrypted);
        }

        public static string DecryptAES(string encryptedText, SymmetricKeyAES symmetricKeyAES)
        {
            if (string.IsNullOrEmpty(encryptedText))
                throw new ArgumentNullException(nameof(encryptedText));

            if (symmetricKeyAES.IV is null || symmetricKeyAES.Key is null)
                throw new ArgumentNullException(nameof(symmetricKeyAES));

            byte[] cipherText = Convert.FromBase64String(encryptedText);

            string decryptedText;

            // Create an Aes object with the specified symmetric key.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Convert.FromBase64String(symmetricKeyAES.Key);
                aesAlg.IV = Convert.FromBase64String(symmetricKeyAES.IV);

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using MemoryStream msDecrypt = new(cipherText);
                using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
                using StreamReader srDecrypt = new(csDecrypt);
                // Read the decrypted bytes from the decrypting stream
                // and place them in a string.
                decryptedText = srDecrypt.ReadToEnd();
            }

            return decryptedText;
        }
        #endregion

        #region RSA
        public static AsymmetricKeyRSA CreateAsymmetricKey()
        {
            using var rsa = new RSACryptoServiceProvider(2048);
            try
            {
                return new AsymmetricKeyRSA
                {
                    PublicKey = rsa.ToXmlString(false),
                    PrivateKey = rsa.ToXmlString(true)
                };
            }
            finally
            {
                rsa.PersistKeyInCsp = false; // keys should not be persisted on the computer
            }
        }
        public static string EncryptRSA(string plainText, AsymmetricKeyRSA asymmetricKeyRSA)
        {
            // TODO
            return string.Empty;
        }
        #endregion
    }
}
