using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p08_AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split(' ').ToList();

            string input;

            while ((input = Console.ReadLine()) != "3:1")
            {
                string[] inputArgs = input.Split(' ');

                string action = inputArgs[0];

                if (action == "merge")
                {
                    int startIndex = int.Parse(inputArgs[1]);
                    int endIndex = int.Parse(inputArgs[2]);

                    words = MergeWords(words, startIndex, endIndex);
                }
                else if (action == "divide")
                {
                    int index = int.Parse(inputArgs[1]);
                    int count = int.Parse(inputArgs[2]);

                    words = DivideWords(words, index, count);
                }
            }

            Console.WriteLine(String.Join(" ", words));
        }

        static List<string> MergeWords(List<string> words, int startIndex, int endIndex)
        {
            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (endIndex >= words.Count)
            {
                endIndex = words.Count - 1;
            }

            StringBuilder resultString = new StringBuilder();

            for (int i = startIndex; i <= endIndex; i++)
            {
                resultString.Append(words[i]);
            }

            List<string> result = new List<string>();

            for (int i = 0; i < words.Count; i++)
            {
                if (i == startIndex)
                {
                    result.Add(resultString.ToString());
                }
                else if(i < startIndex || i > endIndex)
                {
                    result.Add(words[i]);
                }
            }

            return result;
        }

        static List<string> DivideWords(List<string> words, int index, int count)
        {
            if (index < 0)
            {
                index = 0;
            }

            if (index >= words.Count)
            {
                index = words.Count - 1;
            }

            if (count == 1)
            {
                return words;
            }

            List<string> dividedWords = new List<string>();

            string word = words[index];

            int lenght = word.Length / count;

            for (int i = 0; i < word.Length; i++)
            {
                if (dividedWords.Count >= count)
                {
                    break;
                }

                if ((i + 1) % lenght == 0)
                {
                    dividedWords.Add(word.Substring(i - lenght + 1, lenght));
                }
            }

            if (word.Length % count != 0)
            {
                dividedWords[dividedWords.Count - 1] += word.Substring(count * lenght, word.Length - count * lenght);
            }

            List<string> result = new List<string>();

            for (int i = 0; i < words.Count; i++)
            {
                if (i == index)
                {
                    for (int j = 0; j < dividedWords.Count; j++)
                    {
                        result.Add(dividedWords[j]);
                    }
                }
                else
                {
                    result.Add(words[i]);
                }
            }

            return result;
        }
    }
}
