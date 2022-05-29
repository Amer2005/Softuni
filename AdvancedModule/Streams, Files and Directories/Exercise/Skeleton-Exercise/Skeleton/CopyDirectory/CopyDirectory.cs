namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            //string inputPath =  @$"{Console.ReadLine()}";
            string inputPath =  @$"C:\Users\Amer\Desktop\Softuni\Softuni\AdvancedModule\Streams, Files and Directories\Exercise\Skeleton-Exercise\Skeleton\CopyDirectory\DirectoryToCopy";

            //string outputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"C:\Users\Amer\Desktop\Softuni\Softuni\AdvancedModule\Streams, Files and Directories\Exercise\Skeleton-Exercise\Skeleton\CopyDirectory";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            string[] files = Directory.GetFiles(inputPath, "*", SearchOption.TopDirectoryOnly);

            Directory.CreateDirectory(outputPath + "/Copy");

            outputPath = outputPath + "/Copy";

            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);

                File.Delete($"{outputPath}/{fileName}");
                File.Copy($"{inputPath}/{fileName}", $"{outputPath}/{fileName}");
            }
        }
    }
}
