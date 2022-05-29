namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);

            int lineNum = 1;

            StringBuilder result = new StringBuilder();

            using (reader)
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string newLine = $"Line {lineNum}: {line} ({line.Count(x => char.IsLetter(x))})({line.Count(x => char.IsPunctuation(x))})";

                    result.Append(newLine + Environment.NewLine);

                    lineNum++;
                }
            }

            File.WriteAllText(outputFilePath, result.ToString());
        }
    }
}
