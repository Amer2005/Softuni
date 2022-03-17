using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01_ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(new string[] { ", "}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < usernames.Length; i++)
            {
                if(IsUsernameValid(usernames[i]))
                {
                    Console.WriteLine(usernames[i]);
                }
            }
        }

        static bool IsUsernameValid(string username)
        {
            if (username.Length < 3 || username.Length > 16)
            {
                return false;
            }

            for (int i = 0; i < username.Length; i++)
            {
                if (char.IsDigit(username[i]))
                {
                    continue;
                }

                if (char.IsLetter(username[i]))
                {
                    continue;
                }

                if (username[i] == '_' || username[i] == '-')
                {
                    continue;
                }

                return false;
            }

            return true;
        }
    }
}
