using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03_CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());

            if (start > end)
            {
                char temp = start;
                start = end;
                end = temp;
            }

            char[] charactersInRange = GetCharactersInRange(start, end);

            foreach (var ch in charactersInRange)
            {
                Console.Write($"{ch} ");
            }
            Console.WriteLine();
        }

        static char[] GetCharactersInRange(char start, char end)
        {
            if ((int)end - (int)start - 1 <= 0)
            {
                return new char[0];    
            }

            char[] charactersInRange = new char[(int)end - (int)start - 1];

            for (int i = 0; i < end - start - 1; i++)
            {
                charactersInRange[i] = (char)(start + i + 1);
            }

            return charactersInRange;
        }
    }
}
