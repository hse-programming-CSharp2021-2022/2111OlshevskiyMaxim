using static System.Math;
using static System.Console;

namespace SeminarDZ3
{
    class Program
    {
        public static double GValue(double X)
        {
            if (X <= 0.5)
                return Sin(PI / 2);
            else
                return Sin(PI * (X - 1) / 2);
        }

        static void Main()
        {
            if (double.TryParse(ReadLine(), out double X))
                WriteLine($"{GValue(X)}");
            else
                WriteLine("Error!");
        }
    }
}
