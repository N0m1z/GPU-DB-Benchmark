using BenchmarkDotNet.Attributes;

namespace GPU_DB_Benchmark.Benchmark
{
    [MarkdownExporter, HtmlExporter]
    public class Query5Benchmark
    {
        private readonly OmniSci _omniSci = new();
        private readonly string _queryString1;
        
        public Query5Benchmark()
        {
            _queryString1 = _omniSci.ReadQueryString("5");
        }
        
        [Benchmark]
        public void OmniSci5() => _omniSci.ExecuteQuery(_queryString1);
    }
}