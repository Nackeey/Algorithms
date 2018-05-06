using System;
using System.Linq;

namespace Recursive_Array_Sum
{
    public class Startup
    {
        private static int Sum(int[] arr, int index)
        {
            if (index == arr.Length - 1)
            {
                return arr[index];
            }

            return arr[index] += Sum(arr, index + 1);
        }

        public static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(Sum(arr, 0));
        }
    }
}
