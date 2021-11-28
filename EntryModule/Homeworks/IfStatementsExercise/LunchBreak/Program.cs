using System;

namespace LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string showName = Console.ReadLine();

            double episodeLenght = double.Parse(Console.ReadLine());

            double breakLenght = double.Parse(Console.ReadLine());

            double timeLeft = breakLenght;

            timeLeft -= breakLenght / 8;

            timeLeft -= breakLenght / 4;

            if(timeLeft >= episodeLenght)
            {
                Console.WriteLine($"You have enough time to watch {showName} and left with {Math.Ceiling(timeLeft - episodeLenght)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {showName}, you need {Math.Ceiling(episodeLenght - timeLeft)} more minutes.");
            }
        }
    }
}
