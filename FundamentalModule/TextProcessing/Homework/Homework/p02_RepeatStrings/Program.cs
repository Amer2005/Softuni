using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02_RepeatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] allWords = Console.ReadLine().Split(' ');

            foreach (string word in allWords)
            {
                Console.Write(String.Join("", word.ToCharArray().ToList().Select(x => word)));
            }
            Console.WriteLine();
        }
    }
}
