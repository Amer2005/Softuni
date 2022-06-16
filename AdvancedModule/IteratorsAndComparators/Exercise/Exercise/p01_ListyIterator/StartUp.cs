using System;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //this is probelm 1 and 2
            ListyIterator<string> listy = null;

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var splittedInput = input.Split(' ');

                string command = splittedInput[0];

                if (command == "Create")
                {
                    listy = new ListyIterator<string>(splittedInput.Skip(1).ToArray());
                }
                else if (command == "Move")
                {
                    Console.WriteLine(listy.Move());
                }
                else if (command == "Print")
                {
                    listy.Print();
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }
                else if (command == "PrintAll")
                {
                    listy.PrintAll();
                }
            }
        }
    }
}
