using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Problem14
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            bool allBelow30 = products.All(p => p.ProMrp < 30);
            Console.WriteLine($"Are all products below Rs.30? {allBelow30}");
        }
    }
}
