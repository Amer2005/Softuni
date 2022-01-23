using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string dataType;

                if (int.TryParse(input, out int num))
                {
                    dataType = "integer";
                }
                else if(float.TryParse(input, out float floatNum))
                {
                    dataType = "floating point";
                }
                else if (char.TryParse(input, out char ch))
                {
                    dataType = "character";
                }
                else if(bool.TryParse(input, out bool boolean)) 
                {
                    dataType = "boolean";
                }
                else
                {
                    dataType = "string";
                }

                Console.WriteLine($"{input} is {dataType} type");

                input = Console.ReadLine();
            }
        }
    }
}
