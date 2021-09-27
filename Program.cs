using System;
using System.Diagnostics;
using System.Text;

namespace secure_applications_cryptography
{
    class Program
    {
        static void Main(string[] args)
        {
            // Execute(RandomNumberGenerator);
            // Execute(HashData);
            //Execute(HMAC);
            //Execute(Pbkdf2);
            // Execute(TestAesEncryption);
            // Execute(TestAesGCM);
            Execute(TestDPAPI);
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

            byte[] salt = null;
            Console.WriteLine($"Do you want to add salt ? (y/n)");
            var inputYesNo = Console.ReadKey();
            if (inputYesNo.KeyChar == 'y')
			   {
               salt = Random.GenerateRandomNumber(32);
               Console.WriteLine($"");
               Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");
            }

            var md5_1 = Hashing.ComputeHash_MD5(System.Text.Encoding.UTF8.GetBytes(originalMessage), salt);
            var md5_2 = Hashing.ComputeHash_MD5(System.Text.Encoding.UTF8.GetBytes(originalMessage2), salt);

            Console.WriteLine($"Hash MD5 1: {Convert.ToBase64String(md5_1)}");
            Console.WriteLine($"Hash MD5 2: {Convert.ToBase64String(md5_2)}");
            Console.WriteLine($"");

            var sha512_1 = Hashing.ComputeHash_SHA512(System.Text.Encoding.UTF8.GetBytes(originalMessage), salt);
            var sha512_2 = Hashing.ComputeHash_SHA512(System.Text.Encoding.UTF8.GetBytes(originalMessage2), salt);

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
         //const string password = "V3r7K0mP1&xP4$$w0?d";
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

        static void TestAesEncryption()
        {
            const string originalMessage = "Text to Encrypt";

            Console.Clear();
            Console.WriteLine($"AES Encryption Demo in .NET");
            Console.WriteLine($"--------------------------");
            Console.WriteLine($"");
            
            var aes = new AesEncryption();
            var key = Random.GenerateRandomNumber(32);
            var iv = Random.GenerateRandomNumber(16);

            var encrypted = aes.Encrypt(Encoding.UTF8.GetBytes(originalMessage), key, iv);
            var decrypted = aes.Decrypt(encrypted, key, iv);

            Console.WriteLine($"Original : {originalMessage}");
            Console.WriteLine($"Encrypted: {Convert.ToBase64String(encrypted)}");
            Console.WriteLine($"Decrypted: {Encoding.UTF8.GetString(decrypted)}");
            Console.WriteLine($"");
            Console.WriteLine($"");

        }

        static void TestAesGCM()
        {
            // const string originalMessage = "Super Secret Text to Encrypt";

            Console.Clear();
            Console.WriteLine($"AES GCM Encryption Demo in .NET");
            Console.WriteLine($"--------------------------");
            Console.WriteLine($"");
            
            Console.WriteLine($"Write your secret message to encrypt");
            string originalMessage = Console.ReadLine();

            var aesGcm = new AesGcmEncryption();
            var gcmKey = Random.GenerateRandomNumber(32);
            var nonce = Random.GenerateRandomNumber(12);

            // Encrypt
            (byte[] cypherText, byte[] tag) encrypted = aesGcm.Encrypt(Encoding.UTF8.GetBytes(originalMessage), gcmKey, nonce);
            
            // Decrypt
            byte[] decrypted = aesGcm.Decrypt(encrypted.cypherText, gcmKey, nonce, encrypted.tag);

            // Console.WriteLine($"Original : {originalMessage}");
            Console.WriteLine($"Encrypted: {Convert.ToBase64String(encrypted.cypherText)}");
            Console.WriteLine($"Decrypted: {Encoding.UTF8.GetString(decrypted)}");
            Console.WriteLine($"");
            Console.WriteLine($"");

        }

        static void TestDPAPI()
        {
            // const string originalMessage = "Super Secret Text to Encrypt";

            Console.Clear();
            Console.WriteLine($"DPAPI Demo in .NET");
            Console.WriteLine($"--------------------------");
            Console.WriteLine($"");
            
            Console.WriteLine($"Write your secret message to store");
            string originalMessage = Console.ReadLine();
            
            Console.WriteLine($"Write random characters if you want to add entropy, or else press [return]");
            string entropy = Console.ReadLine();

            // Protect
            var encrypted = Protected.Protect(originalMessage, entropy, System.Security.Cryptography.DataProtectionScope.LocalMachine);
            
            // Unprotect
            string decrypted = Protected.Unprotect(encrypted, entropy, System.Security.Cryptography.DataProtectionScope.LocalMachine);

            Console.WriteLine($"Encrypted: {encrypted}");
            Console.WriteLine($"Decrypted: {decrypted}");
            Console.WriteLine($"");
            Console.WriteLine($"");

        }

   }
}
