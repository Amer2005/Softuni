using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02_VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            Console.WriteLine(GetVowelCount(word));
        }

        static int GetVowelCount(string word)
        {
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u'};

            int vowelCount = 0;

            foreach (var ch in word)
            {
                if(vowels.Contains(Char.ToLower(ch)))
                {
                    vowelCount++;
                }
            }

            return vowelCount;
        }
    }
}
