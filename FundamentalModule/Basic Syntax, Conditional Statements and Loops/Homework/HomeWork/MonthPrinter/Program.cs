using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthPrinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int month = int.Parse(Console.ReadLine());

            if (month > 12 || month < 1)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine(new DateTime(2015, month, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("en")));
            }
        }
    }
}
