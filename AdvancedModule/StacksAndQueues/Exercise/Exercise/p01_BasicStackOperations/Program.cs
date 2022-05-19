using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01_BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int[] inputArgs = input.Split(' ').Select(int.Parse).ToArray();

            int numberOfElements = inputArgs[0];
            int numberOfElementsToPop = inputArgs[1];
            int numberToFind = inputArgs[2];

            Stack<int> stack = new Stack<int>(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse));

            for (int i = 0; i < numberOfElementsToPop; i++)
            {
                if(stack.Count == 0)
                {
                    break;
                }

                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.Contains(numberToFind) ? "true" : stack.Min().ToString());
            }
        }
    }
}
