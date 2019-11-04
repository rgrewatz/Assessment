using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment
{
    public class Product : Financial
    {
        public ProductType Type { get; set; }
        public bool Imported { get; set; }
    }
}
