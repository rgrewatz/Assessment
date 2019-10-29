using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment
{
    public class TaxCalculator
    {
        private decimal _salesTaxPercentage;
        private decimal _dutyPercentage;
        public TaxCalculator(decimal salesTaxPercentage, decimal dutyPercentage)
        {
            _salesTaxPercentage = salesTaxPercentage;
            _dutyPercentage = dutyPercentage;
        }

        public decimal CalculateTax(Product product)
        {
            decimal tax = 0;

            if(!(product.Type == ProductType.Book || product.Type == ProductType.Food || product.Type == ProductType.Medical))
            {
                tax = product.Price * _salesTaxPercentage;
            }

            if (product.Imported)
            {
                tax += product.Price * _dutyPercentage; 
            }

            return Math.Ceiling(tax * 100 / 5) * 5 / 100;
        }
    }
}
