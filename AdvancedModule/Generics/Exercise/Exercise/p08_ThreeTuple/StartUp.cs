using System;
using System.Linq;

namespace Tuple
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            ThreeTuple<string, string, string> nameAddressTown = new ThreeTuple<string, string, string>();
            ThreeTuple<string, int, bool> nameBeersDrunk = new ThreeTuple<string, int, bool>();
            ThreeTuple<string, double, string> nameBalanceBankName = new ThreeTuple<string, double, string>();

            string input = Console.ReadLine();
            string[] splittedInput = input.Split(' ');

            nameAddressTown.Item1 = splittedInput[0] + " " + splittedInput[1];
            nameAddressTown.Item2 = splittedInput[2];
            nameAddressTown.Item3 = string.Join(" ", splittedInput.Skip(3).Take(splittedInput.Length - 3));

            input = Console.ReadLine();
            splittedInput = input.Split(' ');

            nameBeersDrunk.Item1 = splittedInput[0];
            nameBeersDrunk.Item2 = int.Parse(splittedInput[1]);
            nameBeersDrunk.Item3 = splittedInput[2] == "drunk";

            input = Console.ReadLine();
            splittedInput = input.Split(' ');

            nameBalanceBankName.Item1 = splittedInput[0];
            nameBalanceBankName.Item2 = double.Parse(splittedInput[1]);
            nameBalanceBankName.Item3 = splittedInput[2];

            Console.WriteLine(nameAddressTown);
            Console.WriteLine(nameBeersDrunk);
            Console.WriteLine(nameBalanceBankName);
        }
    }
}
