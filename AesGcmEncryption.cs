using System.IO;
using System.Security.Cryptography;

namespace secure_applications_cryptography
{
    public class AesGcmEncryption
    {
        public (byte[], byte[]) Encrypt(byte[] dataToEncrypt, byte[] key, byte[] nonce)
        {
            // these will be filled during the encryption
            byte[] tag = new byte[16];
            byte[] cyphertext = new byte[dataToEncrypt.Length];

            using (var aesGcm = new AesGcm(key))
            {
                aesGcm.Encrypt(nonce, dataToEncrypt, cyphertext, tag);
            }
            return (cyphertext, tag);
        }

        public byte[] Decrypt(byte[] cypherText, byte[] key, byte[] nonce, byte[] tag)
        {
            byte[] decryptedData = new byte[cypherText.Length];

            using (var aesGcm = new AesGcm(key))
            {
                aesGcm.Decrypt(nonce, cypherText, tag, decryptedData);
            }
            return decryptedData;
        }
    }
}