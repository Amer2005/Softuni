using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p07_KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());

            char[,] board = new char[boardSize, boardSize];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = input[col];
                }
            }

            int result = GetMinRemovalsNeeded(board);

            Console.WriteLine(result);
        }

        static int GetMinRemovalsNeeded(char[,] board)
        {
            int removalsNeeded = 0;

            int[,] movesBoard = new int[board.GetLength(0), board.GetLength(1)];

            UpdateMovesBoard(board, movesBoard);

            int maxNumber = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            do
            {
                maxNumber = int.MinValue;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (board[row, col] == '0')
                        {
                            continue;
                        }

                        if (movesBoard[row, col] > maxNumber)
                        {
                            maxNumber = movesBoard[row, col];
                            maxRow = row;
                            maxCol = col;
                        }
                    }
                }

                board[maxRow, maxCol] = '0';

                removalsNeeded++;

                UpdateMovesBoard(board, movesBoard);
            }
            while (maxNumber != 0);

            removalsNeeded--;

            return removalsNeeded;
        }

        static void UpdateMovesBoard(char[,] board, int[,] movesBoard)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    movesBoard[row, col] = 0;

                    if (board[row, col] == '0')
                    {
                        continue;
                    }

                    movesBoard[row, col] = CalculateNumberOfMoves(board, row, col);
                }
            }
        }

        static int CalculateNumberOfMoves(char[,] board, int row, int col)
        {
            int moves = 0;

            int newRow, newCol;

            newRow = row - 1;
            newCol = col + 2;

            if(AreCordsValid(board, newRow, newCol) && board[newRow, newCol] == 'K')
            {
                moves++;
            }

            newRow = row - 2;
            newCol = col + 1;

            if (AreCordsValid(board, newRow, newCol) && board[newRow, newCol] == 'K')
            {
                moves++;
            }

            newRow = row - 2;
            newCol = col - 1;

            if (AreCordsValid(board, newRow, newCol) && board[newRow, newCol] == 'K')
            {
                moves++;
            }

            newRow = row - 1;
            newCol = col - 2;

            if (AreCordsValid(board, newRow, newCol) && board[newRow, newCol] == 'K')
            {
                moves++;
            }

            newRow = row + 1;
            newCol = col - 2;

            if (AreCordsValid(board, newRow, newCol) && board[newRow, newCol] == 'K')
            {
                moves++;
            }

            newRow = row + 2;
            newCol = col - 1;

            if (AreCordsValid(board, newRow, newCol) && board[newRow, newCol] == 'K')
            {
                moves++;
            }

            newRow = row + 2;
            newCol = col + 1;

            if (AreCordsValid(board, newRow, newCol) && board[newRow, newCol] == 'K')
            {
                moves++;
            }

            newRow = row + 1;
            newCol = col + 2;

            if (AreCordsValid(board, newRow, newCol) && board[newRow, newCol] == 'K')
            {
                moves++;
            }

            return moves;
        }

        static bool AreCordsValid(char[,] board, int row, int col)
        {
            if (row < 0)
            {
                return false;
            }

            if (col < 0)
            {
                return false;
            }

            if (row >= board.GetLength(0))
            {
                return false;
            }

            if (col >= board.GetLength(1))
            {
                return false;
            }

            return true;
        }
    }
}
