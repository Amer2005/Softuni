using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p06_StoreBoxes
{
    public class Item
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    public class Box : IComparable<Box>
    {
        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }

        public decimal BoxPrice { get; set; }

        public Box(string serialNumber, Item item, int quantity)
        {
            SerialNumber = serialNumber;
            Item = item;
            Quantity = quantity;

            BoxPrice = Item.Price * Quantity;
        }

        public int CompareTo(Box other)
        {
            return other.BoxPrice.CompareTo(this.BoxPrice);
        }

        public override string ToString()
        {
            StringBuilder value = new StringBuilder();

            value.Append($"{SerialNumber}\n");
            value.Append($"-- {Item.Name} - ${Item.Price:f2}: {Quantity}\n");
            value.Append($"-- ${BoxPrice:f2}");

            return value.ToString();
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var boxes = new List<Box>();

            string input;

            while((input = Console.ReadLine()) != "end")
            {
                string[] inputs = input.Split(' ');

                string serialNumber = inputs[0];
                string itemName = inputs[1];
                int itemQuantity = int.Parse(inputs[2]);
                decimal itemPrice = decimal.Parse(inputs[3]);

                boxes.Add(new Box(serialNumber, new Item(itemName, itemPrice), itemQuantity));
            }

            boxes.Sort();

            Console.WriteLine(String.Join("\n", boxes));
        }
    }
}
