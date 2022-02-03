using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03_Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string action = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine(Calculate(action, a, b));
        }

        static int Calculate(string action, int a, int b)
        {
            if (action == "add")
            {
                return Add(a, b);
            }

            if (action == "multiply")
            {
                return Multiply(a, b);
            }

            if (action == "subtract")
            {
                return Subtract(a, b);
            }

            if (action == "divide")
            {
                return Divide(a, b);
            }

            return 0;
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

        static int Multiply(int a, int b)
        {
            return a * b;
        }

        static int Subtract(int a, int b)
        {
            return a - b;
        }

        static int Divide(int a, int b)
        {
            return a / b;
        }
    }
}
