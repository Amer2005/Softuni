using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p05_SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkedCars = new Dictionary<string, string>();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commands = Console.ReadLine().Split(' ');

                string action = commands[0];

                if (action == "register")
                {
                    string owner = commands[1];
                    string carPlate = commands[2];

                    RegisterCar(parkedCars, owner, carPlate);
                }
                else
                {
                    string owner = commands[1];

                    UnregisterCar(parkedCars, owner);
                }
            }

            foreach (var ownerPlatePair in parkedCars)
            {
                Console.WriteLine($"{ownerPlatePair.Key} => {ownerPlatePair.Value}");
            }
        }

        static void RegisterCar(Dictionary<string, string> parkedCars, string owner, string carPlate)
        {
            if (parkedCars.ContainsKey(owner))
            {
                Console.WriteLine($"ERROR: already registered with plate number {parkedCars[owner]}");

                return;
            }

            parkedCars.Add(owner, carPlate);

            Console.WriteLine($"{owner} registered {carPlate} successfully");
        }

        static void UnregisterCar(Dictionary<string, string> parkedCars, string owner)
        {
            if (!parkedCars.ContainsKey(owner))
            {
                Console.WriteLine($"ERROR: user {owner} not found");

                return;
            }

            parkedCars.Remove(owner);

            Console.WriteLine($"{owner} unregistered successfully");
        }
    }
}
