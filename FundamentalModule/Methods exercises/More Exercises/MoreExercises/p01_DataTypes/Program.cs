using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01_DataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();

            string input = Console.ReadLine();

            string output = string.Empty;


            if (dataType == "int")
            {
                output = Calculate(int.Parse(input)).ToString();
            }
            else if (dataType == "real")
            {
                output = $"{Calculate(double.Parse(input)):f2}";
            }
            else if (dataType == "string")
            {
                output = Calculate(input);
            }

            Console.WriteLine(output);
        }

        static int Calculate(int number)
        {
            return number * 2;
        }

        static double Calculate(double number)
        {
            return number * 1.5;
        }

        static string Calculate(string word)
        {
            return $"${word}$";
        }
    }
}
