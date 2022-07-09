using System;

namespace p04_PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;

            input = Console.ReadLine();

            string[] inputArgs;

            inputArgs = input.Split(' ');

            if (inputArgs.Length != 2)
            {
                Console.WriteLine("Pizza name should be between 1 and 15 symbols.");
                Environment.Exit(1);
            }

            Pizza pizza = new Pizza("Default"); ;

            try
            {
                pizza = new Pizza(inputArgs[1]);

                input = Console.ReadLine();
                inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string flourType = inputArgs[1].ToLower();
                string bakingMethod = inputArgs[2].ToLower();
                decimal grams = decimal.Parse(inputArgs[3]);

                Dough dough = new Dough(flourType, bakingMethod, grams);

                pizza.Dough = dough;

                while ((input = Console.ReadLine()) != "END")
                {
                    inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string ingredientType = inputArgs[0];

                    if (ingredientType == "Topping")
                    {
                        string type = inputArgs[1];
                        decimal toppingGrams = decimal.Parse(inputArgs[2]);

                        Topping topping = new Topping(type, toppingGrams);

                        pizza.AddTopping(topping);
                    }
                }
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Environment.Exit(1);
            }

            Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
        }
    }
}
