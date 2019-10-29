using System;

namespace Assessment
{
    public class TaxRule
    {
        private Func<Product, bool> _ruleExpression;
        private decimal _percentageTax;
        public TaxRule(Func<Product, bool> ruleExpression, decimal percentageTax)
        {
            _ruleExpression = ruleExpression;
            _percentageTax = percentageTax;
        }

        private bool IsTrue(Product product)
        {
            return _ruleExpression?.Invoke(product) ?? false;
        }

        public decimal GetPercentageTax(Product product)
        {
            return IsTrue(product) ? _percentageTax : 0;
        }
    }
}
