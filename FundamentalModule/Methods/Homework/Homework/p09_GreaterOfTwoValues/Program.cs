using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p09_GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string valueType = Console.ReadLine();

            if (valueType == "int")
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());

                Console.WriteLine(GetMax<int>(a, b));
            }
            else if (valueType == "char")
            {
                char a = char.Parse(Console.ReadLine());
                char b = char.Parse(Console.ReadLine());

                Console.WriteLine(GetMax<char>(a, b));
            }
            else
            {
                string a = Console.ReadLine();
                string b = Console.ReadLine();

                Console.WriteLine(GetMax<string>(a, b));
            }
        }

        private static T GetMax<T>(T a, T b) where T : IComparable<T>
        {
            if (a.CompareTo(b) > 0)
            {
                return a;
            }

            return b;
        }
    }
}
