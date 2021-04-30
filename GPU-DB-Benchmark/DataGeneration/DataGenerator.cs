using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Bogus;
using Bogus.Extensions;
using CsvHelper;
using GPU_DB_Benchmark.Models;

namespace GPU_DB_Benchmark.DataGeneration
{
    public class DataGenerator
    {
        public static void GenerateData(int count)
        {
            Randomizer.Seed = new Random(101010);
            var random = new Random(101010);

            var reviewId = 1;
            var reviewFaker = new Faker<Review>()
                .RuleFor(x => x.Id, _ => reviewId++)
                .RuleFor(x => x.Author, x => x.Name.FullName())
                .RuleFor(x => x.ReviewText, x => x.Rant.Review())
                .RuleFor(x => x.PublishDate, x => x.Date.Past(10));

            var productId = 1;
            var productFaker = new Faker<Product>()
                .RuleFor(x => x.Id, _ => productId++)
                .RuleFor(x => x.Name, x => x.Commerce.Product())
                .RuleFor(x => x.Color, x => x.Commerce.Color())
                .RuleFor(x => x.Material, x => x.Commerce.ProductMaterial())
                .RuleFor(x => x.Ean13, x => x.Commerce.Ean13())
                .RuleFor(x => x.ReleaseDate, x => x.Date.Past(50))
                .RuleFor(x => x.Price, x => double.Parse(x.Commerce.Price()))
                .RuleFor(x => x.Reviews, (f, b) =>
                {
                    reviewFaker.RuleFor(x => x.ProductId, _ => b.Id);
                    return reviewFaker.GenerateBetween(0, 10);
                });

            var categoryId = 1;
            var categoryFaker = new Faker<Category>()
                .RuleFor(x => x.Id, _ => categoryId++)
                .RuleFor(x => x.Name, x => x.Commerce.Categories(10)[random.Next(0, 10)])
                .RuleFor(x => x.Products, (f, b) =>
                {
                    productFaker.RuleFor(x => x.CategoryId, _ => b.Id);
                    return productFaker.GenerateBetween(1, 100);
                });

            var departmentId = 1;
            var departmentFaker = new Faker<Department>()
                .RuleFor(x => x.Id, _ => departmentId++)
                .RuleFor(x => x.Name, x => x.Commerce.Department())
                .RuleFor(x => x.Categories, (f, b) =>
                {
                    categoryFaker.RuleFor(x => x.DepartmentId, _ => b.Id);
                    return categoryFaker.GenerateBetween(1, 10);
                });

            var addressId = 1;
            var addressFaker = new Faker<Address>()
                .RuleFor(x => x.Id, _ => addressId++)
                .RuleFor(x => x.Country, x => x.Address.Country())
                .RuleFor(x => x.CountryCode, x => x.Address.CountryCode())
                .RuleFor(x => x.ZipCode, x => x.Address.ZipCode())
                .RuleFor(x => x.City, x => x.Address.City())
                .RuleFor(x => x.StreetName, x => x.Address.StreetName())
                .RuleFor(x => x.BuildingNumber, x => x.Address.BuildingNumber())
                .RuleFor(x => x.SecondaryAddress, x => x.Address.SecondaryAddress());

            var companyId = 1;
            var companyFaker = new Faker<Company>()
                .RuleFor(x => x.Id, _ => companyId++)
                .RuleFor(x => x.Name, x => x.Company.CompanyName())
                .RuleFor(x => x.Address, (f, b) =>
                {
                    addressFaker.RuleFor(x => x.CompanyId, _ => b.Id);
                    return addressFaker.Generate();
                })
                .RuleFor(x => x.Email, x => x.Internet.Email())
                .RuleFor(x => x.Website, x => x.Internet.DomainName())
                .RuleFor(x => x.FoundingDate, x => x.Date.Past(100))
                .RuleFor(x => x.PhoneNumber, x => x.Phone.PhoneNumber())
                .RuleFor(x => x.Departments, (f, b) =>
                {
                    departmentFaker.RuleFor(x => x.CompanyId, _ => b.Id);
                    return departmentFaker.GenerateBetween(1, 5);
                });
            
            var companies = companyFaker.GenerateForever();
            using (var writer = new StreamWriter("Companies.csv"))
            using (var writer2 = new StreamWriter("Addresses.csv"))
            using (var writer3 = new StreamWriter("Departments.csv"))
            using (var writer4 = new StreamWriter("Categories.csv"))
            using (var writer5 = new StreamWriter("Products.csv"))
            using (var writer6 = new StreamWriter("Reviews.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            using (var csv2 = new CsvWriter(writer2, CultureInfo.InvariantCulture))
            using (var csv3 = new CsvWriter(writer3, CultureInfo.InvariantCulture))
            using (var csv4 = new CsvWriter(writer4, CultureInfo.InvariantCulture))
            using (var csv5 = new CsvWriter(writer5, CultureInfo.InvariantCulture))
            using (var csv6 = new CsvWriter(writer6, CultureInfo.InvariantCulture))
            {
                csv.WriteHeader<Company>();
                csv.NextRecord();
                csv2.WriteHeader<Address>();
                csv2.NextRecord();
                
                foreach (var company in companies)
                {
                    var categories = new List<Category>();
                    company.Departments.ForEach(d => categories.AddRange(d.Categories));
                    var products = new List<Product>();
                    categories.ForEach(c => products.AddRange(c.Products));
                    var reviews = new List<Review>();
                    products.ForEach(p => reviews.AddRange(p.Reviews));

                    csv.WriteRecord(company);
                    csv.NextRecord();
                    csv2.WriteRecord(company.Address);
                    csv2.NextRecord();
                    csv3.WriteRecords(company.Departments);
                    csv4.WriteRecords(categories);
                    csv5.WriteRecords(products);
                    csv6.WriteRecords(reviews);

                    if (company.Id == count)
                    {
                        break;
                    }
                }
            }
        }
    }
}