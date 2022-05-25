using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p05_CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> charsTimesMet = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (charsTimesMet.ContainsKey(text[i]))
                {
                    charsTimesMet[text[i]]++;
                }
                else
                {
                    charsTimesMet.Add(text[i], 1);
                }
            }

            foreach (var charTimesMetPair in charsTimesMet)
            {
                Console.WriteLine($"{charTimesMetPair.Key}: {charTimesMetPair.Value} time/s");
            }
        }
    }
}
