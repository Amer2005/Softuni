using System;
using System.Linq;
using System.Text;

namespace p03_Stack
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack<string> stack = new CustomStack<string>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var splittedInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = splittedInput[0];

                if (command == "Push")
                {
                    string[] values = splittedInput
                        .Skip(1)
                        .Select(x => x.TrimEnd(','))
                        .ToArray();

                    for (int i = 0; i < values.Length; i++)
                    {
                        stack.Push(values[i]);
                    }
                }
                else if (command == "Pop")
                {
                    if(stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("No elements");
                    }
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, stack));
            Console.WriteLine(String.Join(Environment.NewLine, stack));
        }
    }
}
