using System;
using System.Linq;

namespace _05._Generating_Combinations
{
    public class Startup
    {
        private static void GenCombs(int[] set, int[] vector, int index, int border)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    GenCombs(set, vector, index + 1, i + 1);
                }
            }

        }

        public static void Main()
        {
            int[] elements = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int num = int.Parse(Console.ReadLine());

            int[] vector = new int[num];

            GenCombs(elements, vector, 0, 0);
        }
    }
}
