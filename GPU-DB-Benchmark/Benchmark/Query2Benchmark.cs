using BenchmarkDotNet.Attributes;

namespace GPU_DB_Benchmark.Benchmark
{
    [MarkdownExporter, HtmlExporter]
    public class Query2Benchmark
    {
        private readonly OmniSci _omniSci = new();
        private readonly string _queryString1;
        
        public Query2Benchmark()
        {
            _queryString1 = _omniSci.ReadQueryString("2");
        }
        
        [Benchmark]
        public void OmniSci2() => _omniSci.ExecuteQuery(_queryString1);
    }
}