using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment
{
    public class ProductCalculator : Calculator<Product>
    {

        private ProductCalculator()
        {
        }

        public ProductCalculator(IEnumerable<RuleAction<Product>> ruleActions)
        {
            _ruleActions = ruleActions;
        }
    }
}
