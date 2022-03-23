using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace p02_FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"@#+[A-Z][[A-Za-z0-9]{4,}[A-Z]@#+");

            int numberOfBarcodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfBarcodes; i++)
            {
                string barcode = Console.ReadLine();

                if(!regex.IsMatch(barcode))
                {
                    Console.WriteLine("Invalid barcode");

                    continue;
                }

                StringBuilder allDigits = new StringBuilder(new string(barcode
                    .ToCharArray()
                    .Where(x => char.IsDigit(x))
                    .ToArray()));

                if(allDigits.Length == 0)
                {
                    allDigits = new StringBuilder("00");
                }

                Console.WriteLine($"Product group: {allDigits}");
            }
        }
    }
}
