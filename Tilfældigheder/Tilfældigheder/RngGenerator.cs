namespace Tilfældigheder
{
    using System;
    using System.Diagnostics;
    using System.Security.Cryptography;
    public class RngGenerator : IBenchmark
    {
        public RngGenerator()
        {
            this.Type = RandomNumberGeneratorType.RngCryptoServiceProvider;
        }
        
        public string BenchmarkTime { get; set; }

        public static byte[] GenerateRandomNumbers(int size)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[size];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        public RandomNumberGeneratorType Type { get; }

        public int[] Benchmark(int length)
        {
            var stopwatch = new Stopwatch();
            var values = new int[length];
            stopwatch.Start();
            for (int i = 0; i < length; i++)
            {
                values[i] = BitConverter.ToInt32(GenerateRandomNumbers(length), 0);
            }

            this.BenchmarkTime = stopwatch.Elapsed.ToString();
            stopwatch.Stop();
            stopwatch.Reset();
            return values;
        }
    }
}