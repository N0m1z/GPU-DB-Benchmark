using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPU_DB_Benchmark.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public List<Product> Products { get; set; }
        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
    }
}