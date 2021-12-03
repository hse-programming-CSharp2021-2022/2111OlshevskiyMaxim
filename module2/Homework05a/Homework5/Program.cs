using System;
using System.Collections.Generic;
using Task04Lib_Shape;
using static System.Console;

namespace Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new();
            int N1 = random.Next(3, 6), N2 = random.Next(3, 6), N3 = random.Next(3, 6), n1 = 0, n2 = 0, n3 = 0;
            List<int> sh = new() { 0, 1, 2 };
            Shape[] shapes = new Shape[N1 + N2 + N3];
            for (int i = 0; i < shapes.Length; i++)
            {
                if (n1 == N1)
                    sh.Remove(0);
                if (n2 == N2)
                    sh.Remove(1);
                if (n3 == N3)
                    sh.Remove(2);
                int rand = sh[random.Next(sh.Count)];
                if (rand == 0 && n1++ < N1)
                    shapes[i] = new Circle(random.Next(1, 100));
                else if (rand == 1 && n2++ < N2)
                    shapes[i] = new Cylinder(random.Next(1, 100), random.Next(1, 100));
                else if (rand == 2 && n3++ < N3)
                    shapes[i] = new Sphere(random.Next(1, 100));
                WriteLine(shapes[i]);
            }
            WriteLine("\nSorted:");
            Array.Sort(shapes);
            foreach (Shape shape in shapes)
                WriteLine(shape);
        }
    }
}
