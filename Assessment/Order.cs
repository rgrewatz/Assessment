using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment
{
    public class Order<T> where T : Financial
    {
        private Calculator<T> _calculator;
        private List<T> _financials;

        public Order(Calculator<T> calculator, List<T> financals)
        {
            _calculator = calculator;
            _financials = financals ?? new List<T>();
        }

        public decimal TotalTaxes
        {
            get
            {
                return _financials.Sum(x => _calculator.Calculate(x));
            }
        }

        public decimal SubTotal
        {
            get
            {
                return _financials.Sum(x => x.Price);
            }
        }

        public decimal Total
        {
            get
            {
                return SubTotal + TotalTaxes;
            }
        }
    }
}
