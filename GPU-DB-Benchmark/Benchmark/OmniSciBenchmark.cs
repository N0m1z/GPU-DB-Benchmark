using BenchmarkDotNet.Attributes;

namespace GPU_DB_Benchmark.Benchmark
{
    [MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvExporter]
    public class OmniSciBenchmark
    {
        private readonly OmniSci _omniSci = new();
        private readonly string _queryString1;
        private readonly string _queryString2;
        private readonly string _queryString3;
        private readonly string _queryString5;
        private readonly string _queryString4;

        public OmniSciBenchmark()
        {
            _queryString1 = _omniSci.ReadQueryString("1");
            _queryString2 = _omniSci.ReadQueryString("2");
            _queryString3 = _omniSci.ReadQueryString("3");
            _queryString4 = _omniSci.ReadQueryString("4");
            _queryString5 = _omniSci.ReadQueryString("5");
        }
        
        [Benchmark]
        public void OmniSci1() => _omniSci.ExecuteQuery(_queryString1);
        
        [Benchmark]
        public void OmniSci2() => _omniSci.ExecuteQuery(_queryString2);
        
        [Benchmark]
        public void OmniSci3() => _omniSci.ExecuteQuery(_queryString3);
        
        [Benchmark]
        public void OmniSci4() => _omniSci.ExecuteQuery(_queryString4);
        
        [Benchmark]
        public void OmniSci5() => _omniSci.ExecuteQuery(_queryString5);
    }
}