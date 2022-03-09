using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04_TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();

            foreach (var bannedWord in bannedWords)
            {
                while (text.Contains(bannedWord))
                {
                    int startIndex = text.IndexOf(bannedWord);

                    text = text.Replace(bannedWord, new string(bannedWord.ToCharArray().Select(x => '*').ToArray()));
                }
            }

            Console.WriteLine(text);
        }
    }
}
