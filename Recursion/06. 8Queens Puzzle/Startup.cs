using System;
using System.Collections.Generic;

namespace _06._8Queens_Puzzle
{
    public class Startup
    {
        private const int Size = 8;
        static int counter = 0;
        static int[,] board = new int[Size, Size];

        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedCols = new HashSet<int>();        

        private static void Solve(int row)
        {
            if (row == Size)
            {
                PrintSolution();
                counter++;
                return;
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAtackedFields(row, col);
                        Solve(row + 1);
                        UnmarkAttackFields(row, col);
                    }
                }
            }

        }

        private static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (board[row, col] == 1)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void UnmarkAttackFields(int row, int col)
        {
            board[row, col] = 0;
            attackedRows.Remove(row);
            attackedCols.Remove(col);
        }

        private static void MarkAtackedFields(int row, int col)
        {
            board[row, col] = 1;
            attackedRows.Add(row);
            attackedCols.Add(col);
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            if (attackedRows.Contains(row) || attackedCols.Contains(col))   
            {
                return false; 
            }

            for (int i = 1; i < Size; i++)
            {
                int currentRow = row - i;
                int currentCol = col - i;


                if (currentRow < 0
                    || currentRow >= Size
                    || currentCol < 0 
                    || currentCol >= Size)
                {
                    break;
                }

                if (board[currentRow, currentCol] == 1)                                                        
                {
                    return false;
                }
            }

            for (int i = 1; i < Size; i++)
            {
                int currentRow = row - i;
                int currentCol = col + i;

                if (currentRow < 0
                    || currentRow >= Size
                    || currentCol < 0
                    || currentCol >= Size)
                {
                    break;
                }

                if (board[currentRow, currentCol] == 1)
                {
                    return false;
                }
            }

            for (int i = 1; i < Size; i++)
            {
                int currentRow = row + i;
                int currentCol = col - i;

                if (currentRow < 0
                    || currentRow >= Size
                    || currentCol < 0
                    || currentCol >= Size)
                {
                    break;
                }

                if (board[currentRow, currentCol] == 1)
                {
                    return false;
                }
            }

            for (int i = 1; i < Size; i++)
            {
                int currentRow = row + i;
                int currentCol = col + i;

                if (currentRow < 0
                    || currentRow >= Size
                    || currentCol < 0
                    || currentCol >= Size)
                {
                    break;
                }

                if (board[currentRow, currentCol] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        public static void Main()
        {
            Solve(0);
            Console.WriteLine(counter);
        }
    }
}
