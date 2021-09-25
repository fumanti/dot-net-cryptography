using System.Security.Cryptography;

namespace secure_applications_cryptography
{
    public static class Random
    {
        public static byte[] GenerateRandomNumber(int length)
        {
            using (var randomGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];
                randomGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
    }    
}