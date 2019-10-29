using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment
{
    public class TaxCalculator
    {
        private IEnumerable<TaxRule> _taxActions;

        public TaxCalculator()
        {
            _taxActions = new List<TaxRule>
            {
                new TaxRule((p) => p.Type == ProductType.Other, .1m),
                new TaxRule((p) => p.Imported, .05m)
            };
        }

        public TaxCalculator(IEnumerable<TaxRule> taxActions)
        {
            _taxActions = taxActions;
        }

        public decimal CalculateTax(Product product)
        {
            decimal tax = 0;

            foreach (var taxAction in _taxActions)
            {
                tax += product.Price * taxAction.GetPercentageTax(product) * product.Quantity;
            }

            return Math.Ceiling(tax * 20) / 20;
        }
    }
}
