using System.IO;
using System.Security.Cryptography;

namespace secure_applications_cryptography
{
    public class AesEncryption
    {
        public byte[] Encrypt(byte[] data, byte[] key, byte[] iv)
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                aes.Key = key;
                aes.IV = iv;

                using (var stream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(stream, aes.CreateEncryptor(), CryptoStreamMode.Write);

                    cryptoStream.Write(data, 0, data.Length);
                    cryptoStream.FlushFinalBlock();
                    return stream.ToArray();
                }
            }
        }

        public byte[] Decrypt(byte[] data, byte[] key, byte[] iv)
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                aes.Key = key;
                aes.IV = iv;

                using (var stream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(stream, aes.CreateDecryptor(), CryptoStreamMode.Write);

                    cryptoStream.Write(data, 0, data.Length);
                    cryptoStream.FlushFinalBlock();
                    return stream.ToArray();
                }
            }
        }
    }
}