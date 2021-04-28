using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPU_DB_Benchmark.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public string Ean13 { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Price { get; set; }
        public List<Review> Reviews { get; set; }
        public int CategoryId { get; set; }
    }
}