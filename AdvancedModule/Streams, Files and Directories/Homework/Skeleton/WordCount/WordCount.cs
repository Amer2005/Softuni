namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            List<string> validWords = new List<string>();

            StreamReader validWordsReader = new StreamReader(wordsFilePath);

            using (validWordsReader)
            {
                foreach (var word in validWordsReader.ReadLine().Split(" "))
                {
                    validWords.Add(word.ToLower());
                }
            }

            StreamReader wordsReader = new StreamReader(textFilePath);

            List<string> textLines = new List<string>();

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            using (wordsReader)
            {
                string line;
                while ((line = wordsReader.ReadLine()) != null)
                {
                    textLines.Add(line);
                }
            }

            foreach (string word in validWords)
            {
                wordCounts.Add(word, 0);
            }

            Regex regex = new Regex(@"[a-zA-Z]+");

            foreach (string line in textLines)
            {
                string[] words = regex.Matches(line).Select(x => x.Value.ToLower()).ToArray();


                foreach (string word in words)
                {
                    if (validWords.Contains(word))
                    {
                        wordCounts[word]++;
                    }
                }
            }

            StreamWriter outputWriter = new StreamWriter(outputFilePath);

            using (outputWriter)
            {
                foreach (string word in validWords.OrderByDescending(x => wordCounts[x]))
                {
                    outputWriter.WriteLine($"{word} - {wordCounts[word]}");
                }
            }
        }
    }
}
