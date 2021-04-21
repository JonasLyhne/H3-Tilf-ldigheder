using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Tilfældigheder
{
    class Program
    {
        private const int key = 24;
        static void Main(string[] args)
        {
            // Add generators.
            List<IBenchmark> Generators = new List<IBenchmark>();
            Generators.Add(new RngGenerator());
            Generators.Add(new RandomGenerator());
            
            Console.WriteLine("Let the race begin!");
            
            foreach (var generator in Generators)
            {
                var values = generator.Benchmark(2500);
                Console.WriteLine($"Generator type: {generator.Type}");
                for (int i = 0; i < values.Length; i++)
                {
                    Console.WriteLine($"Number {i+1}: {values[i]}");
                }

                Console.WriteLine($"Elapsed time: {generator.BenchmarkTime}");
            }
            

            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Welcome to the Cipher!");
            Console.WriteLine("Please enter a message to be encrypted: ");
            var message = Console.ReadLine();
            var encryptedMessage = Encrypter.Encipher(message, key);
            var decryptedMessage = Encrypter.Decipher(encryptedMessage, key);

            Console.WriteLine($"Original Message: {message}");
            Console.WriteLine($"Encrypted message: {encryptedMessage}");
            Console.WriteLine($"Decrypted message: {decryptedMessage}");
            



        }
    }
}