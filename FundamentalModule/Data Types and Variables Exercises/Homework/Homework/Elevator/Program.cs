using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            int capacity = int.Parse(Console.ReadLine());

            int trips = numberOfPeople / capacity;
            trips += numberOfPeople % capacity > 0 ? 1 : 0;

            Console.WriteLine(trips);
        }
    }
}
