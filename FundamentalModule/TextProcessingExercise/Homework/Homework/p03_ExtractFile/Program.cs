using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03_ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            string file = path.Substring(path.LastIndexOf('\\') + 1);

            int indexOfDot = file.IndexOf('.');

            string fileName = file.Substring(0, indexOfDot);
            string extension = file.Substring(indexOfDot + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
