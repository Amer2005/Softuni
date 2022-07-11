using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;

            List<IIdentifiable> inhabitants = new List<IIdentifiable>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IIdentifiable inhabitant;

                if (inputArgs.Length == 3)
                {
                    inhabitant = new Citizen(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]);
                }
                else
                {
                    inhabitant = new Robot(inputArgs[0], inputArgs[1]);
                }

                inhabitants.Add(inhabitant);
            }

            string checkNum = Console.ReadLine();

            foreach (var inhabitant in inhabitants)
            {
                if (inhabitant.IsIdFake(checkNum))
                {
                    Console.WriteLine(inhabitant.Id);
                }
            }
        }
    }
}
