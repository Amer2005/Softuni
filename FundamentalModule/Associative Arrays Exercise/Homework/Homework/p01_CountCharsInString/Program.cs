using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01_CountCharsInString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> counts = new Dictionary<char, int>();

            text = text.Replace(" ", "");

            for (int i = 0; i < text.Length; i++)
            {
                if (counts.ContainsKey(text[i]))
                {
                    counts[text[i]]++;
                }
                else
                {
                    counts.Add(text[i], 1);
                }
            }

            foreach (var item in counts)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
