namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main(string[] args)
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            StreamReader firstReader = new StreamReader(firstInputFilePath);
            StreamReader secondReader = new StreamReader(secondInputFilePath);

            StreamWriter streamWriter = new StreamWriter(outputFilePath);

            string line1;
            string line2;

            using (firstReader)
            {
                using (secondReader)
                {
                    using (streamWriter)
                    {
                        while (true)
                        {
                            line1 = firstReader.ReadLine();
                            line2 = secondReader.ReadLine();

                            if (line1 == null && line2 == null)
                            {
                                break;
                            }

                            if (line1 != null)
                            {
                                streamWriter.WriteLine(line1);
                            }

                            if (line2 != null)
                            {
                                streamWriter.WriteLine(line2);
                            }
                        }
                    }
                }
            }
        }
    }
}
