using System;

namespace SumAndProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if(n % 10 != 5 && n % 3 != 0)
            {
                Console.WriteLine("Nothing found");
                return;
            }

            for (int a = 0; a <= 9; a++)
            {
                for (int b = 9; b >= a; b--)
                {
                    for (int c = 0; c <= 9; c++)
                    {
                        for (int d = 9; d >= c; d--)
                        {

                            if(n % 10 == 5)
                            {
                                if (a != 0)
                                {
                                    if (a + b + c + d == a * b * c * d)
                                    {
                                        Console.WriteLine($"{a}{b}{c}{d}");

                                        return;
                                    }
                                }
                            }
                            

                            if(n % 3 == 0)
                            {
                                if((a + b + c + d) == 0)
                                {
                                    continue;
                                }

                                if(d == 0)
                                {
                                    continue;
                                }

                                if ((a * b * c * d) / (a + b + c + d) == 3)
                                {
                                    Console.WriteLine($"{d}{c}{b}{a}");

                                    return;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Nothing found");
        }
    }
}
