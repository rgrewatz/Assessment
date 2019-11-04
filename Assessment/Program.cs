using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator<Product>(
                new List<RuleAction<Product>>
                {
                    new RuleAction<Product>((p) => p.Type == ProductType.Other, (p) => p.Price * 0.1m * p.Quantity),
                    new RuleAction<Product>((p) => p.Imported, (p) => p.Price * 0.05m * p.Quantity)
                });


            var products = new List<Product> {
                new Product { Name = "Book", Type = ProductType.Book, Price = 12.49m, Quantity = 1, Imported = false },
                new Product { Name = "Music CD", Type = ProductType.Other, Price = 14.99m, Quantity = 1, Imported = false },
                new Product { Name = "Chocolate Bar", Type = ProductType.Food, Price = .85m, Quantity = 1, Imported = false }
            };
            var order = new Order<Product>(calculator, products);

            var builder = new StringBuilder();
            products.ForEach(p => builder.AppendLine($"{p.Quantity} {(p.Imported ? "Imported " : null)}{p.Name}: {p.Price + calculator.Calculate(p):F2}"));
            builder.AppendLine($"Subtotal: {order.SubTotal:F2}");
            builder.AppendLine($"Sales Taxes: {order.TotalTaxes:F2}");
            builder.AppendLine($"Total: {order.Total:F2}");
            Console.WriteLine(builder);

            products = new List<Product>{
                new Product { Name = "Box Of Chocolates", Type = ProductType.Food, Price = 10m, Quantity = 1, Imported = true },
                new Product { Name = "Bottle Of Perfume", Type = ProductType.Other, Price = 47.50m, Quantity = 1, Imported = true }
            };
            order = new Order<Product>(calculator, products);

            builder = new StringBuilder();
            products.ForEach(p => builder.AppendLine($"{p.Quantity} {(p.Imported ? "Imported " : null)}{p.Name}: {p.Price + calculator.Calculate(p):F2}"));
            builder.AppendLine($"Subtotal: {order.SubTotal:F2}");
            builder.AppendLine($"Sales Taxes: {order.TotalTaxes:F2}");
            builder.AppendLine($"Total: {order.Total:F2}");
            Console.WriteLine(builder);

            products = new List<Product> {
                new Product { Name = "Bottle Of Perfume", Type = ProductType.Other, Price = 27.99m, Quantity = 1, Imported = true },
                new Product { Name = "Bottle Of Perfume", Type = ProductType.Other, Price = 18.99m, Quantity = 1, Imported = false },
                new Product { Name = "Packet Of Headache Pills", Type = ProductType.Medical, Price = 9.75m, Quantity = 1, Imported = false },
                new Product { Name = "Box Of Chocolates", Type = ProductType.Food, Price = 11.25m, Quantity = 1, Imported = true }
            };
            order = new Order<Product>(calculator, products);

            builder = new StringBuilder();
            products.ForEach(p => builder.AppendLine($"{p.Quantity} {(p.Imported ? "Imported " : null)}{p.Name}: {p.Price + calculator.Calculate(p):F2}"));
            builder.AppendLine($"Subtotal: {order.SubTotal:F2}");
            builder.AppendLine($"Sales Taxes: {order.TotalTaxes:F2}");
            builder.AppendLine($"Total: {order.Total:F2}");
            Console.WriteLine(builder);
        }
    }
}
