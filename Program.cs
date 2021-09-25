using System;

namespace secure_applications_cryptography
{
    class Program
    {
        static void Main(string[] args)
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
    }
}
