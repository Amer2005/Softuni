using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CenturiesToMinutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigInteger centuries = BigInteger.Parse(Console.ReadLine());
            BigInteger years = centuries * 100;
            BigInteger days = (BigInteger)Math.Floor((decimal)years * 365.2422M);
            BigInteger hours = days * 24;
            BigInteger minutes = hours * 60;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}
