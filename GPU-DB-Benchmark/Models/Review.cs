﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPU_DB_Benchmark.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string ReviewText { get; set; }
        public DateTime PublishDate { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
    }
}