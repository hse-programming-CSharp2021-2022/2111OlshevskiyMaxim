using System;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{0.1 + 0.2}\n{(0.1 + 0.2):f1}\n{0.1m + 0.2m}\a\n");
            Console.WriteLine("{0.1 + 0.2}\n{(0.1 + 0.2):f1}\n{0.1m + 0.2m}\a\n");
            Console.WriteLine(@"{0.1 + 0.2}\n{(0.1 + 0.2):f1}\n{0.1m + 0.2m}\a\n");
        }
    }
}
