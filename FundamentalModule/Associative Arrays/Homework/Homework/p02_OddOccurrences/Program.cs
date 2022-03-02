using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02_OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string loweredWord = word.ToLower();

                if (wordCount.ContainsKey(loweredWord))
                {
                    wordCount[loweredWord]++;
                }
                else
                {
                    wordCount.Add(loweredWord, 1);
                }
            }

            List<string> oddOccurrences = wordCount.Where(x => x.Value % 2 != 0).Select(x => x.Key).ToList();

            Console.WriteLine(string.Join(" ", oddOccurrences));
        }
    }
}
