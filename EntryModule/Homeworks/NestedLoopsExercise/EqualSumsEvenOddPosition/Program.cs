using System;

namespace EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                int num = i;

                int even = 0;
                int odd = 0;

                int index = 0;

                while(num != 0)
                {
                    if (index % 2 == 0)
                    {
                        even += num % 10;
                    }
                    else
                    {
                        odd += num % 10;
                    }

                    num /= 10;

                    index++;
                }

                if(even == odd)
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
