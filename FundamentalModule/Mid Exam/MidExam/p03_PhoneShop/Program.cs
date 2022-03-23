using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03_PhoneShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> phones = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string input;

            while((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                string action = commands[0];

                if (action == "Add")
                {
                    string phone = commands[1];

                    if(phones.Contains(phone))
                    {
                        continue;
                    }

                    phones.Add(phone);
                }
                else if (action == "Remove")
                {
                    string phone = commands[1];

                    if (!phones.Contains(phone))
                    {
                        continue;
                    }

                    phones.Remove(phone);
                }
                else if (action == "Bonus phone")
                {
                    string[] bonusPhones = commands[1].Split(':');
                    string oldPhone = bonusPhones[0];
                    string newPhone = bonusPhones[1];

                    if (!phones.Contains(oldPhone))
                    {
                        continue;
                    }

                    int index = phones.IndexOf(oldPhone);

                    phones.Insert(index + 1, newPhone);
                }
                else if (action == "Last")
                {
                    string phone = commands[1];

                    if (!phones.Contains(phone))
                    {
                        continue;
                    }

                    phones.Remove(phone);

                    phones.Add(phone);
                }
            }

            Console.WriteLine(String.Join(", ", phones));
        }
    }
}
