using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper.Configuration.Attributes;
using GPU_DB_Benchmark.DataGeneration;
using GPU_DB_Benchmark.Models;

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
                    
                    Genrate(factor);
                    break;
                case "benchmark":
                    Benchmark();
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }

        private static void Genrate(int factor)
        {
            var companies = DataGenerator.GenerateData(factor);
            
            CsvCreator.WriteCsv(companies);
        }

        private static void Benchmark()
        {
            
        }
    }
}