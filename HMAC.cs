using System.Security.Cryptography;

namespace secure_applications_cryptography
{
    public static class Hmac 
    {
        private const int KeySize = 32;

        public static byte[] ComputeHMAC_SHA512(byte[] toBeHashed, byte[] key)
        {
            using (var hmac = new HMACSHA512(key))
            {
                return hmac.ComputeHash(toBeHashed);
            }
        }
    }
}