namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            var reader = new StreamReader(inputFilePath);

            int lineNum = 0;

            StringBuilder result = new StringBuilder();

            using (reader)
            {
                string line;

                List<char> replaceChars = new List<char> { '-', ',', '.', '!', '?' };

                while ((line = reader.ReadLine()) != null)
                {
                    if (lineNum % 2 == 0)
                    {
                        StringBuilder replacedLine = new StringBuilder(line);

                        for (int i = 0; i < line.Length; i++)
                        {
                            if (replaceChars.Contains(line[i]))
                            {
                                replacedLine[i] = '@';
                            }
                        }

                        List<string> words = replacedLine.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

                        words.Reverse();

                        result.Append(String.Join(" ", words));

                        result.Append(Environment.NewLine);
                    }

                    lineNum++;
                }
            }

            return result.ToString();
        }
    }
}
