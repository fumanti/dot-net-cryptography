using System;

namespace secure_applications_cryptography
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomNumberGenerator();

            HashData();
        }

        static void RandomNumberGenerator()
        {
            Console.Clear();
            Console.WriteLine($"Random number generator Demo in .NET");
            Console.WriteLine($"--------------------------");
            Console.WriteLine($"");
            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Random number {i+1}: {Convert.ToBase64String(Random.GenerateRandomNumber(32))}");
            }
        }

        static void HashData()
        {
            const string originalMessage = "Original message to Hash";
            const string originalMessage2 = "Or1ginal message to Hash";

            Console.Clear();
            Console.WriteLine($"Random number generator Demo in .NET");
            Console.WriteLine($"--------------------------");
            Console.WriteLine($"Original message 1: {originalMessage}");
            Console.WriteLine($"Original message 2: {originalMessage2}");
            Console.WriteLine($"");
            
            var md5_1 = Hashing.ComputeHash_MD5(System.Text.Encoding.UTF8.GetBytes(originalMessage));
            var md5_2 = Hashing.ComputeHash_MD5(System.Text.Encoding.UTF8.GetBytes(originalMessage2));

            Console.WriteLine($"Hash MD5 1: {Convert.ToBase64String(md5_1)}");
            Console.WriteLine($"Hash MD5 2: {Convert.ToBase64String(md5_2)}");
            Console.WriteLine($"");

            var sha512_1 = Hashing.ComputeHash_SHA512(System.Text.Encoding.UTF8.GetBytes(originalMessage));
            var sha512_2 = Hashing.ComputeHash_SHA512(System.Text.Encoding.UTF8.GetBytes(originalMessage2));

            Console.WriteLine($"Hash SHA512 1: {Convert.ToBase64String(sha512_1)}");
            Console.WriteLine($"Hash SHA512 2: {Convert.ToBase64String(sha512_2)}");
            Console.WriteLine($"");
            Console.WriteLine($"");

        }
    }
}
