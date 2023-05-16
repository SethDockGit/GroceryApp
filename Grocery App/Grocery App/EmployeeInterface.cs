using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery_App
{
    internal class EmployeeInterface
    {
        public List<Product> Products { get; set; }

        public EmployeeInterface(List<Product> products)
        {
            Products = products;

            WelcomeEmployee();
        }
        private void WelcomeEmployee()
        {
            bool exit = false;

            while(!exit)
            {
                Console.Clear();

                Console.WriteLine("Welcome to the employee portal. Which data would you like to access?\n\n(Write the number of your selection or exit, then press the enter key.)\n\n");

                Console.WriteLine("1. Produce items\n2. Deli items\n3. Non-Perishable items\n4. Specialty items\n5. Out-of-Stock items\n6. Items over $5\n7. Most Expensive item\n" +
                "8. Most expensive to least expensive items\n9. Least expensive to most expensive items by category\n10. Name and ID of out of stock items\n" +
                "11. Out of stock items by category\n12. Most expensive items by category\nExit - Return to main menu");

                string input = Console.ReadLine();

                if(input.ToLower() == "exit")
                {
                    exit = true;
                    Console.Clear();
                }
                else
                {
                    showDataOptions(input);
                }
            }
        }
        private void showDataOptions(string input)
        {
            switch(input)
            {
                case "1":
                    Console.Clear();
                    PrintProduce();
                    Console.WriteLine("\n\nPress any key to return...");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Clear();
                    PrintDeli();
                    Console.WriteLine("\n\nPress any key to return...");
                    Console.ReadKey();
                    break;

                case "3":
                    Console.Clear();
                    PrintNonPerishable();
                    Console.WriteLine("\n\nPress any key to return...");
                    Console.ReadKey();
                    break;

                case "4":
                    Console.Clear();
                    PrintSpecialty();
                    Console.WriteLine("\n\nPress any key to return...");
                    Console.ReadKey();
                    break;

                case "5":
                    Console.Clear();
                    PrintOutOfStock();
                    Console.WriteLine("\n\nPress any key to return...");
                    Console.ReadKey();
                    break;

                case "6":
                    Console.Clear();
                    PrintOverFive();
                    Console.WriteLine("\n\nPress any key to return...");
                    Console.ReadKey();
                    break;

                case "7":
                    Console.Clear();
                    PrintMostExpensive();
                    Console.WriteLine("\n\nPress any key to return...");
                    Console.ReadKey();
                    break;

                case "8":
                    Console.Clear();
                    PrintMostToLeast();
                    Console.WriteLine("\n\nPress any key to return...");
                    Console.ReadKey();
                    break;

                case "9":
                    Console.Clear();
                    PrintLeastToMostByCat();
                    Console.WriteLine("\n\nPress any key to return...");
                    Console.ReadKey();
                    break;

                case "10":
                    Console.Clear();
                    PrintNameIDOOS();
                    Console.WriteLine("\n\nPress any key to return...");
                    Console.ReadKey();
                    break;

                case "11":
                    Console.Clear();
                    PrintOOSByCat();
                    Console.WriteLine("\n\nPress any key to return...");
                    Console.ReadKey();
                    break;

                case "12":
                    Console.Clear();
                    PrintMostExpensiveByCat();
                    Console.WriteLine("\n\nPress any key to return...");
                    Console.ReadKey();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Please make a valid selection. Press any key to return...");
                    Console.ReadKey();
                    break;
            }
        }

        private void PrintProduce()
        {
            List<Product> produceList = Products.Where(p => p.Category == Category.Produce).ToList();

            foreach(var p in produceList)
            {
                Console.WriteLine(p.Name);
            }
        }
        private void PrintDeli()
        {
            List<Product> deliList = Products.Where(p => p.Category == Category.Deli).ToList();

            foreach (var p in deliList)
            {
                Console.WriteLine(p.Name);
            }
        }
        private void PrintSpecialty()
        {
            List<Product> specialtyList = Products.Where(p => p.Category == Category.Specialty).ToList();

            foreach (var p in specialtyList)
            {
                Console.WriteLine(p.Name);
            }
        }
        private void PrintNonPerishable()
        {
            List<Product> nonPerishable = Products.Where(p => p.Category == Category.NonPerishable).ToList();

            foreach (var p in nonPerishable)
            {
                Console.WriteLine(p.Name);
            }
        }
        private void PrintOutOfStock()
        {
            List<Product> outOfStock = Products.Where(p => p.NumberInStock == 0).ToList();

            foreach (var p in outOfStock)
            {
                Console.WriteLine(p.Name);
            }
        }
        private List<Product> GetOutOfStock(List<Product> products)
        {
            List<Product> outOfStock = products.Where(p => p.NumberInStock == 0).ToList();

            return outOfStock;
        }
        private void PrintOverFive()
        {
            List<Product> overFive = Products.Where(p => p.Cost > 5.00M).ToList();

            foreach (var p in overFive)
            {
                Console.WriteLine(p.Name);
            }
        }
        private void PrintMostExpensive()
        {
            Product mostExp = Products.OrderByDescending(p => p.Cost).First();

            Console.WriteLine(mostExp.Name);
        }
        private void PrintMostToLeast()
        {
            List<Product> mostToLeast = Products.OrderByDescending(p => p.Cost).ToList();

            foreach (var p in mostToLeast)
            {
                Console.WriteLine(p.Name);
            }
        }
        private void PrintLeastToMostByCat()
        {
            List<Product> leastToMost = Products.OrderBy(p => p.Category).ThenBy(p => p.Cost).ToList();

            foreach (var p in leastToMost)
            {
                Console.WriteLine(p.Name);
            }
        }
        private void PrintNameIDOOS()
        {
            List<Product> outOfStock = GetOutOfStock(Products);

            var namesAndID = outOfStock.Select(product => new
            {
                Name = product.Name,
                ID = product.Id,
            }).ToList();

            Console.WriteLine("Out of Stock:\n");

            foreach (var v in namesAndID)
            {
                Console.WriteLine($"ID {v.ID} --- {v.Name}");
            }
        }
        private void PrintOOSByCat()
        {
            var groupedByCat = Products.GroupBy(p => p.Category);

            foreach (var cat in groupedByCat)
            {
                List<Product> OOS = GetOutOfStock(cat.ToList());
                int count = OOS.Count;

                Console.WriteLine($"Category: {cat.ToList()[0].Category} --- Out of stock items: {count}");
            }
        }
        private void PrintMostExpensiveByCat()
        {

            var groupedByCat = Products.GroupBy(p => p.Category);

            var mostExpByCat = groupedByCat.Select(cat => new
            {
                Category = cat.Key,
                MostExp = cat.OrderByDescending(c => c.Cost).First()
            });

            foreach (var c in mostExpByCat)
            {
                Console.WriteLine($"{c.Category}: {c.MostExp.Name} is the most expensive item");
            }
        }
    }
}
