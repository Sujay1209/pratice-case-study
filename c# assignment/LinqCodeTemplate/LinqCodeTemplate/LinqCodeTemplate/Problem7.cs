using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Problem7
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            var result = products.GroupBy(p => p.ProCategory).ToList();
            foreach(var cat in result)
            {
                Console.WriteLine($"Category:{cat.Key}");
                foreach(var item in cat)
                {
                    Console.WriteLine($"{item.ProName}");
                }
            }
        }
    }
}
