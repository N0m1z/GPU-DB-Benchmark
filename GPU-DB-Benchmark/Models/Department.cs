using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPU_DB_Benchmark.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
        public int CompanyId { get; set; }
    }
}