using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03_WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfWords = int.Parse(Console.ReadLine());

            var dictionary = new Dictionary<string, List<string>>();

            for (int i = 0; i < numberOfWords; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (dictionary.ContainsKey(word))
                {
                    dictionary[word].Add(synonym);
                }
                else
                {
                    dictionary[word] = new List<string> { synonym };
                }
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        }
    }
}
