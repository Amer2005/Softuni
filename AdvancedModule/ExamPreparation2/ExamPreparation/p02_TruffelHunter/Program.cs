using System;
using System.Collections.Generic;
using System.Linq;

namespace p02_TruffelHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] board = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] boardRow = Console.ReadLine()
                    .Split(" ")
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    board[row, col] = boardRow[col];
                }
            }

            string input;

            Dictionary<char, int> trufflesCollected = new Dictionary<char, int>();

            trufflesCollected.Add('B', 0); // black truffels
            trufflesCollected.Add('S', 0); // summer truffels
            trufflesCollected.Add('W', 0); // whute truffels

            int totalCollectedByBoar = 0;

            while ((input = Console.ReadLine()) != "Stop the hunt")
            {
                string[] splittedInput = input.Split(' ');

                string command = splittedInput[0];

                int commandRow = int.Parse(splittedInput[1]);
                int commandCol = int.Parse(splittedInput[2]);

                if (command == "Collect")
                {
                    if (board[commandRow, commandCol] != '-')
                    {
                        trufflesCollected[board[commandRow, commandCol]]++;
                        board[commandRow, commandCol] = '-';
                    }
                }
                else if (command == "Wild_Boar")
                {
                    int boarRow = commandRow;
                    int boarCol = commandCol;

                    string direction = splittedInput[3];

                    while(AreIndexesValid(board, boarRow, boarCol))
                    {
                        if (board[boarRow, boarCol] != '-')
                        {
                            totalCollectedByBoar++;
                            board[boarRow, boarCol] = '-';
                        }

                        switch (direction)
                        {
                            case "up":
                                boarRow -= 2;
                                break;
                            case "down":
                                boarRow += 2;
                                break;
                            case "right":
                                boarCol += 2;
                                break;
                            case "left":
                                boarCol -= 2;
                                break;
                            default:
                                break;
                        }
                    }
                }


            }

            Console.WriteLine($"Peter manages to harvest {trufflesCollected['B']} black, {trufflesCollected['S']} summer, and {trufflesCollected['W']} white truffles.");
            Console.WriteLine($"The wild boar has eaten {totalCollectedByBoar} truffles.");
            PrintBoard(board);
        }

        static bool AreIndexesValid(char[,] matrix, int row, int col)
        {
            if (row < 0 || col < 0)
            {
                return false;
            }

            if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }

        static void PrintBoard(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

    }
}
