using System;

namespace _2k1
{
    class Program
    {
        static void Main(string[] args)
        {
            int neededNum = int.Parse(Console.ReadLine());

            int num = 1;

            while(num <= neededNum)
            {
                Console.WriteLine(num);

                num = num * 2 + 1;
            }
        }
    }
}
