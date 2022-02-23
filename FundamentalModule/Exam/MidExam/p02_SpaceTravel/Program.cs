using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02_SpaceTravel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] commands = Console.ReadLine().Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            int fuel = int.Parse(Console.ReadLine());
            int ammo = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands.Length; i++)
            {
                string[] command = commands[i].Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);

                string action = command[0];

                if (action == "Travel")
                {
                    int distance = int.Parse(command[1]);

                    if (fuel >= distance)
                    {
                        Console.WriteLine($"The spaceship travelled {distance} light-years.");

                        fuel -= distance;

                        continue;
                    }

                    Console.WriteLine("Mission failed.");

                    return;
                }
                else if (action == "Enemy")
                {
                    int enemyArmour = int.Parse(command[1]);

                    if(ammo >= enemyArmour)
                    {
                        Console.WriteLine($"An enemy with {enemyArmour} armour is defeated.");

                        ammo -= enemyArmour;

                        continue;
                    }
                    else if (fuel >= enemyArmour * 2)
                    {
                        Console.WriteLine($"An enemy with {enemyArmour} armour is outmaneuvered.");

                        fuel -= enemyArmour * 2;

                        continue;
                    }

                    Console.WriteLine("Mission failed.");

                    return;
                }
                else if (action == "Repair")
                {
                    int refillAmount = int.Parse(command[1]);

                    ammo += refillAmount * 2;
                    fuel += refillAmount;

                    Console.WriteLine($"Ammunitions added: {refillAmount * 2}.");
                    Console.WriteLine($"Fuel added: {refillAmount}.");
                }
                else
                {
                    Console.WriteLine("You have reached Titan, all passengers are safe.");

                    return;
                }
            }

            Console.WriteLine("You have reached Titan, all passengers are safe.");
        }
    }
}
