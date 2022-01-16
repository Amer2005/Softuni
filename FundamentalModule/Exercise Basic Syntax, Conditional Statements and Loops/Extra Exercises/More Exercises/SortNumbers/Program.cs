using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            if (a < b)
            {
                Swap(ref a, ref b);
            }

            if (a < c)
            {
                Swap(ref a, ref c);
            }

            if (b < c)
            {
                Swap(ref c, ref b);
            }

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
