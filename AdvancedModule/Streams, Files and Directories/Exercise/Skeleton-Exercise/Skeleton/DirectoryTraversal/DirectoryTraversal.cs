namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            //string path = "C:/Program Files (x86)/Steam/graphics";
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);
            
            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath, "*", SearchOption.TopDirectoryOnly);

            Dictionary<string, HashSet<string>> extensionsAndFiles = new Dictionary<string, HashSet<string>>();

            foreach (var file in files)
            {
                string extension = GetExtension(file);

                if (extensionsAndFiles.ContainsKey(extension))
                {
                    extensionsAndFiles[extension].Add(file);
                }
                else
                {
                    extensionsAndFiles.Add(extension, new HashSet<string>() { file });
                }
            }

            StringBuilder result = new StringBuilder();

            foreach (var extensionFilesPair in extensionsAndFiles)
            {
                result.AppendLine($".{extensionFilesPair.Key}");

                foreach (var file in extensionFilesPair.Value.OrderBy(x => GetFileName(x)))
                {
                    result.AppendLine($"--{GetFileName(file)} - {GetFileSize(file)}kb");
                }
            }

            return result.ToString();
        }

        public static string GetFileName(string filePath)
        {
            int lastSlash = filePath.LastIndexOf('\\');

            return filePath.Substring(lastSlash + 1, filePath.Length - lastSlash - 1);
        }

        public static string GetExtension(string filePath)
        {
            int lastDot = filePath.LastIndexOf('.');

            return filePath.Substring(lastDot + 1, filePath.Length - lastDot - 1);
        }

        public static decimal GetFileSize(string filePath)
        {
            return (decimal)(new System.IO.FileInfo(filePath).Length) / 1024;
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            FileStream fileStream = new FileStream(reportFileName, FileMode.Create, FileAccess.ReadWrite);

            byte[] bytes = Encoding.UTF8.GetBytes(textContent);

            fileStream.Write(bytes);
        }
    }
}
