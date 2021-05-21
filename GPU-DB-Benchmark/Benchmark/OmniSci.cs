using System;
using System.Diagnostics;
using System.IO;
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
                    Arguments = $"{Directory.GetCurrentDirectory()}/Queries/OmniSci/Query{queryNumber}.sql",
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