using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01_SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input;

            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] splittedInput = input.Split(new string[] { ":|:" }, StringSplitOptions.RemoveEmptyEntries);

                string actionType = splittedInput[0];

                if (actionType == "InsertSpace")
                {
                    int index = int.Parse(splittedInput[1]);

                    message = message.Insert(index, " ");
                }
                else if (actionType == "Reverse")
                {
                    string substring = splittedInput[1];

                    int index = message.IndexOf(substring);

                    if (index == -1)
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    message = message.Remove(index, substring.Length);

                    message = message + new string(substring.ToCharArray().Reverse().ToArray());
                }
                else if (actionType == "ChangeAll")
                {
                    string substring = splittedInput[1];

                    string replacement = splittedInput[2];

                    message = message.Replace(substring, replacement);
                }

                Console.WriteLine(message);
            }

            //Laptop test
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
