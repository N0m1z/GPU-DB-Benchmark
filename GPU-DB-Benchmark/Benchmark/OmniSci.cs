using System;
using System.Diagnostics;

namespace GPU_DB_Benchmark.Benchmark
{
    public class OmniSci : IQueryExecutor
    {
        public void ExecuteQueries()
        {
            var args = "Queries/OmniSci/Query1.sql | $OMNISCI_PATH/bin/omnisql -p HyperInteractive";
            Process.Start("cat", args);
        }
    }
}