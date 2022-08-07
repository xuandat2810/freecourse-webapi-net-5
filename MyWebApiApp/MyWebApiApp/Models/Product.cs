using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApp.Models
{
    public class ProductVM
    {
        public string NameProduct { get; set; }
        public double Amount { get; set; }
    }

    public class Product : ProductVM
    {
        public Guid IDProduct { get; set; }
    }
}
