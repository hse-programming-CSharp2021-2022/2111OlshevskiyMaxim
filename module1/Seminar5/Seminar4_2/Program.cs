using static System.Console;
using static System.Math;

namespace Seminar4_2
{
    class Program
    {
        public static void SumFormula(int n)
        {
            double Sum = 0;
            for (int k = 1; k <= n; k++)
            {
                Sum += (k + 0.3) / (3 * Pow(k, 2) + 5);
                WriteLine($"{Sum}");
            }
        }

        static void Main()
        {
            WriteLine("Type an integer.");
            if (int.TryParse(ReadLine(), out int n) && n != 0)
            {
                SumFormula(n);
                WriteLine("Type \"again\" to go again. Type \"quit\" to quit.");
                string input = ReadLine();
                if (input.ToLower() == "again")
                    Main();
                else if (input.ToLower() == "quit")
                    return;
            }
            else
            {
                WriteLine("Error! Try again.");
                Main();
            }
        }
    }
}
