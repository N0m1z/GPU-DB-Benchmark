﻿using BenchmarkDotNet.Attributes;

namespace GPU_DB_Benchmark.Benchmark
{
    [MarkdownExporter, HtmlExporter]
    public class Query1Benchmark
    {
        private readonly OmniSci _omniSci = new();
        private readonly string _queryString1;
        private readonly Blazing _blazing = new();
        
        public Query1Benchmark()
        {
            _queryString1 = _omniSci.ReadQueryString("1");
        }

        [IterationSetup]
        public void ClearMemory() => _omniSci.ClearMemory();
        
        [Benchmark]
        public void OmniSci1() => _omniSci.ExecuteQuery(_queryString1);
        
        [Benchmark]
        public void Blazing1() => _blazing.ExecuteQuery("1");
    }
}