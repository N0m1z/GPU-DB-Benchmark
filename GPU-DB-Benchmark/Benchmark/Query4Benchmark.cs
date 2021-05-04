using BenchmarkDotNet.Attributes;

namespace GPU_DB_Benchmark.Benchmark
{
    [MarkdownExporter, HtmlExporter]
    public class Query4Benchmark
    {
        private readonly OmniSci _omniSci = new();
        private readonly string _queryString1;
        
        public Query4Benchmark()
        {
            _queryString1 = _omniSci.ReadQueryString("4");
        }
        
        [Benchmark]
        public void OmniSci4() => _omniSci.ExecuteQuery(_queryString1);
    }
}