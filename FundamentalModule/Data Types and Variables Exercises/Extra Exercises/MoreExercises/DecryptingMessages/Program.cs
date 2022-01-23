using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecryptingMessages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numberOfLetters = int.Parse(Console.ReadLine());

            StringBuilder message = new StringBuilder();

            for (int i = 0; i < numberOfLetters; i++)
            {
                char letter = char.Parse(Console.ReadLine());

                letter = (char)((int)letter + key);

                message.Append(letter);
            }

            Console.WriteLine(message);
        }
    }
}
