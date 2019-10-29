using Assessment;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AssessmentUnitTests
{
    public class TaxCalculatorUnitTests
    {
        private TaxCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new TaxCalculator();
        }

        [Test]
        public void CalculateTax_UnTaxedItem_ReturnsZeroTax()
        {
            var p = new Product
            {
                Type = ProductType.Book,
                Price = 12.49m,
                Quantity = 1
            };

            Assert.AreEqual(12.49, p.Price + _calculator.CalculateTax(p));
        }

        [Test]
        public void CalculateTax_DomesticTaxedItem_ReturnsDomesticTax()
        {
            var p = new Product
            {
                Price = 14.99m,
                Type = ProductType.Other,
                Quantity = 1
            };

            Assert.AreEqual(1.50m, _calculator.CalculateTax(p));
        }

        [Test]
        public void CalculateTax_DomesticTaxedItemWithMultipleQuantity_ReturnsDomesticTax()
        {
            var p = new Product
            {
                Price = 14.99m,
                Type = ProductType.Other,
                Quantity = 55
            };

            Assert.AreEqual(82.45, _calculator.CalculateTax(p));
        }

        [Test]
        public void CalculateTax_ImportedUntaxedItem_ReturnsDutyTax()
        {
            var p = new Product
            {
                Price = 11.25m,
                Type = ProductType.Food,
                Imported = true,
                Quantity = 1
            };

            Assert.AreEqual(11.85m, p.Price + _calculator.CalculateTax(p));
        }

        [Test]
        public void CalculateTax_ImportedTaxedItem_ReturnsDutyAndSalesTax()
        {
            var p = new Product
            {
                Price = 27.99m,
                Type = ProductType.Other,
                Imported = true,
                Quantity = 1
            };

            Assert.AreEqual(32.19m, p.Price + _calculator.CalculateTax(p));
        }

        [Test]
        public void CalculateTax_MultipleItemsNoImport_CalculatesTotalTax()
        {
            var products = new List<Product> {
                new Product { Type = ProductType.Book, Price = 12.49m, Quantity = 1, Imported = false },
                new Product { Type = ProductType.Other, Price = 14.99m, Quantity = 1, Imported = false },
                new Product { Type = ProductType.Food, Price = .85m, Quantity = 1, Imported = false }
            };
            Assert.AreEqual(1.50m, products.Sum(x => _calculator.CalculateTax(x)));
        }

        [Test]
        public void CalculateTax_MultipleItemsWithImport_CalculatesTotalTax()
        {
            var products = new List<Product> {
                new Product { Type = ProductType.Other, Price = 27.99m, Quantity = 1, Imported = true },
                new Product { Type = ProductType.Other, Price = 18.99m, Quantity = 1, Imported = false },
                new Product { Type = ProductType.Medical, Price = 9.75m, Quantity = 1, Imported = false },
                new Product { Type = ProductType.Food, Price = 11.25m, Quantity = 1, Imported = true }
            };

            Assert.AreEqual(6.70, products.Sum(x => _calculator.CalculateTax(x)));
        }
    }
}