namespace GPU_DB_Benchmark.Benchmark
{
    public interface IQueryExecutor
    {
        public string ReadQueryString(string queryNumber);
        public void ExecuteQuery(string queryString);
    }
}