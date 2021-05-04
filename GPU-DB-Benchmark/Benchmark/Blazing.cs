using System;
using System.Diagnostics;
using System.IO;

namespace GPU_DB_Benchmark.Benchmark
{
    public class Blazing : IQueryExecutor
    {
        public void ExecuteQuery(string queryString)
        {
            var workingDirectory = Directory.GetCurrentDirectory();
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "bash",
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = false,
                    WorkingDirectory = workingDirectory,
                }
            };
            
            process.Start();
            using (var sw = process.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("cd Queries/BlazingSQL");
                    sw.WriteLine($"source /home/nomis/miniconda3/bin/activate");
                    sw.WriteLine($"/home/nomis/miniconda3/bin/python {workingDirectory}/Queries/BlazingSQL/Query{queryString}.py");
                }
            }
            
            while (!process.StandardOutput.EndOfStream)
            {
                var line = process.StandardOutput.ReadLine();
                Console.WriteLine(line);
            }
            
            process.WaitForExit();
        }
    }
}