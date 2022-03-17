using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p06_ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder filteredText = new StringBuilder();

            filteredText.Append(text[0]);

            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] != text[i - 1])
                {
                    filteredText.Append(text[i]);
                }
            }

            Console.WriteLine(filteredText.ToString());
        }
    }
}
