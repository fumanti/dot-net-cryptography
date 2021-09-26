using System;
using System.Security.Cryptography;

namespace secure_applications_cryptography
{
    public static class Hashing
    {
        public static byte[] ComputeHash_MD5(byte[] toBeHashed, byte[] salt = null)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(salt != null ? Combine(toBeHashed, salt) : toBeHashed);
            }
        }

        public static byte[] ComputeHash_SHA512(byte[] toBeHashed, byte[] salt = null)
        {
            using (var sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(salt != null ? Combine(toBeHashed, salt) : toBeHashed);
            }
        }

        public static byte[] Combine(byte[] password, byte[] salt)
        {
            var ret = new byte[password.Length + salt.Length];
            Buffer.BlockCopy(password, 0, ret, 0, password.Length);
            Buffer.BlockCopy(salt, 0, ret, password.Length, salt.Length);
            return ret;
        }
    }
}