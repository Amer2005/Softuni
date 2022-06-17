using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace p02_BeaverAtWork
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char[,] pond = new char[n, n];

            Beaver beaver = new Beaver();

            int numberOfBranches = 0;

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                char[] pondRow = Console.ReadLine()
                    .Split(" ")
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    pond[row, col] = pondRow[col];

                    if (pond[row, col] == 'B')
                    {
                        beaver.Row = row;
                        beaver.Col = col;
                    }
                    if (pond[row, col] >= 'a' && pond[row, col] <= 'z')
                    {
                        numberOfBranches++;
                    }
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                if (numberOfBranches - beaver.BranchesCollected == 0)
                {
                    break;
                }

                MoveToCell(beaver, pond, command);
                //PrintPond(pond);
            }

            if (numberOfBranches - beaver.BranchesCollected == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {beaver.Branches.Count} wood branches: {string.Join(", ", beaver.Branches.Reverse())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {numberOfBranches - beaver.BranchesCollected} branches left.");
            }

            PrintPond(pond);

        }

        static void MoveToCell(Beaver beaver, char[,] pond, string direction)
        {
            if (direction == "up")
            {
                MoveToCell(beaver, pond, beaver.Row - 1, beaver.Col, direction);
            }
            else if (direction == "down")
            {
                MoveToCell(beaver, pond, beaver.Row + 1, beaver.Col, direction);
            }
            else if (direction == "left")
            {
                MoveToCell(beaver, pond, beaver.Row, beaver.Col - 1, direction);
            }
            else if (direction == "right")
            {
                MoveToCell(beaver, pond, beaver.Row, beaver.Col + 1, direction);
            }
        }

        static void MoveToCell(Beaver beaver, char[,] pond, int newRow, int newCol, string direction)
        {
            if(!AreIndexesValid(pond, newRow, newCol))
            {
                if (beaver.Branches.Count > 0)
                {
                    beaver.Branches.Pop();
                }

                return;
            }

            if (pond[newRow, newCol] != 'F')
            {
                if(char.IsLetter(pond[newRow, newCol]) && char.IsLower(pond[newRow, newCol]))
                {
                    beaver.Branches.Push(pond[newRow, newCol]);
                    beaver.BranchesCollected++;
                }

                pond[beaver.Row, beaver.Col] = '-';

                beaver.Row = newRow;
                beaver.Col = newCol;

                pond[beaver.Row, beaver.Col] = 'B';

                return;
            }
            else
            {
                pond[beaver.Row, beaver.Col] = '-';

                beaver.Row = newRow;
                beaver.Col = newCol;

                pond[beaver.Row, beaver.Col] = 'B';

                SwimInDirection(beaver, pond, direction);
            }

        }

        static void SwimInDirection(Beaver beaver, char[,] pond, string direction)
        {
            if (direction == "left")
            {
                if (beaver.Col == 0)
                {
                    SwimInDirection(beaver, pond, "right");

                    return;
                }

                MoveToCell(beaver, pond, beaver.Row, 0, "left");
                //yes
            }
            else if(direction == "right")
            {
                if (beaver.Col == pond.GetLength(1) - 1)
                {
                    SwimInDirection(beaver, pond, "left");

                    return;
                }

                MoveToCell(beaver, pond, beaver.Row, pond.GetLength(1) - 1, "right");
            }
            else if (direction == "up")
            {
                if (beaver.Row == 0)
                {
                    SwimInDirection(beaver, pond, "down");

                    return;
                }

                MoveToCell(beaver, pond, 0, beaver.Col, "up");
            }
            else if (direction == "down")
            {
                if (beaver.Row == pond.GetLength(0) - 1)
                {
                    SwimInDirection(beaver, pond, "up");

                    return;
                }

                MoveToCell(beaver, pond, pond.GetLength(0) - 1, beaver.Col, "down");
            }
        }

        static bool AreIndexesValid(char[,] pond, int row, int col)
        {
            if (row < 0 || col < 0)
            {
                return false;
            }

            if (row >= pond.GetLength(0) || col >= pond.GetLength(1))
            {
                return false;
            }

            return true;
        }

        static void PrintPond(char[,] pond)
        {
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    Console.Write(pond[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }

    public class Beaver
    {
        public Beaver()
        {
            Branches = new Stack<char>();
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public Stack<char> Branches { get; set; }

        public int BranchesCollected;
    }
}
