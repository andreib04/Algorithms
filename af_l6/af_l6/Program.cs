using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace af_l6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Complex z1, z2, c, d, e;
            z1 = new Complex();
            z2 = new Complex();
            
            z1.Read();
            z2.Read();

            c = z1 + z2;
            d = z1 * z2;
            e = z1 / z2;
            Console.WriteLine(z1.ToString());
            Console.WriteLine(z2.ToString());
            Console.WriteLine();
            Console.WriteLine(c.ToString());
            Console.WriteLine(d.ToString());
            Console.WriteLine(e.ToString());

        }
    }
}
