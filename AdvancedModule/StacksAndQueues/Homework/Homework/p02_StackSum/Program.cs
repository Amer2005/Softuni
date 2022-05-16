using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02_StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            Stack<int> stack = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));

            while((input = Console.ReadLine()).ToLower() != "end")
            {
                input = input.ToLower();

                string[] inputArgs = input.Split(' ');

                string action = inputArgs[0];

                if (action == "add")
                {
                    int firstNumber = int.Parse(inputArgs[1]);
                    int secondNumber = int.Parse(inputArgs[2]);

                    stack.Push(firstNumber);
                    stack.Push(secondNumber);
                }
                else if (action == "remove")
                {
                    int countOfItems = int.Parse(inputArgs[1]);

                    if(countOfItems <= stack.Count)
                    {
                        for (int i = 0; i < countOfItems; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            Console.WriteLine("Sum: {0}", stack.Sum());
        }
    }
}
