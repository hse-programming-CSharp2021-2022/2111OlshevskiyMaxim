using System;
using static System.Console;

namespace Seminar02
{
    delegate void SquareSizeChanged(double a, double b);

    class Square
    {
        private Tuple<double, double> pointA;
        private Tuple<double, double> pointB;

        public Tuple<double, double> PointA
        {
            get => pointA;
            set
            {
                pointA = value;
                OnSizeChanged?.Invoke(pointB.Item1 - pointA.Item1, pointB.Item2 - pointA.Item2);
            }
        }

        public Tuple<double, double> PointB
        {
            get => pointB;
            set
            {
                pointB = value;
                OnSizeChanged?.Invoke(pointB.Item1 - pointA.Item1, pointB.Item2 - pointA.Item2);
            }
        }

        public Square(Tuple<double, double> a, Tuple<double, double> b) => (pointA, pointB) = (a, b);

        public event SquareSizeChanged OnSizeChanged;
    }

    class Program
    {
        public static void SquareConsoleInfo(double a, double b) => WriteLine("Длины сторон: {0:f2} и {1:f2}", a, b);

        static void Main(string[] args)
        {
            Write("Координаты верхнего левого угла через пробел: ");
            string[] split = ReadLine().Split(' ');
            Tuple<double, double> a = new(double.Parse(split[0]), double.Parse(split[1]));
            Write("Координаты правого нижнего угла через пробел: ");
            split = ReadLine().Split(' ');
            Tuple<double, double> b = new(double.Parse(split[0]), double.Parse(split[1]));
            Square s = new(a, b);
            s.OnSizeChanged += SquareConsoleInfo;
            while (true)
            {
                Write("Новые координаты правого нижнего угла через пробел: ");
                split = ReadLine().Split(' ');
                s.PointB = new(double.Parse(split[0]), double.Parse(split[1]));
                WriteLine("Нажмите клавишу ESC, если хотите выйти.");
                if (ReadKey().Key == ConsoleKey.Escape)
                    return;
            }
        }
    }
}
