using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04_Orders
{
    public class Product
    {
        public Product(double price, int quantity)
        {
            Price = price;
            Quantity = quantity;
        }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }

    internal class Program
    {


        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string input;

            while ((input = Console.ReadLine()) != "buy")
            {
                string[] commands = input.Split(' ');

                string product = commands[0];
                double price = double.Parse(commands[1]);   
                int quantity = int.Parse(commands[2]);  

                if (products.ContainsKey(product))
                {
                    products[product].Price = price;
                    products[product].Quantity += quantity;
                }
                else
                {
                    products.Add(product, new Product(price, quantity));
                }
            }

            foreach (var productPricePair in products)
            {
                double totalProductPrice = productPricePair.Value.Price * productPricePair.Value.Quantity;

                Console.WriteLine($"{productPricePair.Key} -> {totalProductPrice:f2}");
            }
        }
    }
}
