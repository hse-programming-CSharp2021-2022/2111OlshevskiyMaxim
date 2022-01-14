using static System.Console;
using static System.Math;

namespace Seminar01a
{
    class Program
    {
        delegate int Cast(double a);

        public static int M1(double a) => (int)a % 2 == 0 ? (int)a : (int)a + 1;

        public static int M2(double a) => (int)Log10(a) + 1;

        static void Main(string[] args)
        {
            Cast cast1 = delegate (double a) { return (int)a % 2 == 0 ? (int)a : (int)a + 1; };
            Cast cast2 = a => (int)Log10(a) + 1;
            Cast cast3 = cast1 + cast2;
            Cast cast4 = M1;
            Cast cast5 = M2;
            Cast cast6 = cast4 + cast5;
            WriteLine($"{cast1(2.5)}\n{cast1(3.5)}\n{cast1(5.23)}\n{cast1(6.57)}\n\n" +
                $"{cast2(3.55)}\n{cast2(63.5)}\n{cast2(128.2)}\n\n" +
                $"{cast3?.Invoke(110.7)}\n\n***\n");
            cast3 -= a => (int)Log10(a) + 1;
            WriteLine($"{cast3?.Invoke(110.7)}\n\n" +
                $"{cast4?.Invoke(11.7)}\n\n" +
                $"{cast5?.Invoke(110.7)}\n\n" +
                $"{cast6?.Invoke(110.7)}\n\n***\n");
            cast6 -= M1;
            cast6 -= M2;
            WriteLine(cast6?.Invoke(110.7));
            cast6 += M1;
            cast6 += M2;
            foreach (Cast d in cast6.GetInvocationList())
            {
                WriteLine(d?.Invoke(110.7));
            }
        }
    }
}
