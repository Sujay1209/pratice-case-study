using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Problem13
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            var min = products.Min(p => p.ProMrp);
            Console.WriteLine(min);
        }
    }
}
