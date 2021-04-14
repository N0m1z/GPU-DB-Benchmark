using System;
using System.Collections.Generic;
using GPU_DB_Benchmark.DataAccess;
using GPU_DB_Benchmark.DataGeneration;
using GPU_DB_Benchmark.Models;

namespace GPU_DB_Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            CsvCreator.WriteCsv("CsvFiles");
        }
    }
}