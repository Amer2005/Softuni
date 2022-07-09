using System;
using System.Collections.Generic;
using System.Linq;

namespace p03_ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] peopleArgs = Console.ReadLine()
                .Split(new char[] { ';', '=' });


            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            try
            {
                for (int i = 0; i < peopleArgs.Length; i += 2)
                {
                    people.Add(new Person(peopleArgs[i], decimal.Parse(peopleArgs[i + 1])));
                }

                string[] productArgs = Console.ReadLine()
                    .Split(new char[]{ ';', '='}, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < productArgs.Length; i += 2)
                {
                    products.Add(new Product(productArgs[i], decimal.Parse(productArgs[i + 1])));
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Environment.Exit(1);
            }

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string personName = input.Split(' ')[0];
                string productName = input.Split(' ')[1];

                Person person = people.FirstOrDefault(x => x.Name == personName);
                Product product = products.FirstOrDefault(x => x.Name == productName);

                Console.WriteLine(person.BuyProduct(product));
            }

            Console.WriteLine(String.Join(Environment.NewLine, people));
        }
    }
}
