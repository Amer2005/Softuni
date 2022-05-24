using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p05_ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            Dictionary<string, List<Item>> ShopsAndItems = new Dictionary<string, List<Item>>();

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] inputArgs = input
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                string shopName = inputArgs[0];
                string itemName = inputArgs[1];
                decimal itemPrice = decimal.Parse(inputArgs[2]);

                Item item = new Item(itemName, itemPrice);

                if (ShopsAndItems.ContainsKey(shopName))
                {
                    ShopsAndItems[shopName].Add(item);
                }
                else
                {
                    ShopsAndItems.Add(shopName, new List<Item> { item });
                }
            }

            foreach (var ShopAndItemsPair in ShopsAndItems.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{ShopAndItemsPair.Key}->");

                foreach (Item item in ShopAndItemsPair.Value)
                {
                    Console.WriteLine($"Product: {item.Name}, Price: {(double)item.Price}");
                }
            }
        }

        public class Item
        {
            public Item(string name, decimal price)
            {
                Name = name;
                Price = price;
            }

            public string Name { get; set; }

            public decimal Price { get; set; }
        }
    }
}
