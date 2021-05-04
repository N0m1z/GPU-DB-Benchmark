namespace GPU_DB_Benchmark.Benchmark
{
    public interface IQueryExecutor
    {
        public void ExecuteQuery(string queryString);
    }
}