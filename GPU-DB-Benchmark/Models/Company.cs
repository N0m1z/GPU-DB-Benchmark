using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration.Attributes;

namespace GPU_DB_Benchmark.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        [Ignore]
        public Address Address { get; set; }
        public DateTime FoundingDate { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string PhoneNumber { get; set; }
        [NotMapped]
        public List<Department> Departments { get; set; }
    }
}