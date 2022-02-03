using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p07_RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            int repeatTimes = int.Parse(Console.ReadLine());

            PrintRepeatedString(str, repeatTimes);
        }

        static void PrintRepeatedString(string stringToRepeat, int repeatTimes)
        {
            for (int i = 0; i < repeatTimes; i++)
            {
                Console.Write(stringToRepeat);
            }
            Console.WriteLine();
        }
    }
}
