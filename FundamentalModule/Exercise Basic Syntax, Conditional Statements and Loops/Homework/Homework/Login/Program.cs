using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = new string(username.Reverse().ToArray());

            string passwordInput = Console.ReadLine();

            int tries = 0;

            while (passwordInput != password)
            {
                tries++;
                if (tries >= 4)
                {
                    break;
                }
                Console.WriteLine("Incorrect password. Try again.");

                passwordInput = Console.ReadLine();
            }

            if (passwordInput == password)
            {
                Console.WriteLine($"User {username} logged in.");
            }
            else
            {
                Console.WriteLine($"User {username} blocked!");
            }
        }
    }
}
