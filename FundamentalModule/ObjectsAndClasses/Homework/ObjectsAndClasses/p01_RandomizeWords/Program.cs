using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01_RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');

            Random random = new Random();

            for (int i = 0; i < words.Length - 1; i++)
            {
                int randomIndex = random.Next(0, words.Length);

                swapWords(words, i, randomIndex);
            }

            Console.WriteLine(String.Join("\n", words));
        }

        static void swapWords(string[] words, int firstIndex, int secondIndex)
        {
            string temp = words[firstIndex];

            words[firstIndex] = words[secondIndex];
            words[secondIndex] = temp;
        }
    }
}
