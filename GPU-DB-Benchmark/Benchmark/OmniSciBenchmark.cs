using BenchmarkDotNet.Attributes;

namespace GPU_DB_Benchmark.Benchmark
{
    public class OmniSciBenchmark
    {
        private readonly OmniSci _omniSci = new();
        
        [Benchmark]
        public void OmniSci1() => _omniSci.ExecuteQuery1();
        
        [Benchmark]
        public void OmniSci2() => _omniSci.ExecuteQuery2();
        
        [Benchmark]
        public void OmniSci3() => _omniSci.ExecuteQuery3();
        
        [Benchmark]
        public void OmniSci4() => _omniSci.ExecuteQuery4();
        
        [Benchmark]
        public void OmniSci5() => _omniSci.ExecuteQuery5();
    }
}