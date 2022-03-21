using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace p01_Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regexCommands = @">>(?<furnitureName>[A-Za-z0-9]+)<<(?<price>\d+[.]*[\d]*)!(?<quantity>\d+)";

            string input;

            StringBuilder textBuilder = new StringBuilder();

            while((input = Console.ReadLine()) != "Purchase")
            {
                textBuilder.AppendLine(input);
            }

            string text = textBuilder.ToString();

            Regex regex =  new Regex(regexCommands);

            var matches = regex.Matches(text);

            Console.WriteLine("Bought furniture");

            double totalPrice = 0;

            foreach (Match match in matches)
            {
                string furniture = match.Groups["furnitureName"].Value;
                double price = double.Parse(match.Groups["price"].Value);
                int quantity = int.Parse(match.Groups["quantity"].Value);

                Console.WriteLine(furniture);

                totalPrice += price * quantity;
            }

            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
