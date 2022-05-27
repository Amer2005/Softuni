namespace ExtractBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class ExtractBytes
    {
        static void Main(string[] args)
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            FileStream fileStream = new FileStream(binaryFilePath, FileMode.Open);

            List<byte> fileBytes = new List<byte>();

            using (fileStream)
            {
                var buf = new byte[1024];

                while (true)
                {
                    int bytesRead = fileStream.Read(buf);

                    if (bytesRead == 0)
                    {
                        break;
                    }

                    foreach (var num in buf)
                    {
                        fileBytes.Add(num);
                    }
                }
            }

            StreamReader streamReader = new StreamReader(bytesFilePath);

            List<byte> searchBytes = new List<byte>();

            using (streamReader)
            {
                string line;
                while (true)
                {
                    line = streamReader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    searchBytes.Add(byte.Parse(line));
                }
            }

            FileStream fileWriter = new FileStream(outputPath, FileMode.Create);

            using (fileWriter)
            {
                foreach (var num in fileBytes)
                {
                    if (searchBytes.Contains(num))
                    {
                        fileWriter.WriteByte(num);
                    }
                }
            }

        }
    }
}
