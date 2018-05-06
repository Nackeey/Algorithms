using System;

namespace Generating_01_Vectors
{
    public class Startup
    {
        private static void Gen01(int[] vector, int index)
        {
            if (index >= vector.Length)
            {
                PrintVector(vector);
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    vector[index] = i;
                    Gen01(vector, index + 1);
                }
            }
        }

        private static void PrintVector(int[] vector)
        {
            Console.WriteLine(string.Join("", vector));
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] vector = new int[n];

            Gen01(vector, 0);
        }
    }
}
