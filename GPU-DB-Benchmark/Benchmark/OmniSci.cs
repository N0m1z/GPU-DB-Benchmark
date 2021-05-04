using System;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;

namespace GPU_DB_Benchmark.Benchmark
{
    public class OmniSci : IQueryExecutor
    {
        public string ReadQueryString(string queryNumber)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cat",
                    Arguments = $"/home/nomis/GPU-DB-Benchmark/GPU-DB-Benchmark/Queries/OmniSci/Query{queryNumber}.sql",
                    RedirectStandardOutput = true
                }
            };

            proc.Start();
            var queryString = proc.StandardOutput.ReadToEnd();
            return queryString;
        }

        public void ExecuteQuery(string queryString)
        {
            var omni = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/opt/omnisci/bin/omnisql",
                    Arguments = "-p HyperInteractive",
                    RedirectStandardInput = true,
                }
            };

            omni.Start();
            omni.StandardInput.Write(queryString);
            omni.StandardInput.Close();
            omni.WaitForExit();
        }
        
        [IterationSetup]
        public void ClearMemory()
        {
            var omni = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/opt/omnisci/bin/omnisql",
                    Arguments = "-p HyperInteractive",
                    RedirectStandardInput = true,
                }
            };

            omni.Start();
            omni.StandardInput.WriteLine("\\clear_gpu");
            omni.StandardInput.WriteLine("\\clear_cpu");
            omni.StandardInput.Close();
            omni.WaitForExit();
        }
    }
}