using System.Collections.Generic;

namespace GPU_DB_Benchmark.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
    }
}