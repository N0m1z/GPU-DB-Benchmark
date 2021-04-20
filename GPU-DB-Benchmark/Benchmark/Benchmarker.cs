using BenchmarkDotNet.Attributes;

namespace GPU_DB_Benchmark.Benchmark
{
    public class Benchmarker
    {
        private OmniSci _omniSci = new();
        private Blazing _blazing = new();
        private Kinetica _kinetica = new();
        
        
        [Benchmark]
        public void OmniSci() => _omniSci.ExecuteQueries();
        
        // [Benchmark]
        // public void Blazing() => _blazing.ExecuteQueries();
        //
        // [Benchmark]
        // public void Kinetica() => _kinetica.ExecuteQueries();
    }
}