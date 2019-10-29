using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment
{
    public class Product : Financial
    {
        public string Name { get; set; }
        public bool Imported { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ProductType Type { get; set; }
    }
}
