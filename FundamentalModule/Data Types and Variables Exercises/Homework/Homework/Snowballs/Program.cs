using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowballs = int.Parse(Console.ReadLine());

            BigInteger maxSnowballValue = -1;
            int maxSnowballSnow = 0;
            int maxSnowballTime = 0;
            int maxSnowballQuailty = 0;

            for (int i = 0; i < numberOfSnowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowbalValue = BigInteger.Pow((BigInteger)(snowballSnow / snowballTime), snowballQuality);

                if (snowbalValue > maxSnowballValue)
                {
                    maxSnowballValue = snowbalValue;
                    maxSnowballTime = snowballTime;
                    maxSnowballSnow = snowballSnow;
                    maxSnowballQuailty = snowballQuality;
                }
            }

            Console.WriteLine($"{maxSnowballSnow} : {maxSnowballTime} = {maxSnowballValue} ({maxSnowballQuailty})");
        }
    }
}
