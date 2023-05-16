using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Grocery_App
{
    public class Product
    {
        public int Id;
        public decimal Cost;
        public string Name;
        public int NumberInStock;
        public Category Category;
    }
}
