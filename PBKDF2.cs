using System.Security.Cryptography;

namespace secure_applications_cryptography
{
    public static class PBKDF2 
    {
        public const int KeySize = 32;

        public static byte[] HashPassword(byte[] toBeHashed, byte[] salt, int iterations)
        {
         using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, iterations))
         {
            return rfc2898.GetBytes(20);
         }
        }
    }
}