using Assessment;
using NUnit.Framework;

namespace AssessmentUnitTests
{
    public class TaxCalculatorUnitTests
    {
        private TaxCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new TaxCalculator(.10m, .05m);
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