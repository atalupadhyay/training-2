using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komsky.Domain.Models;
using Komsky.Services.Handlers;

namespace Komsky.Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductHandler productHandler = new ProductHandler();
            var allProducts = productHandler.GetAll();
            foreach (var productDomain in allProducts)
            {
                Display(productDomain);
            }
        }

        private static void Display(ProductDomain productDomain)
        {
            Console.Write("Product name: {0}", productDomain.Name);
            Display(productDomain.Customer);
            Console.WriteLine(";");
        }

        private static void Display(CustomerDomain customerDomain)
        {
            Console.Write("Product name: {0}", customerDomain.Name);

        }
    }
}
