using System;

namespace p04_SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputArgs = Console.ReadLine().Split(' ');

            long sum = 0;

            for (int i = 0; i < inputArgs.Length; i++)
            {
                try
                {
                    int num = int.Parse(inputArgs[i]);
                    sum += num;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{inputArgs[i]}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{inputArgs[i]}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{inputArgs[i]}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
