using System;

namespace p09_ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Citizen citizen = new Citizen(inputArgs[0],
                                              inputArgs[1],
                                              int.Parse(inputArgs[2]));

                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
