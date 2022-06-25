using System;
using System.Linq;

namespace p02_WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] wall = new char[n, n];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                string inputArgs = Console.ReadLine();

                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    wall[row, col] = inputArgs[col];

                    if (wall[row, col] == 'V')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string input;

            int holes = 1;
            int rods = 0;

            while ((input = Console.ReadLine()) != "End")
            {
                string result = Move(wall, ref playerRow, ref playerCol, input);

                if (result == "made hole")
                {
                    holes++;
                }
                if (result == "rip")
                {
                    holes++;

                    playerRow = -1;
                    playerCol = -1;

                    break;
                }
                if (result == "hit rod")
                {
                    rods++;

                    Console.WriteLine($"Vanko hit a rod!");
                }
                if (result == "there is hole")
                {
                    Console.WriteLine($"The wall is already destroyed at position [{playerRow}, {playerCol}]!");
                }

                //PrintWall(wall);
            }

            if (playerRow == -1)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rods} rod(s).");
            }

            PrintWall(wall);
        }

        static string Move(char[,] wall, ref int oldRow, ref int oldCol, string direction)
        {
            int newRow = oldRow;
            int newCol = oldCol;

            switch (direction)
            {
                case "up":
                    newRow--;
                    break;
                case "down":
                    newRow++;
                    break;
                case "right":
                    newCol++;
                    break;
                case "left":
                    newCol--;
                    break;
                default:
                    break;
            }

            if (!AreIndexesValid(wall, newRow, newCol))
            {
                return "nothing";
            }

            if (wall[newRow, newCol] == '-')
            {
                wall[oldRow, oldCol] = '*';
                wall[newRow, newCol] = 'V';

                oldRow = newRow;
                oldCol = newCol;

                return "made hole";
            }
            if (wall[newRow, newCol] == '*')
            {
                wall[oldRow, oldCol] = '*';
                wall[newRow, newCol] = 'V';

                oldRow = newRow;
                oldCol = newCol;

                return "there is hole";
            }
            if (wall[newRow, newCol] == 'C')
            {
                wall[oldRow, oldCol] = '*';
                wall[newRow, newCol] = 'E';

                oldRow = newRow;
                oldCol = newCol;

                return "rip";
            }
            if (wall[newRow, newCol] == 'R')
            {
                return "hit rod";
            }

            return "nothing";
        }

        static bool AreIndexesValid(char[,] wall, int row, int col)
        {
            if (row < 0 || col < 0)
            {
                return false;
            }

            if(row >= wall.GetLength(0) || col >= wall.GetLength(1))
            {
                return false;
            }

            return true;
        }

        static void PrintWall(char[,] wall)
        {
            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    Console.Write(wall[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
