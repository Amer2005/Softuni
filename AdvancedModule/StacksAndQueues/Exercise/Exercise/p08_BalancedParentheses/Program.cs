using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p08_BalancedParentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string parenthese = Console.ReadLine();

            Stack<char> opened = new Stack<char>();

            bool balanced = true;

            for (int i = 0; i < parenthese.Length; i++)
            {
                if (parenthese[i] == '(' || parenthese[i] == '[' || parenthese[i] == '{')
                {
                    opened.Push(parenthese[i]);
                }
                else
                {
                    if (opened.Count == 0)
                    {
                        balanced = false;
                        break;
                    }

                    if (FindClosedParanthese(opened.Peek()) == parenthese[i])
                    {
                        opened.Pop();
                    }
                    else
                    {
                        balanced = false;
                        break;
                    }
                }
            }

            Console.WriteLine(balanced ? "YES" : "NO");
        }

        static char FindClosedParanthese(char parenthese)
        {
            if(parenthese == '(')
            {
                return ')';
            }
            else if(parenthese == '[')
            {
                return ']';
            }
            else
            {
                return '}';
            }
        }
    }
}
