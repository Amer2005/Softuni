using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02_ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] actionArgs = input.Split(' ');

                if (actionArgs[0] == "Insert")
                {
                    int number = int.Parse(actionArgs[1]);
                    int position = int.Parse(actionArgs[2]);

                    numbers.Insert(position, number);
                }
                else if(actionArgs[0] == "Delete")
                {
                    int number = int.Parse(actionArgs[1]);

                    numbers = numbers.Where(x => x != number).ToList();
                }
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
