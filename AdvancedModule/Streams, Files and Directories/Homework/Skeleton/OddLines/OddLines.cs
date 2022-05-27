
namespace OddLines
{
    using System;
    using System.IO;
    public class OddLines
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputPath, outputPath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            var writer = new StreamWriter(outputFilePath);

            int lineNum = 0;

            using (reader)
            {
                using (writer)
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if(lineNum % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }

                        lineNum++;
                    }
                }
            }
        }
    }
}
