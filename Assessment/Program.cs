using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new TaxCalculator(.10m, .05m);
            var products = new List<Product> {
                new Product { Name = "Book", Type = ProductType.Book, Price = 12.49m, Quantity = 1, Imported = false },
                new Product { Name = "Music CD", Type = ProductType.Other, Price = 14.99m, Quantity = 1, Imported = false },
                new Product { Name = "Chocolate Bar", Type = ProductType.Food, Price = .85m, Quantity = 1, Imported = false }
            };

            products.ForEach(p => Console.WriteLine($"{p.Quantity} {p.Name}: {p.Price + calculator.CalculateTax(p)}"));
            Console.WriteLine($"Sales Taxes: {products.Sum(p => calculator.CalculateTax(p))}");
            Console.WriteLine($"Total: {products.Sum(p => p.Price + calculator.CalculateTax(p))}");

            products = new List<Product>{
                new Product { Name = "Box Of Chocolates", Type = ProductType.Food, Price = 10m, Quantity = 1, Imported = true },
                new Product { Name = "Bottle Of Perfume", Type = ProductType.Other, Price = 47.50m, Quantity = 1, Imported = true }
            };

            products.ForEach(p => Console.WriteLine($"{p.Quantity} {p.Name}: {p.Price + calculator.CalculateTax(p)}"));
            Console.WriteLine($"Sales Taxes: {products.Sum(p => calculator.CalculateTax(p))}");
            Console.WriteLine($"Total: {products.Sum(p => p.Price + calculator.CalculateTax(p))}");

            products = new List<Product> {
                new Product { Name = "Bottle Of Perfume", Type = ProductType.Other, Price = 27.99m, Quantity = 1, Imported = true },
                new Product { Name = "Bottle Of Perfume", Type = ProductType.Other, Price = 18.99m, Quantity = 1, Imported = false },
                new Product { Name = "Headache Pills", Type = ProductType.Medical, Price = 9.75m, Quantity = 1, Imported = false },
                new Product { Name = "Box Of Chocolates", Type = ProductType.Food, Price = 11.25m, Quantity = 1, Imported = true }
            };

            products.ForEach(p => Console.WriteLine($"{p.Quantity} {p.Name}: {p.Price + calculator.CalculateTax(p)}"));
            Console.WriteLine($"Sales Taxes: {products.Sum(p => calculator.CalculateTax(p))}");
            Console.WriteLine($"Total: {products.Sum(p => p.Price + calculator.CalculateTax(p))}");
        }
    }
}
