using BenchmarkDotNet.Attributes;

namespace GPU_DB_Benchmark.Benchmark
{
    [MarkdownExporter, HtmlExporter]
    public class Query2Benchmark
    {
        private readonly OmniSci _omniSci = new();
        private readonly string _queryString1;
        private readonly Blazing _blazing = new();

        public Query2Benchmark()
        {
            _queryString1 = _omniSci.ReadQueryString("2");
        }
        
        [IterationSetup]
        public void ClearMemory() => _omniSci.ClearMemory();
        
        [Benchmark]
        public void OmniSci2() => _omniSci.ExecuteQuery(_queryString1);
        
        [Benchmark]
        public void Blazing1() => _blazing.ExecuteQuery("2");
    }
}