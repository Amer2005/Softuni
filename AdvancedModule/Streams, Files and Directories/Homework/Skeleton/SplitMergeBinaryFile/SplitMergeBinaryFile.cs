namespace SplitMergeBinaryFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            //FileStream fileStream = new FileStream(sourceFilePath, FileMode.Open);

            byte[] fileBytes = File.ReadAllBytes(sourceFilePath);

            List<byte> firstBytes = new List<byte>();
            List<byte> secondBytes = new List<byte>();

            for (int i = 0; i < fileBytes.Length; i++)
            {
                if (i < fileBytes.Length / 2 + fileBytes.Length % 2)
                {
                    firstBytes.Add(fileBytes[i]);
                }
                else
                {
                    secondBytes.Add(fileBytes[i]);
                }
            }

            FileStream firstFileWriter = new FileStream(partOneFilePath, FileMode.Create);
            FileStream secondFileWriter = new FileStream(partTwoFilePath, FileMode.Create);

            using (firstFileWriter)
            {
                firstFileWriter.Write(firstBytes.ToArray());
            }

            using (secondFileWriter)
            {
                secondFileWriter.Write(secondBytes.ToArray());
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            FileStream fileStream = new FileStream(partOneFilePath, FileMode.Open);

            List<byte> firstFileBytes = new List<byte>();

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

                    for (int i = 0; i < bytesRead; i++)
                    {
                        firstFileBytes.Add(buf[i]);
                    }
                }
            }

            FileStream secondFileStream = new FileStream(partTwoFilePath, FileMode.Open);

            List<byte> secondFileBytes = new List<byte>();

            using (secondFileStream)
            {
                var buf = new byte[4096];

                while (true)
                {
                    int bytesRead = secondFileStream.Read(buf);

                    if (bytesRead == 0)
                    {
                        break;
                    }

                    for (int i = 0; i < bytesRead; i++)
                    {
                        secondFileBytes.Add(buf[i]);
                    }
                }
            }

            FileStream outputfileStream = new FileStream(joinedFilePath, FileMode.Create);

            using (outputfileStream)
            {
                outputfileStream.Write(firstFileBytes.ToArray());
                outputfileStream.Write(secondFileBytes.ToArray());
            }
        }
    }
}