using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04_MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> indexOfLastOpeningBracket = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    indexOfLastOpeningBracket.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int openingBracketIndex = indexOfLastOpeningBracket.Pop();
                    int closingBracketIndex = i;

                    Console.WriteLine(expression.Substring(openingBracketIndex, closingBracketIndex - openingBracketIndex + 1));
                }
            }
        }
    }
}
