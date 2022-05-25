using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03_PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfChemicals = int.Parse(Console.ReadLine());

            HashSet<string> chemicals = new HashSet<string>();

            for (int i = 0; i < numberOfChemicals; i++)
            {
                string compound = Console.ReadLine();
                string[] compoundElements = compound.Split(' ');

                foreach (string chemical in compoundElements)
                {
                    if (!chemicals.Contains(chemical))
                    {
                        chemicals.Add(chemical);
                    }
                }
            }

            Console.WriteLine(String.Join(" ", chemicals.OrderBy(x => x)));
        }
    }
}
