using System;
using System.Linq;

namespace p03_CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(Environment.NewLine, Console.ReadLine()
                                .Split(' ')
                                .Where(x => x.Length > 0)
                                .Where(x => char.IsUpper(x[0]))));
        }
    }
}
