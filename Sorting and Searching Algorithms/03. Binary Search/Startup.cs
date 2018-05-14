using System;

namespace _03._Binary_Search
{
    public class Startup
    {
        private static int IndexOf(int[] arr, int key)
        {
            int lo = 0;
            int hi = arr.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (key < arr[mid])
                {
                    hi = mid - 1;
                }
                else if (key > arr[mid])
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }

        public static void Main()
        {
            var nums = new[] { 1, 2, 3, 4, 5, 6, 7 };

            var index = IndexOf(nums, 7);

            Console.WriteLine(index);
        }
    }
}
