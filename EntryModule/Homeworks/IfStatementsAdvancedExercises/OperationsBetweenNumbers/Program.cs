using System;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            char operation = char.Parse(Console.ReadLine());

            double result = 0;

            if (operation == '+' || operation == '-' || operation == '*')
            {
                if(operation == '+')
                {
                    result = a + b;
                }
                else if(operation == '-')
                {
                    result = a - b;
                }
                else
                {
                    result = a * b;
                }

                string oddEven = result % 2 == 0 ? "even" : "odd";

                Console.WriteLine($"{a} {operation} {b} = {result} - {oddEven}");
            }
            else
            {
                if(b == 0)
                {
                    Console.WriteLine($"Cannot divide {a} by zero");
                }
                else
                {
                    if (operation == '/')
                    {
                        result = (double)a / b;

                        Console.WriteLine($"{a} {operation} {b} = {result:f2}");
                    }
                    else
                    {
                        result = a % b;

                        Console.WriteLine($"{a} {operation} {b} = {result}");
                    }
                }
            }
        }
    }
}
