using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList strings = new RandomList();

            strings.Add("a");
            strings.Add("b");
            strings.Add("c");
            strings.Add("d");
            strings.Add("e");

            Console.WriteLine(strings.RandomString());
        }
    }
}
