using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p06_CardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstDeckArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] secondDeckArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> firstDeck = new Queue<int>();
            Queue<int> secondDeck = new Queue<int>();

            for (int i = 0; i < firstDeckArray.Length; i++)
            {
                firstDeck.Enqueue(firstDeckArray[i]);
            }

            for (int i = 0; i < secondDeckArray.Length; i++)
            {
                secondDeck.Enqueue(secondDeckArray[i]);
            }

            while (firstDeck.Count > 0 && secondDeck.Count > 0)
            {
                if (firstDeck.First() > secondDeck.First())
                {
                    firstDeck.Enqueue(secondDeck.Dequeue());
                    firstDeck.Enqueue(firstDeck.Dequeue());
                }
                else if (firstDeck.First() < secondDeck.First())
                {
                    secondDeck.Enqueue(firstDeck.Dequeue());
                    secondDeck.Enqueue(secondDeck.Dequeue());
                }
                else
                {
                    firstDeck.Dequeue();
                    secondDeck.Dequeue();
                }
            }

            int sum = 0;

            if (firstDeck.Count == 0)
            {
                secondDeck.Sum(x => sum += x);

                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
            else if (secondDeck.Count == 0)
            {
                firstDeck.Sum(x => sum += x);

                Console.WriteLine($"First player wins! Sum: {sum}");
            }
        }
    }
}
