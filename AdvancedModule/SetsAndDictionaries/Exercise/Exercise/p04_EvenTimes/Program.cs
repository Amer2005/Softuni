using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04_EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfNumbers = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbersTimesMet = new Dictionary<int, int>();

            for (int i = 0; i < countOfNumbers; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (numbersTimesMet.ContainsKey(number))
                {
                    numbersTimesMet[number]++;
                }
                else
                {
                    numbersTimesMet.Add(number, 1);
                }
            }

            int evenNum = 0;

            foreach (var numberTimesMetPair in numbersTimesMet)
            {
                if (numberTimesMetPair.Value % 2 == 0)
                {
                    evenNum = numberTimesMetPair.Key;

                    break;
                }
            }

            Console.WriteLine(evenNum);
        }
    }
}
