using System;

namespace Recursive_Factoriel
{
    public class Startup
    {
        static int Factoriel(int number)
        {            
            if (number == 1)
            {
                return number;
            }

            return number *= Factoriel(number - 1);
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Factoriel(n));
        }
    }
}
