using System;
using System.Collections.Generic;
using System.Text;

public class Startup
{
    private static void Sort(int[] arr, int lo, int hi)
    {
        if (lo >= hi)
        {
            return;
        }

        int p = Partition(arr, lo, hi);

        Sort(arr, lo, p - 1);
        Sort(arr, p + 1, hi);
    }

    private static int Partition(int[] arr, int lo, int hi)
    {
        if (lo >= hi)
        {
            return lo;
        }

        int i = lo;
        int j = hi + 1;
        while (true)
        {
            while (arr[++i] < arr[lo])
            {
                if (i == hi) break;
            }

            while (arr[lo] < arr[--j])
            {
                if (j == lo) break;
            }

            if (i >= j) break;

            Swap(arr, i, j);
        }

        Swap(arr, lo, j);

        return j;
    }

    private static void Swap(int[] arr, int i, int j)
    {
        int rem = arr[i];
        arr[i] = arr[j];
        arr[j] = rem;
    }

    public static void Main()
    {
        var numbers = new[] { 10, 9, 7, 8, 5, 4, -2, 1, 3};

        Sort(numbers, 0, numbers.Length - 1);
        Console.WriteLine(string.Join(" ", numbers));
    }
}

