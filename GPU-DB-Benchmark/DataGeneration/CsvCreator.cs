using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using GPU_DB_Benchmark.Models;

namespace GPU_DB_Benchmark.DataGeneration
{
    public class CsvCreator
    {
        public static void WriteCsv(string path)
        {
            var companies = DataGenerator.GenerateData(1000);
            var addresses = new List<Address>();
            companies.ForEach(c => addresses.Add(c.Address));
            var departments = new List<Department>();
            companies.ForEach(c => departments.AddRange(c.Departments));
            var categories = new List<Category>();
            departments.ForEach(d => categories.AddRange(d.Categories));
            var products = new List<Product>();
            categories.ForEach(c => products.AddRange(c.Products));
            var reviews = new List<Review>();
            products.ForEach(p => reviews.AddRange(p.Reviews));

            using var writer = new StreamWriter("Companies.csv");
            {
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                //csv.Context.RegisterClassMap<CsvCompanyMap>();
                csv.WriteRecords(companies);
            }
            
            using var writer2 = new StreamWriter(Path.Combine("Addresses.csv"));
            {
                using var csv = new CsvWriter(writer2, CultureInfo.InvariantCulture);
                csv.WriteRecords(addresses);
            }
            
            using var writer3 = new StreamWriter(Path.Combine("Departments.csv"));
            {
                using var csv = new CsvWriter(writer3, CultureInfo.InvariantCulture);
                csv.WriteRecords(departments);
            }
            
            using var writer4 = new StreamWriter(Path.Combine("Categories.csv"));
            {
                using var csv = new CsvWriter(writer4, CultureInfo.InvariantCulture);
                csv.WriteRecords(categories);
            }
            
            using var writer5 = new StreamWriter(Path.Combine("Products.csv"));
            {
                using var csv = new CsvWriter(writer5, CultureInfo.InvariantCulture);
                csv.WriteRecords(products);
            }
            
            using var writer6 = new StreamWriter(Path.Combine("Reviews.csv"));
            {
                using var csv = new CsvWriter(writer6, CultureInfo.InvariantCulture);
                csv.WriteRecords(reviews);
            }
        }
    }
}