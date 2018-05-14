using System;

namespace Bubble_Sort
{
    class Program
    {
        static int count = 0;

        static int Sort(int[] arr, int lo, int hi)
        {
            
            if (lo >= hi)
            {
                return count;
            }

            if (arr[lo] > arr[lo + 1])
            {
                count++;
                int rem = arr[lo];
                arr[lo] = arr[lo + 1];
                arr[lo + 1] = rem;
                lo = -1;
            }

            Sort(arr, lo + 1, hi);
           return count;
        }

        static void Main(string[] args)
        {
            var nums = new[] { 2, 4, 1, 3, 5 };

            int count = Sort(nums, 0, nums.Length - 1);

            Console.WriteLine(count);
        }
    }
}
