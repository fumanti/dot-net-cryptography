using System;
using System.Diagnostics;

namespace secure_applications_cryptography
{
    class Program
    {
        static void Main(string[] args)
        {
            // Execute(RandomNumberGenerator);
            // Execute(HashData);
            //Execute(HMAC);
            Execute(Pbkdf2);
        }

        static void Execute(Action action)
        {
            action.Invoke();
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
            Console.WriteLine($"");
            Console.WriteLine($"");

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

        static void HMAC()
        {
            const string originalMessage = "Original message to Hash";
            const string originalMessage2 = "Original mmessage to Hash";

            Console.Clear();
            Console.WriteLine($"HMAC Demo in .NET");
            Console.WriteLine($"--------------------------");
            Console.WriteLine($"");
            
            var key = Random.GenerateRandomNumber(32);

            var hmessage1 = Hmac.ComputeHMAC_SHA512(System.Text.Encoding.UTF8.GetBytes(originalMessage), key);
            var hmessage2 = Hmac.ComputeHMAC_SHA512(System.Text.Encoding.UTF8.GetBytes(originalMessage2), key);

            Console.WriteLine($"Hash SHA512 1: {Convert.ToBase64String(hmessage1)}");
            Console.WriteLine($"Hash SHA512 2: {Convert.ToBase64String(hmessage2)}");
            Console.WriteLine($"");
            Console.WriteLine($"");

        }

      static void Pbkdf2()
      {
         //const string password = "V3r7K0mP1&xP4$$w07d";
         const string password = "the password";

         Console.Clear();
         Console.WriteLine($"Hashing password with PBKDF2 Demo in .NET");
         Console.WriteLine($"--------------------------");
         Console.WriteLine($"");

         var salt = Random.GenerateRandomNumber(PBKDF2.KeySize);
         int iterations = 100000;

         var sw = new Stopwatch();
         sw.Start();
         var hashedPassword = PBKDF2.HashPassword(System.Text.Encoding.UTF8.GetBytes(password), salt, iterations);
         sw.Stop();

         Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");
         Console.WriteLine($"Hashed password: {Convert.ToBase64String(hashedPassword)}");
         Console.WriteLine($"{iterations} iterations executed in: {sw.ElapsedMilliseconds} ms");
         Console.WriteLine($"");
         Console.WriteLine($"Write the password: ");
         string inputPassword = Console.ReadLine();
         var hashedInputPassword = PBKDF2.HashPassword(System.Text.Encoding.UTF8.GetBytes(inputPassword), salt, iterations);
         if(Convert.ToBase64String(hashedInputPassword) == Convert.ToBase64String(hashedPassword))
			{
            Console.WriteLine("Password match!");
			}
         else
         {
            Console.WriteLine("Password FAIL!");
         }
      }


   }
}
