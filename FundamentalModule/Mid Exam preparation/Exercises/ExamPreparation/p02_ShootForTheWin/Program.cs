using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02_ShootForTheWin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string command;

            int targetsShotCount = 0;

            while ((command = Console.ReadLine()) != "End")
            {
                int targetIndex = int.Parse(command);

                if (targetIndex < 0 || targetIndex >= targets.Length)
                {
                    continue;
                }

                targetsShotCount++;

                int targetPoints = targets[targetIndex];

                targets[targetIndex] = -1;

                if (targetPoints < 0)
                {
                    continue;
                }

                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i] == -1)
                    {
                        continue;
                    }

                    if (targets[i] <= targetPoints)
                    {
                        targets[i] += targetPoints; 
                    }
                    else
                    {
                        targets[i] -= targetPoints;
                    }
                }
            }

            Console.WriteLine($"Shot targets: {targetsShotCount} -> {String.Join(" ", targets)}");
        }
    }
}
