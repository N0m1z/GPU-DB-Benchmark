using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Bogus.Extensions;
using GPU_DB_Benchmark.Models;

namespace GPU_DB_Benchmark.DataGeneration
{
    public class DataGenerator
    {
        public static List<Company> GenerateData(int count)
        {
            Randomizer.Seed = new Random(101010);
            var random = new Random(101010);

            var reviewId = 1;
            var reviewFaker = new Faker<Review>()
                .RuleFor(x => x.Id, _ => reviewId++)
                .RuleFor(x => x.Author, x => x.Name.FullName())
                .RuleFor(x => x.ReviewText, x => x.Rant.Review())
                .RuleFor(x => x.PublishDate, x => x.Date.Past());

            var productId = 1;
            var productFaker = new Faker<Product>()
                .RuleFor(x => x.Id, _ => productId++)
                .RuleFor(x => x.Name, x => x.Commerce.Product())
                .RuleFor(x => x.Color, x => x.Commerce.Color())
                .RuleFor(x => x.Material, x => x.Commerce.ProductMaterial())
                .RuleFor(x => x.Ean13, x => x.Commerce.Ean13())
                .RuleFor(x => x.ReleaseDate, x => x.Date.Past())
                .RuleFor(x => x.Price, x => x.Commerce.Price())
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
                .RuleFor(x => x.FoundingDate, x => x.Date.Past())
                .RuleFor(x => x.PhoneNumber, x => x.Phone.PhoneNumber())
                .RuleFor(x => x.Departments, (f, b) =>
                {
                    departmentFaker.RuleFor(x => x.CompanyId, _ => b.Id);
                    return departmentFaker.GenerateBetween(1, 5);
                });

            return companyFaker.Generate(count);
        }
    }
}