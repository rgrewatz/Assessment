using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment
{
    public class TaxCalculator<T>
    {
        private IEnumerable<TaxAction<T>> _taxActions;
        public TaxCalculator(IEnumerable<TaxAction<T>> taxActions)
        {
            _taxActions = taxActions;
        }

        public decimal CalculateTax(T t)
        {
            decimal tax = 0;
            foreach (var action in _taxActions)
            {
                tax += action.Apply(t);
            }
            return Math.Ceiling(tax * 100 / 5) * 5 / 100;
            /*

            if(_taxedTypes.Any(x => x == product.Type))
            {
                tax = product.Price * _salesTaxPercentage;
            }

            if (product.Imported)
            {
                tax += product.Price * _dutyPercentage; 
            }

            
            */
        }
    }
}
