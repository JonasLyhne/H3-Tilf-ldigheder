using System;
using System.Diagnostics;

namespace Tilfældigheder
{
    public interface IBenchmark
    {
        /// <summary>
        /// The time it took to run a benchmark.
        /// </summary>
        String BenchmarkTime { get; set; }
        
        /// <summary>
        /// The type of random number generator.
        /// </summary>
        RandomNumberGeneratorType Type { get; }
        
        /// <summary>
        /// This is used to run a benchmark of a random number generator.
        /// 
        /// </summary>
        /// <param name="length">The amount of random numbers to generate.</param>
        /// <returns></returns>
        int[] Benchmark(int length);
    }
}