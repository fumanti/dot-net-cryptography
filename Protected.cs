using System;
using System.Security.Cryptography;
using System.Text;

namespace secure_applications_cryptography
{
    public static class Protected
    {
        public static string Protect(string stringToEncrypt, string entropy, DataProtectionScope scope)
        {
            byte[] encryptedData = ProtectedData.Protect(
                Encoding.UTF8.GetBytes(stringToEncrypt), 
                !string.IsNullOrEmpty(entropy) ? Encoding.UTF8.GetBytes(entropy) : null,
                scope);

            return Convert.ToBase64String(encryptedData);
        }

        public static string Unprotect(string encryptedString, string entropy, DataProtectionScope scope)
        {
            byte[] decrypted = ProtectedData.Unprotect(
                Convert.FromBase64String(encryptedString), 
                !string.IsNullOrEmpty(entropy) ? Encoding.UTF8.GetBytes(entropy) : null, 
                scope);
            return Encoding.UTF8.GetString(decrypted);
        }

        public static byte[] Protect(byte[] dataToEncrypt, byte[] entropy, DataProtectionScope scope)
        {
            return ProtectedData.Protect(dataToEncrypt, entropy, scope);
        }

        public static byte[] Unprotect(byte[] encryptedData, byte[] entropy, DataProtectionScope scope)
        {
            return ProtectedData.Unprotect(encryptedData, entropy, scope);
        }

        
    }
}