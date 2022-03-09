using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p05_DigitsLettersAndOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] symbols = Console.ReadLine().ToCharArray();

            char[] digits = symbols.Where(x => char.IsDigit(x)).ToArray();
            char[] letters = symbols.Where(x => char.IsLetter(x)).ToArray();
            char[] other = symbols.Where(x => !char.IsDigit(x) && !char.IsLetter(x)).ToArray();

            Console.WriteLine(new string(digits));
            Console.WriteLine(new string(letters));
            Console.WriteLine(new string(other));
        }
    }
}
