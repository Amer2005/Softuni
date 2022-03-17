using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04_CaesarCypher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder(Console.ReadLine());

            for (int i = 0; i < text.Length; i++)
            {
                text[i] = (char)(text[i] + 3);
            }

            Console.WriteLine(text.ToString());
        }
    }
}
