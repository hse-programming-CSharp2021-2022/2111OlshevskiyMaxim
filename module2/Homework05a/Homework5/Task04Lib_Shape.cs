using System;

namespace Task04Lib_Shape
{
    public class Shape : IComparable
    {
        public const double PI = Math.PI;
        protected double _x, _y;

        public Shape() { }

        public Shape(double x, double y) => (_x, _y) = (x, y);

        public virtual double Area() => _x * _y;

        public override string ToString()
        {
            if (this is Circle)
                return $"Circle with area {(this as Circle).Area():f2}";
            else if (this is Cylinder)
                return $"Cylinder with area {(this as Cylinder).Area():f2}";
            else
                return $"Sphere with area {(this as Sphere).Area():f2}";
        }

        public int CompareTo(object shape)
        {
            int thisType = 0, shapeType = 0;
            if (this is Cylinder)
                thisType = 1;
            else if (this is Sphere)
                thisType = 2;
            if (shape is Cylinder)
                shapeType = 1;
            else if (shape is Sphere)
                shapeType = 2;
            return thisType.CompareTo(shapeType);
        }
    }

    public class Circle : Shape
    {
        public Circle(double r) : base(r, 0) { }

        public override double Area() => PI * _x * _x;
    }

    public class Sphere : Shape
    {
        public Sphere(double r) : base(r, 0) { }

        public override double Area() => 4 * PI * _x * _x;
    }

    public class Cylinder : Shape
    {
        public Cylinder(double r, double h) : base(r, h) { }

        public override double Area() => 2 * PI * _x * _x + 2 * PI * _x * _y;
    }
}
