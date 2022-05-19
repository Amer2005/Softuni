using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p09_SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            Stack<StringBuilder> actionQueue = new Stack<StringBuilder>();

            actionQueue.Push(new StringBuilder(""));

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(' ');

                string action = inputArgs[0];

                //1 someString - appends someString to the end of the text.
                //2 count - erases the last count elements from the text.
                //3 index - returns the element at position index from the text.
                //4 - undoes the last not undone command of type 1 or 2 and returns the text to the state before that operation.

                if (action == "1")
                {
                    string stringToAdd = inputArgs[1];

                    StringBuilder textNow = new StringBuilder(actionQueue.Peek().ToString());

                    actionQueue.Push(textNow.Append(stringToAdd));
                }
                else if (action == "2")
                {
                    int countToRemove = int.Parse(inputArgs[1]);

                    actionQueue.Push(new StringBuilder(actionQueue.Peek().ToString().Substring(0, actionQueue.Peek().Length - countToRemove)));
                }
                else if (action == "3")
                {
                    int index = int.Parse(inputArgs[1]);

                    Console.WriteLine(actionQueue.Peek()[index - 1]);
                }
                else
                {
                    actionQueue.Pop();

                    if (actionQueue.Count == 0)
                    {
                        actionQueue.Push(new StringBuilder(""));
                    }
                }
            }
        }
    }
}
