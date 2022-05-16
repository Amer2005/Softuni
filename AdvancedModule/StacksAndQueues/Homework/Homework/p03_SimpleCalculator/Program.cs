using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03_SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mathOperation = Console.ReadLine();

            Stack<string> NumbersAndOperators = new Stack<string>(mathOperation.Split(' '));

            int result = 0;

            while (NumbersAndOperators.Count > 1)
            {
                int number = int.Parse(NumbersAndOperators.Pop());

                string symbol = NumbersAndOperators.Pop();

                if (symbol == "+")
                {
                    result += number;
                }
                else
                {
                    result -= number;
                }
            }

            int endNumber = int.Parse(NumbersAndOperators.Pop());

            result += endNumber;

            Console.WriteLine(result);
        }
    }
}
