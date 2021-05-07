using BenchmarkDotNet.Attributes;

namespace GPU_DB_Benchmark.Benchmark
{
    [MarkdownExporter, HtmlExporter, RPlotExporter]
    public class Query1Benchmark
    {
        private readonly OmniSci _omniSci = new();
        private string _queryString;
        private readonly Blazing _blazing = new();

        [Params("1","2","3","4","5")]
        public string queryNumber;


        [IterationSetup]
        public void Prepare()
        {
            _omniSci.ClearMemory();
            _queryString = _omniSci.ReadQueryString(queryNumber);
        }

        [Benchmark(Baseline = true)]
        public void OmniSci() => _omniSci.ExecuteQuery(_queryString);
        
        [Benchmark]
        public void Blazing() => _blazing.ExecuteQuery(queryNumber);
    }
}