using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p06_MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            Console.WriteLine(GetMiddleCharacters(word));
        }

        static string GetMiddleCharacters(string word)
        {
            return word.Substring(word.Length / 2 + word.Length % 2 - 1, 2 - word.Length % 2);
        }
    }
}
