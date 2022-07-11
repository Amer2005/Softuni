using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            const int stationaryPhoneLenght = 7;

            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < numbers.Length; i++)
            {
                ICallable phone;

                if (numbers[i].Length == stationaryPhoneLenght)
                {
                    phone = new StationaryPhone();
                }
                else
                {
                    phone = new Smartphone();
                }

                try
                {
                    Console.WriteLine(phone.Call(numbers[i]));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            for (int i = 0; i < websites.Length; i++)
            {
                IBrowserable phone = new Smartphone();

                try
                {
                    Console.WriteLine(phone.Browse(websites[i]));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
