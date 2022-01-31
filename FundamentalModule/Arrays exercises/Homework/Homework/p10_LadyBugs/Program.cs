using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p10_LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            int[] ladyBugIndexes = Console.ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            int[] field = new int[fieldSize];

            for (int i = 0; i < ladyBugIndexes.Length; i++)
            {
                if(ladyBugIndexes[i] < 0 || ladyBugIndexes[i] >= fieldSize)
                {
                    continue;
                }

                field[ladyBugIndexes[i]] = 1;
            }

            string input = Console.ReadLine();

            while((input = Console.ReadLine()) != "end")
            {
                string[] inputs = input.Split(' ');

                int ladyBugPosition = int.Parse(inputs[0]);
                string direction = inputs[1];
                int distance = int.Parse(inputs[2]);

                if (ladyBugPosition < 0 || ladyBugPosition > field.Length - 1 || field[ladyBugPosition] == 0)
                {
                    continue;
                }

                field[ladyBugPosition] = 0;

                if (direction == "right")
                {
                    ladyBugPosition += distance;
                }
                else
                {
                    ladyBugPosition -= distance;
                }

                while (ladyBugPosition >= 0 && ladyBugPosition < field.Length)
                {
                    if (field[ladyBugPosition] == 0)
                    {
                        field[ladyBugPosition] = 1;
                        break;
                    }

                    if (direction == "right")
                    {
                        ladyBugPosition += distance;
                    }
                    else
                    {
                        ladyBugPosition -= distance;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}
