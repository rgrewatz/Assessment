using Assessment;
using NUnit.Framework;
using System.Collections.Generic;

namespace AssessmentUnitTests
{
    public class TaxCalculatorUnitTests
    {
        private TaxCalculator<Product> _calculator;

        [SetUp]
        public void Setup()
        {
            var taxActions = new List<TaxAction<Product>>
            {
                new TaxAction<Product>((p) => p.Type == ProductType.Other, (p) => p.Price * .1m),
                new TaxAction<Product>((p) => p.Imported, (p) => p.Price * .05m)
            };
            _calculator = new TaxCalculator<Product>(taxActions);
        }

        [Test]
        public void CalculateTax_UnTaxedItem_ReturnsZeroTax()
        {
            var p = new Product
            {
                Type = ProductType.Book,
                Price = 12.49m
            };

            Assert.AreEqual(0, _calculator.CalculateTax(p));
        }

        [Test]
        public void CalculateTax_DomesticTaxedItem_ReturnsDomesticTax()
        {
            var p = new Product
            {
                Price = 14.99m,
                Type = ProductType.Other
            };

            Assert.AreEqual(16.49m, p.Price + _calculator.CalculateTax(p));
        }

        [Test]
        public void CalculateTax_ImportedUntaxedItem_ReturnsDutyTax()
        {
            var p = new Product
            {
                Price = 11.25m,
                Type = ProductType.Food,
                Imported = true
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
                Imported = true
            };

            Assert.AreEqual(32.19m, p.Price + _calculator.CalculateTax(p));
        }
    }
}