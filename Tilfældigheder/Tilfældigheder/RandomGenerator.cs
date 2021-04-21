using System;
using System.Diagnostics;

namespace Tilfældigheder
{
    public class RandomGenerator : IBenchmark
    {
        public RandomGenerator()
        {
            this.Type = RandomNumberGeneratorType.RandomNumber;
        }
        public string BenchmarkTime { get; set; }

        public RandomNumberGeneratorType Type { get; }

        public int[] Benchmark(int length)
        {
            var randomNumber = new Random();
            var stopwatch = new Stopwatch();
            var values = new int[length];
            stopwatch.Start();
            for (int i = 0; i < length; i++)
            {
                values[i] = randomNumber.Next(Int32.MinValue, Int32.MaxValue);
            }

            this.BenchmarkTime = stopwatch.Elapsed.ToString();
            stopwatch.Stop();
            stopwatch.Reset();
            return values;
        }
    }
}