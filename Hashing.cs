using System.Security.Cryptography;

namespace secure_applications_cryptography
{
    public static class Hashing
    {
        public static byte[] ComputeHash_MD5(byte[] toBeHashed)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(toBeHashed);
            }
        }

        public static byte[] ComputeHash_SHA512(byte[] toBeHashed)
        {
            using (var sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(toBeHashed);
            }
        }
    }
}