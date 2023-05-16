using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery_App
{
    public class CustInterface
    {
        public List<Product> Products;

        public CustInterface(List<Product> products)
        {
            Products = products;

            WelcomeCust();
        }

        private void WelcomeCust()
        {
            Console.Clear();
            Console.WriteLine("Thank you for choosing DockMart. Here are our available products:");
            Console.WriteLine();

            foreach (Product product in Products)
            {
                bool isItOut = false;

                if(product.NumberInStock == 0)
                {
                    isItOut = true;
                }

                if (!isItOut)
                {
                    Console.WriteLine($"{product.Name} --- {product.Category} ---  ${product.Cost}");
                }
                else
                {
                    Console.WriteLine($"{product.Name} --- {product.Category} --- ${product.Cost}, (Out of Stock)");
                }
            }

            Console.WriteLine("\n\nPress any key to return to the main menu.");

            Console.ReadKey();

            Console.Clear();
        }    
    }
}
