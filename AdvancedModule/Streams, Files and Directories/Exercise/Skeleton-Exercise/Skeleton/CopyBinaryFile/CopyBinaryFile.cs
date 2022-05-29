namespace CopyBinaryFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            FileStream fileStream = new FileStream(inputFilePath, FileMode.Open);

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

            FileStream outputFileStream = new FileStream(outputFilePath, FileMode.Create);

            using (fileStream)
            {
                outputFileStream.Write(firstFileBytes.ToArray());
            }
        }
    }
}
