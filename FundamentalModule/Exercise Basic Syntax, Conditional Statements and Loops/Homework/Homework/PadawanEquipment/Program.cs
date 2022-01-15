using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int numberOfStudents = int.Parse(Console.ReadLine());
            double lightSaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double lighSaberTotalPrice = lightSaberPrice * (Math.Ceiling(numberOfStudents * 1.1));

            double totalBeltPrice = beltPrice * numberOfStudents - Math.Floor((double)numberOfStudents / 6) * beltPrice;

            double totalRobePrice = robePrice * numberOfStudents;

            double totalPrice = lighSaberTotalPrice + totalBeltPrice + totalRobePrice;

            if (money >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalPrice - money:f2}lv more.");
            }
        }
    }
}
