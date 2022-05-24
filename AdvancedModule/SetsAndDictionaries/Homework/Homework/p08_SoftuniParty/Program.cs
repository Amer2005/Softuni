using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p08_SoftuniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            HashSet<string> reservations = new HashSet<string>();

            while ((input = Console.ReadLine()) != "PARTY")
            {
                string reservation = input;

                reservations.Add(reservation);
            }

            while ((input = Console.ReadLine()) != "END")
            {
                string reservation = input;

                if(reservations.Contains(reservation))
                {
                    reservations.Remove(reservation);
                }
            }

            Console.WriteLine(reservations.Count);

            string[] vips = reservations.Where(x => char.IsDigit(x[0])).ToArray();
            string[] nonVips = reservations.Where(x => !char.IsDigit(x[0])).ToArray();

            foreach (string reservation in vips)
            {
                Console.WriteLine(reservation);
            }

            foreach (string reservation in nonVips)
            {
                Console.WriteLine(reservation);
            }
        }
    }
}
