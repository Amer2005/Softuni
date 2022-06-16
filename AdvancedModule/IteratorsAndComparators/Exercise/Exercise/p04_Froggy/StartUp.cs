using System;
using System.Linq;

namespace p04_Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Lake lake = new Lake(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList());

            Console.WriteLine(String.Join(", ", lake));
        }
    }
}
