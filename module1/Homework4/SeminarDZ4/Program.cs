using static System.Console;

namespace SeminarDZ4
{
    class Program
    {
        static void Main()
        {
            if (int.TryParse(ReadLine(), out int n))
            {
                int min = 100;
                int answer = 0;
                for (int i = 0; i < n; i++)
                {
                    if (int.TryParse(ReadLine(), out int x))
                    {
                        if (x / 10 % 10 * 10 + x % 10 < min)
                        {
                            min = x / 10 % 10 * 10 + x % 10;
                            answer = x;
                        }
                    }
                    else
                    {
                        WriteLine("Error!");
                        return;
                    }
                }
                WriteLine($"\n{answer}");
            }
            else
                WriteLine("Error!");
        }
    }
}
