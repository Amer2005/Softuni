using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustion = int.Parse(Console.ReadLine());

            if (pokePower % 2 == 0 && exhaustion != 0 && pokePower > 1)
            {
                if((pokePower / 2) % distance == 0)
                {
                    int targetsPoked = 0;

                    pokePower /= 2;

                    targetsPoked += pokePower / distance;
                    pokePower /= exhaustion;

                    targetsPoked += pokePower / distance;

                    Console.WriteLine(pokePower % distance);
                    Console.WriteLine(targetsPoked);

                    return;
                }
            }

            Console.WriteLine(pokePower % distance);
            Console.WriteLine(pokePower / distance);
        }
    }
}
