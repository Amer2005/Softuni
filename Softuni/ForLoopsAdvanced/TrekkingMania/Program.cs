using System;

namespace TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int totalClimbers = 0;

            double musala = 0;
            double monblan = 0;
            double kilimanjaro = 0;
            double k2 = 0;
            double everest = 0;

            for (int i = 0; i < n; i++)
            {
                int climbers = int.Parse(Console.ReadLine());

                totalClimbers += climbers;

                if (climbers <= 5)
                {
                    musala += climbers;
                }
                else if(climbers <= 12)
                {
                    monblan += climbers;
                }
                else if (climbers <= 25)
                {
                    kilimanjaro += climbers;
                }
                else if (climbers <= 40)
                {
                    k2 += climbers;
                }
                else
                {
                    everest += climbers;
                }
            }

            musala = musala / totalClimbers * 100;
            monblan = monblan / totalClimbers * 100;
            kilimanjaro = kilimanjaro / totalClimbers * 100;
            k2 = k2 / totalClimbers * 100;
            everest = everest / totalClimbers * 100;

            Console.WriteLine($"{musala:f2}%");
            Console.WriteLine($"{monblan:f2}%");
            Console.WriteLine($"{kilimanjaro:f2}%");
            Console.WriteLine($"{k2:f2}%");
            Console.WriteLine($"{everest:f2}%");
        }
    }
}
