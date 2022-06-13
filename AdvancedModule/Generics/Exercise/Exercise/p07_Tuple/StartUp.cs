using System;

namespace Tuple
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Tuple<string, string> nameAddress = new Tuple<string, string>();
            Tuple<string, int> nameBeers = new Tuple<string, int>();
            Tuple<int, double> integerDouble = new Tuple<int, double>();

            string input = Console.ReadLine();
            string[] splittedInput = input.Split(' ');

            nameAddress.Item1 = splittedInput[0] + " " + splittedInput[1];
            nameAddress.Item2 = splittedInput[2];

            input = Console.ReadLine();
            splittedInput = input.Split(' ');

            nameBeers.Item1 = splittedInput[0];
            nameBeers.Item2 = int.Parse(splittedInput[1]);

            input = Console.ReadLine();
            splittedInput = input.Split(' ');

            integerDouble.Item1 = int.Parse(splittedInput[0]);
            integerDouble.Item2 = double.Parse(splittedInput[1]);

            Console.WriteLine(nameAddress);
            Console.WriteLine(nameBeers);
            Console.WriteLine(integerDouble);
        }
    }
}
