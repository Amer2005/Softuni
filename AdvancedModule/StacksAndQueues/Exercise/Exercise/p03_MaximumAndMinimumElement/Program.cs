using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03_MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string input = Console.ReadLine();

                int[] inputArgs = input
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int action = inputArgs[0];

                //1 x – Push the element x into the stack.
                //2 – Delete the element present at the top of the stack.
                //3 – Print the maximum element in the stack.
                //4 – Print the minimum element in the stack.

                if(action == 1)
                {
                    int number = inputArgs[1];

                    stack.Push(number);
                } 
                else if (action == 2)
                {
                    if(stack.Count <= 0)
                    {
                        continue;
                    }

                    stack.Pop();
                }
                else if (action == 3)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }

                    Console.WriteLine(stack.Max());
                }
                else if (action == 4)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }

                    Console.WriteLine(stack.Min());
                }
            }

            Console.WriteLine(String.Join(", ", stack));
        }
    }
}
