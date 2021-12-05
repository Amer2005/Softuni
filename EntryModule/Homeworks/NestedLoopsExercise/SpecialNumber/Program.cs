using System;

namespace SpecialNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                int num = i;

                bool isMagicNumber = true;

                while(num > 0)
                {
                    if(num % 10 == 0)
                    {
                        isMagicNumber = false;

                        break;
                    }

                    if(n % (num % 10) != 0)
                    {
                        isMagicNumber = false;

                        break;
                    }

                    num /= 10;
                }

                if(isMagicNumber)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
