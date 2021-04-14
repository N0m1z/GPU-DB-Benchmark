using System.Collections.Generic;
using System.Linq;
using GPU_DB_Benchmark.DataGeneration;
using GPU_DB_Benchmark.Models;
using Microsoft.EntityFrameworkCore;

namespace GPU_DB_Benchmark.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=blogging.db");
            options.EnableSensitiveDataLogging();
        }
    }
}