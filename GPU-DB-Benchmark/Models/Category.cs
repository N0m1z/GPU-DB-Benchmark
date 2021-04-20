﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPU_DB_Benchmark.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public int DepartmentId { get; set; }
    }
}