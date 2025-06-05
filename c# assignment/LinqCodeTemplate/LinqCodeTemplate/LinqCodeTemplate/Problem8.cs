using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Problem8
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            var result = products.GroupBy(p => p.ProMrp).ToList();
            foreach (var mrp in result)
            {
                Console.WriteLine($"Category:{mrp.Key}");
                foreach (var item in mrp)
                {
                    Console.WriteLine($"{item.ProName}");
                }
            }
        }
    }
}
