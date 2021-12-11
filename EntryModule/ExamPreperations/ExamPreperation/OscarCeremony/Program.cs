 using System;

namespace OscarCeremony
{
    class Program
    {
        static void Main(string[] args)
        {
            int rent = int.Parse(Console.ReadLine());

            double statues = (double)rent * 0.7;

            double keturing = statues * 0.85;

            double sound = keturing * 0.5;

            Console.WriteLine($"{rent + statues + keturing + sound:f2}");
        }
    }
}
