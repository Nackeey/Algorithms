using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Find_All_Paths_In_a_Labyrinth
{
    public class Startup
    {
        static char[,] labyrinth;
        static List<char> path = new List<char>();

        private static void Solve(int row, int col, char direction)
        {
            if (IsOutOfRange(row, col))
            {
                return;
            }

            path.Add(direction);

            if (IsExit(row, col))
            {
                PrintPath();
            }
            else if (IsPassable(row, col))
            {
                labyrinth[row, col] = 'x';

                Solve(row + 1, col, 'D'); //down
                Solve(row - 1, col, 'U'); //up
                Solve(row, col + 1, 'R'); //right
                Solve(row, col - 1, 'L'); //left

                labyrinth[row, col] = '-';
            }

            path.RemoveAt(path.Count - 1);
        }

        private static void PrintPath()
        {
            Console.WriteLine(string.Join("", path.Skip(1)));
        }

        private static bool IsPassable(int row, int col)
        {
            if (labyrinth[row, col] == 'x')
            {
                return false;
            }

            if (labyrinth[row, col] == '*')
            {
                return false;
            }

            return true;
        }

        private static bool IsExit(int row, int col)
        {
            return labyrinth[row, col] == 'e';
        }

        private static bool IsOutOfRange(int row, int col)
        {
            return row < 0
                || row >= labyrinth.GetLength(0)
                || col < 0
                || col >= labyrinth.GetLength(1);
        }

        private static char[,] GetLabyrinth()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            labyrinth = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var inputRow = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    labyrinth[row, col] = inputRow[col];
                }
            }

            return labyrinth;
        }

        public static void Main()
        {
            GetLabyrinth();
            Solve(0, 0, 'S');            
        }
    }
}
