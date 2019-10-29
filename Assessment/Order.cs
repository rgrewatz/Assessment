using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment
{
    public class Order
    {
        private TaxCalculator _taxCalculator;
        private List<Product> _products;

        public Order(TaxCalculator taxCalculator, List<Product> products)
        {
            _taxCalculator = taxCalculator;
            _products = products ?? new List<Product>();
        }

        public decimal TotalTaxes
        {
            get
            {
                return _products.Sum(x => _taxCalculator.CalculateTax(x));
            }
        }

        public decimal PreTaxTotal
        {
            get
            {
                return _products.Sum(x => x.Price);
            }
        }

        public decimal Total
        {
            get
            {
                return PreTaxTotal + TotalTaxes;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            _products.ForEach(p => builder.AppendLine($"{p.Quantity} {p.Name}: {p.Price + _taxCalculator.CalculateTax(p):F2}"));
            builder.AppendLine($"Sales Taxes: {TotalTaxes:F2}");
            builder.AppendLine($"Total: {Total:F2}");
            return builder.ToString();
        }
    }
}
