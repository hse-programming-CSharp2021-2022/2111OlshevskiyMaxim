using System;
using System.Text;
using static System.Math;

namespace FigureLibrary
{
    public class Point
    {
        public double X { get; private set; }

        public double Y { get; private set; }

        public Point(double x, double y) => (X, Y) = (x, y);

        public double Distance(Point other) => Sqrt(Pow(X - other.X, 2) + Pow(Y - other.Y, 2));

        public override string ToString() => $"({Round(X, 3)}, {Round(Y, 3)})";
    }

    public abstract class Figure
    {
        private readonly Point[] points;

        public double Length { get; protected set; }

        public abstract double Area { get; }

        public Figure(Point[] p)
        {
            points = new Point[p.Length];
            for (int i = 0; i < points.Length; i++)
                points[i] = p[i];
        }

        public bool Near(Figure other) => Center().Distance(other.Center()) <= Radius() + other.Radius();

        public Point Center()
        {
            double sumX = 0, sumY = 0;
            foreach (Point point in points)
            {
                sumX += point.X;
                sumY += point.Y;
            }
            return new(sumX / points.Length, sumY / points.Length);
        }

        public abstract double Radius();

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            char a = 'A';
            foreach (Point point in points)
                stringBuilder.Append($"{a++}{point}, ");
            stringBuilder.Append($"AB = {Length}, ");
            if (GetType().ToString() == "FigureLibrary.EqTriangle")
                stringBuilder.Append($"правильный треугольник, S = {Round(Area, 3)}");
            else
                stringBuilder.Append($"квадрат, S = {Round(Area, 3)}");
            return stringBuilder.ToString();
        }
    }

    class EqTriangle : Figure
    {
        public override double Area { get => Sqrt(3) * Pow(Length, 2) / 4; }

        public override double Radius() => 2 * Length / Sqrt(3);

        public static Point[] GetPoints(Point lowerLeft, double length)
        {
            Point[] trianglePoints = new Point[3];
            trianglePoints[0] = lowerLeft;
            trianglePoints[1] = new(lowerLeft.X + length, lowerLeft.Y);
            trianglePoints[2] = new(lowerLeft.X + length / 2, lowerLeft.Y + Sqrt(3) * length / 2);
            return trianglePoints;
        }

        public EqTriangle(Point lowerLeft, double length) : base(GetPoints(lowerLeft, length))
        {
            if (length < 0)
                throw new ArgumentException("Длина стороны не может быть отрицательной!");
            Length = length;
        }
    }

    class Square : Figure
    {
        public override double Area { get => Pow(Length, 2); }

        public override double Radius() => Length / Sqrt(2);

        public static Point[] GetPoints(Point lowerLeft, double length)
        {
            Point[] squarePoints = new Point[4];
            squarePoints[0] = lowerLeft;
            squarePoints[1] = new(lowerLeft.X + length, lowerLeft.Y);
            squarePoints[2] = new(lowerLeft.X + length, lowerLeft.Y + length);
            squarePoints[3] = new(lowerLeft.X, lowerLeft.Y + length);
            return squarePoints;
        }

        public Square(Point lowerLeft, double length) : base(GetPoints(lowerLeft, length))
        {
            if (length < 0)
                throw new ArgumentException("Длина стороны не может быть отрицательной!");
            Length = length;
        }
    }
}
