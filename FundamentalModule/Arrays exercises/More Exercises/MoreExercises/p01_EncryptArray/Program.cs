using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01_EncryptArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());

            string[] messages = new string[numberOfMessages];

            int[] encryptetMessages = new int[numberOfMessages];

            for (int i = 0; i < messages.Length; i++)
            {
                messages[i] = Console.ReadLine();

                int messageSum = 0;

                for (int j = 0; j < messages[i].Length; j++)
                {
                    if(messages[i][j] == 'a' || messages[i][j] == 'e' || messages[i][j] == 'i' || messages[i][j] == 'o' || messages[i][j] == 'u' ||
                       messages[i][j] == 'A' || messages[i][j] == 'E' || messages[i][j] == 'I' || messages[i][j] == 'O' || messages[i][j] == 'U')
                    {
                        messageSum += (int)messages[i][j] * messages[i].Length;
                    }
                    else
                    {
                        messageSum += (int)messages[i][j] / messages[i].Length;
                    }
                }

                encryptetMessages[i] = messageSum;
            }

            Array.Sort(encryptetMessages);

            for (int i = 0; i < encryptetMessages.Length; i++)
            {
                Console.WriteLine(encryptetMessages[i]);
            }
        }
    }
}
