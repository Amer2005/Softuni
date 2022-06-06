using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            dateModifier.SetTimeDifferenceInDays(firstDate, secondDate);

            Console.WriteLine(dateModifier.TimeDifferenceInDays);
        }
    }
}
