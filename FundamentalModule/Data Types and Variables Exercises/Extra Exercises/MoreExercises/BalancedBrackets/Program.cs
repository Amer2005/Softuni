using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());

            bool opened = false;

            bool balanced = true;

            for (int i = 0; i < numberOfStrings; i++)
            {
                string str = Console.ReadLine();

                if (!balanced)
                {
                    continue;
                }

                if (str == "(")
                {
                    if (!opened)
                    {
                        opened = true;
                    }
                    else
                    {
                        balanced = false;
                    }
                }
                else if (str == ")")
                {
                    if (opened)
                    {
                        opened = false;
                    }
                    else
                    {
                        balanced = false;
                    }
                }
            }

            if (balanced && !opened)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
