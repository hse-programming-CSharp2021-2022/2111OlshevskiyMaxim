using static System.Math;
using static System.Console;

namespace SeminarDZ1
{
    class Program
    {
        public static bool PointInSector(int x, int y)
        {
            if (Pow(x, 2) + Pow(y, 2) <= 4 && y <= x && x >= 0)
                return true;
            else
                return false;
        }

        static void Main()
        {
            if (int.TryParse(ReadLine(), out int x) && int.TryParse(ReadLine(), out int y))
                WriteLine($"{PointInSector(x, y)}");
            else
                WriteLine("Error!");
        }
    }
}
