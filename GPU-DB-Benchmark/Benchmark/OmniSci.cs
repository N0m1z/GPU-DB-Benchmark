using System;
using System.Diagnostics;

namespace GPU_DB_Benchmark.Benchmark
{
    public class OmniSci : IQueryExecutor
    {
        public void ExecuteQuery1()
        {
            var queryString = ReadQueryString("1");
            ExecuteQuery(queryString);
        }

        public void ExecuteQuery2()
        {
            var queryString = ReadQueryString("2");
            ExecuteQuery(queryString);
        }

        public void ExecuteQuery3()
        {
            var queryString = ReadQueryString("3");
            ExecuteQuery(queryString);
        }

        public void ExecuteQuery4()
        {
            var queryString = ReadQueryString("4");
            ExecuteQuery(queryString);
        }

        public void ExecuteQuery5()
        {
            var queryString = ReadQueryString("5");
            ExecuteQuery(queryString);
        }

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
    }
}