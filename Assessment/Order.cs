using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment
{
    public class Order<T> where T : Product
    {
        private TaxCalculator<T> _taxCalculator;
        private List<T> _products;
        private decimal? _totalTaxes;
        private decimal? _preTaxTotal;
        private bool _recalculateTax;
        private bool _recalculatePreTaxTotal;

        public Order(TaxCalculator<T> taxCalculator, List<T> products)
        {
            _taxCalculator = taxCalculator;
            _products = products ?? new List<T>();
        }

        public decimal TotalTaxes
        {
            get
            {
                if (!_totalTaxes.HasValue || _recalculateTax)
                {
                    _totalTaxes = _products.Sum(x => _taxCalculator.CalculateTax(x));
                }
                _recalculateTax = false;
                return _totalTaxes.Value;
            }
        }

        public decimal PreTaxTotal
        {
            get
            {
                if (!_preTaxTotal.HasValue || _recalculatePreTaxTotal)
                {
                    _preTaxTotal = _products.Sum(x => x.Price);
                }
                return _preTaxTotal.Value;
            }
        }

        public decimal Total
        {
            get
            {
                return PreTaxTotal + TotalTaxes;
            }
        }

        public void AddProduct(T t)
        {
            _products.Add(t);
            _recalculateTax = true;
            _recalculatePreTaxTotal = true;
        }

        public void RemoveProduct(T t)
        {
            _products.Remove(t);
            _recalculateTax = true;
            _recalculatePreTaxTotal = true;
        }

        public void PrintOrder()
        {
            _products.ForEach(p => Console.WriteLine($"{p.Quantity} {p.Name}: {p.Price + _taxCalculator.CalculateTax(p)}"));
            Console.WriteLine($"Sales Taxes: {TotalTaxes}");
            Console.WriteLine($"Total: {Total}");

        }
    }
}
