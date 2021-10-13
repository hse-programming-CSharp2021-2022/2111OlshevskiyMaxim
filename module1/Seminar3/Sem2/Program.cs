using System;

namespace Sem2
{
    class Program
    {
        static double Total(double k, double r, uint n)
        {
            return Math.Pow(1 + r, n) * k;
        }

        static void Main(string[] args)
        {
            double k = double.Parse(Console.ReadLine()), r = double.Parse(Console.ReadLine());
            uint n = uint.Parse(Console.ReadLine());
            for (uint i = 0; i <= n; i++)
            {
                Console.WriteLine(Total(k, r, i));
            }
        }
    }
}
