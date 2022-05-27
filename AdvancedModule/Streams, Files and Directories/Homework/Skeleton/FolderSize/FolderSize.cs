namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            string[] files = Directory.GetFiles(folderPath,"*" ,SearchOption.AllDirectories);

            double folderSize = 0;

            foreach (var file in files)
            {
                folderSize += new System.IO.FileInfo(file).Length; ;
            }

            StreamWriter streamWriter = new StreamWriter(outputFilePath);

            using (streamWriter)
            {
                streamWriter.WriteLine(folderSize / 1024); 
            }
        }
    }
}
