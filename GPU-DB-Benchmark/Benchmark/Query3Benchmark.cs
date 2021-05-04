using BenchmarkDotNet.Attributes;

namespace GPU_DB_Benchmark.Benchmark
{
    [MarkdownExporter, HtmlExporter]
    public class Query3Benchmark
    {
        private readonly OmniSci _omniSci = new();
        private readonly string _queryString1;
        private readonly Blazing _blazing = new();
        
        public Query3Benchmark()
        {
            _queryString1 = _omniSci.ReadQueryString("3");
        }
        
        [IterationSetup]
        public void ClearMemory() => _omniSci.ClearMemory();
        
        [Benchmark(Baseline = true)]
        public void OmniSci3() => _omniSci.ExecuteQuery(_queryString1);
        
        [Benchmark]
        public void Blazing3() => _blazing.ExecuteQuery("3");
    }
}