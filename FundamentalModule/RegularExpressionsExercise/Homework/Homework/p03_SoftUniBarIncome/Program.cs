using System;
using System.Text;
using System.Text.RegularExpressions;

namespace p03_SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input;

            StringBuilder textBuilder = new StringBuilder();

            while ((input = Console.ReadLine()) != "end of shift")
            {
                textBuilder.AppendLine(input);
            }

            string text = textBuilder.ToString();

            Regex regex = new Regex(@"%(?<customerName>[A-Z]{1}[a-z]+)%[^\|$%.0-9]*<(?<product>\w+)>[^\|$%.0-9]*\|(?<quantity>\d+)\|[^\|$%.0-9]*(?<price>\d+(.?\d+)?)\$");

            var matches = regex.Matches(text);

            double totalSum = 0;

            foreach (Match match in matches)
            {
                string customerName = match.Groups["customerName"].Value;
                string product = match.Groups["product"].Value;
                double price = double.Parse(match.Groups["price"].Value);
                int quantity = int.Parse(match.Groups["quantity"].Value);

                totalSum += price * quantity;

                Console.WriteLine($"{match.Groups["customerName"]}: {match.Groups["product"]} - {price * quantity:f2}");
            }
            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }
}
