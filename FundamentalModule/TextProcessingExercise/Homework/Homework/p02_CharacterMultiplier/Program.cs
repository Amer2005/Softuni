using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02_CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputArgs = Console.ReadLine().Split(' ');

            string firstString = inputArgs[0];
            string secondString = inputArgs[1];

            if (firstString.Length < secondString.Length)
            {
                string temp = firstString;

                firstString = secondString;
                secondString = temp;
            }

            long multiplication = 0;

            for (int i = 0; i < secondString.Length; i++)
            {
                multiplication += firstString[i] * secondString[i];
            }

            for (int i = secondString.Length; i < firstString.Length; i++)
            {
                multiplication += firstString[i];
            }

            Console.WriteLine(multiplication);
        }
    }
}
