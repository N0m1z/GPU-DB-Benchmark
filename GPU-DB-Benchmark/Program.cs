using System;
using System.Collections.Generic;
using System.IO;
using GPU_DB_Benchmark.DataAccess;
using GPU_DB_Benchmark.DataGeneration;
using GPU_DB_Benchmark.Models;

namespace GPU_DB_Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var companies = DataGenerator.GenerateData(10000);
            
            CsvCreator.WriteCsv("CsvFiles", companies);
        }
    }
}