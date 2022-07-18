using System;

namespace p01_SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine(CalculateSquareRoot(number));
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }

        static double CalculateSquareRoot(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Number cannot be negative!");
            }

            return Math.Sqrt(number);
        }
    }
}
