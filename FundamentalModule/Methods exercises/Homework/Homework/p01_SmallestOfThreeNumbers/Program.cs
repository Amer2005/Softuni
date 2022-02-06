using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01_SmallestOfThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(GetSmallestOfThreeNumbers(firstNumber,secondNumber,thirdNumber));
        }

        static int GetSmallestOfThreeNumbers(int firstNumber, int secondNumber, int thirdNumber)
        {
            return Math.Min(thirdNumber, Math.Min(firstNumber, secondNumber));
        }
    }
}
