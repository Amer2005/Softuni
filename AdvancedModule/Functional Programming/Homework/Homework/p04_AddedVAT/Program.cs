using System;
using System.Linq;

namespace p04_AddedVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(Environment.NewLine, Console.ReadLine()
                .Split(", ")
                .Select(decimal.Parse) // make decimal
                .Select(x => x * 1.2m) // add 20%
                .Select(x => $"{x:f2}"))); //make formated string
        }
    }
}
