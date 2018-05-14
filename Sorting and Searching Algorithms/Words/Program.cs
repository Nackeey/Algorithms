using System;
using System.Collections.Generic;
using System.Linq;

namespace Words
{
    class Program
    {
        static char[] elements;
        static int count;

        static void Gen(int index)
        {
            if (index >= elements.Length)
            {
                for (int i = 1; i < elements.Length; i++)
                {
                    if (elements[i] == elements[i - 1]) return;
                }

                count++;
            }
            else
            {
                HashSet<int> swapped = new HashSet<int>();
                for (int i = index; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        Swap(index, i);
                        Gen(index + 1);
                        Swap(index, i);
                        swapped.Add(elements[i]);
                    }
                }
            }
        }

        private static void Swap(int index, int i)
        {
            var temp = elements[index];
            elements[index] = elements[i];
            elements[i] = temp;
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            elements = input.ToCharArray();

            var unique = elements.Distinct().Count() == input.Length;

            if (unique)
            {
                count = 1;
                for (int i = 1; i <= input.Length; i++)
                {
                    count *= i;
                }
            }
            else
            {
                Gen(0);
            }

            Console.WriteLine(count);
        }
    }
}
