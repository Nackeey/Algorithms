using System;

public class Startup
{
    private static void Sort(int[] arr, int startIndex, int endIndex)
    {
        if (startIndex >= endIndex)
        {
            return;
        }

        int midIndex = (startIndex + endIndex) / 2;

        Sort(arr, startIndex, midIndex);
        Sort(arr, midIndex + 1, endIndex);

        Merge(arr, startIndex, midIndex, endIndex);
    }

    private static void Merge(int[] arr, int startIndex, int midIndex, int endIndex)
    {
        if (midIndex < 0 || midIndex + 1 >= arr.Length || arr[midIndex] <= arr[midIndex + 1])
        {
            return;
        }

        int[] helpArr = new int[arr.Length];

        for (int i = startIndex; i <= endIndex; i++)
        {
            helpArr[i] = arr[i];
        }

        int leftIndex = startIndex;
        int rightIndex = midIndex + 1;

        for (int i = startIndex; i <= endIndex; i++)
        {
            if (leftIndex > midIndex)
            {
                arr[i] = helpArr[rightIndex++];
            }
            else if (rightIndex > endIndex)
            {
                arr[i] = helpArr[leftIndex++];
            }
            else if (helpArr[leftIndex] <= helpArr[rightIndex])
            {
                arr[i] = helpArr[leftIndex++];
            }
            else
            {
                arr[i] = helpArr[rightIndex++];
            }
        }
    }

    public static void Main()
    {
        var numbers = new[] { 5, 2, 8, 3, 1, 11, 4};

        Sort(numbers, 0, numbers.Length - 1);

       Console.WriteLine(string.Join(" ", numbers));
    }
}
