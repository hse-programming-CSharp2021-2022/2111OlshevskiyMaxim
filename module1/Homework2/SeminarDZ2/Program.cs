using static System.Math;
using static System.Console;

namespace SeminarDZ2
{
    class Program
    {
        public static double GValue(double X, double Y)
        {
            if (X < Y && X > 0)
                return X + Sin(Y);
            else if (X > Y && X < 0)
                return Y - Cos(X);
            else
                return 0.5 * X * Y;
        }

        static void Main()
        {
            if (double.TryParse(ReadLine(), out double X) && double.TryParse(ReadLine(), out double Y))
                WriteLine($"{GValue(X, Y)}");
            else
                WriteLine("Error!");
        }
    }
}
