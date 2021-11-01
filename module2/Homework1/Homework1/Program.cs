using System;
using static System.Math;
using static System.Console;
class Program
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double x, double y) { X = x; Y = y; }
        public Point() : this(0, 0) { } // конструктор умолчания
                                        // СВОЙСТВО RO
                                        // СВОЙСТВО FI
        public string PointData
        {   // СВОЙСТВО 
            get
            {
                string maket = "X = {0:F2}; Y = {1:F2}; Ro = {2:F2}; Fi = {3:F2} ";
                return string.Format(maket, X, Y, Ro, Fi);
            }
        }
        public double Ro
        {
            get
            {
                if (X > 0 && Y >= 0)
                    return Atan(Y / X);
                if (X > 0 && Y < 0)
                    return Atan(Y / X) + 2 * PI;
                if (X < 0)
                    return Atan(Y / X) + PI;
                if (X == 0 && Y > 0)
                    return PI / 2;
                if (X == 0 && Y < 0)
                    return 3 * PI / 2;
                return 0;
            }
        }
        public double Fi
        {
            get
            {
                return Y * Y + X * X;
            }
        }


        static void Main()
        {
            Point a, b, c;
            a = new Point(3, 4);
            Console.WriteLine(a.PointData);
            b = new Point(0, 3);
            Console.WriteLine(b.PointData);
            c = new Point();
            double x = 0, y = 0;
            do
            {
                Console.Write("x = ");
                double.TryParse(Console.ReadLine(), out x);
                Console.Write("y = ");
                double.TryParse(Console.ReadLine(), out y);
                c.X = x; c.Y = y;
                if (Sqrt(c.Fi) < Sqrt(a.Fi) && Sqrt(c.Fi) < Sqrt(b.Fi))
                {
                    WriteLine(c.PointData);
                    WriteLine(b.PointData);
                    WriteLine(a.PointData);
                }
                else if (Sqrt(c.Fi) < Sqrt(a.Fi) && Sqrt(c.Fi) > Sqrt(b.Fi))
                {
                    WriteLine(b.PointData);
                    WriteLine(c.PointData);
                    WriteLine(a.PointData);
                }
                else
                {
                    WriteLine(b.PointData);
                    WriteLine(a.PointData);
                    WriteLine(c.PointData);
                }
            } while (x != 0 | y != 0);


        }
    }
}
