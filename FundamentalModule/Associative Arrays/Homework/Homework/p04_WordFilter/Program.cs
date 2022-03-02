using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04_WordFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(' ');

            var filteredWords = words.Where(x => x.Length % 2 == 0);

            Console.WriteLine(string.Join("\n", filteredWords));
        }
    }
}
