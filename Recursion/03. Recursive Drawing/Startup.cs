using System;

namespace Recursive_Drawing
{
    public class Startup
    {
        static void PringFigure(int n)
        {
            if (n == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', n));

            PringFigure(n - 1);            

            Console.WriteLine(new string('#', n));       
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            PringFigure(n);
        }
    }
}
