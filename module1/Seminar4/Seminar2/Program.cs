using static System.Console;

namespace Seminar2
{
    class Program
    {
        public static void Sums(uint number, out uint sumEven, out uint sumOdd)
        {
            sumEven = 0;
            sumOdd = 0;
            while (number != 0)
            {
                sumEven += number % 10;
                number /= 10;
                sumOdd += number % 10;
                number /= 10;
            }
        }

        static void Main()
        {
            if (uint.TryParse(ReadLine(), out uint number))
            {
                Sums(number, out uint sumEven, out uint sumOdd);
                WriteLine($"{sumEven}\n{sumOdd}");
            }
        }
    }
}
