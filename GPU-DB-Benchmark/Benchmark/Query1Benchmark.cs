using BenchmarkDotNet.Attributes;

namespace GPU_DB_Benchmark.Benchmark
{
    [MarkdownExporter, HtmlExporter]
    public class Query1Benchmark
    {
        private readonly OmniSci _omniSci = new();
        private readonly string _queryString;
        private readonly Blazing _blazing = new();

        [Params("1","2","3","4","5")]
        public string queryNumber;
        
        public Query1Benchmark()
        {
            _queryString = _omniSci.ReadQueryString(queryNumber);
        }

        [IterationSetup]
        public void ClearMemory() => _omniSci.ClearMemory();
        
        [Benchmark(Baseline = true)]
        public void OmniSci() => _omniSci.ExecuteQuery(_queryString);
        
        [Benchmark]
        public void Blazing() => _blazing.ExecuteQuery(queryNumber);
    }
}