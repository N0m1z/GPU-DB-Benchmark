using System;
using BenchmarkDotNet.Running;
using GPU_DB_Benchmark.Benchmark;
using GPU_DB_Benchmark.DataGeneration;

namespace GPU_DB_Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No arguments given");
                return;
            }

            var command = args[0];
            switch (command)
            {
                case "generate" when args.Length == 2:
                    var suc = int.TryParse(args[1], out var factor);
                    if (!suc)
                        goto default;
                    
                    Generate(factor * 2000);
                    Console.WriteLine("Done!");
                    break;
                case "benchmark":
                    Benchmark();
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }

        private static void Generate(int factor)
        {
            Console.WriteLine("Generating Data");
            DataGenerator.GenerateData(factor);
        }

        private static void Benchmark()
        {
            BenchmarkRunner.Run<Query1Benchmark>();
            BenchmarkRunner.Run<Query2Benchmark>();
            BenchmarkRunner.Run<Query3Benchmark>();
            BenchmarkRunner.Run<Query4Benchmark>();
            BenchmarkRunner.Run<Query5Benchmark>();
        }
    }
}