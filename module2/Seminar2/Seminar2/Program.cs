using System;

namespace Seminar2
{
    class MyComplex
    {
        double re, im;
        public MyComplex(double xre = 0, double xim = 0)
        { re = xre; im = xim; }
        public static MyComplex operator ++(MyComplex mc)
        { return new MyComplex(mc.re + 1, mc.im + 1); }
        public static MyComplex operator --(MyComplex mc)
        { return new MyComplex(mc.re - 1, mc.im - 1); }
        public static MyComplex operator +(MyComplex mc1, MyComplex mc2)
        { return new MyComplex(mc1.re + mc2.re, mc1.im + mc2.im); }
        public static MyComplex operator -(MyComplex mc1, MyComplex mc2)
        { return new MyComplex(mc1.re - mc2.re, mc1.im - mc2.im); }
        public static MyComplex operator *(MyComplex mc1, MyComplex mc2)
        { return new MyComplex(mc1.re * mc2.re - mc1.im * mc2.im, mc1.re * mc2.re + mc1.im * mc2.im); }
        public static MyComplex operator /(MyComplex mc1, MyComplex mc2)
        { return new MyComplex((mc1.re * mc2.re + mc1.im * mc2.im) / (mc2.re * mc2.re + mc2.im * mc2.im), (mc1.im * mc2.re - mc1.re * mc2.im) / (mc2.re * mc2.re + mc2.im * mc2.im)); }
        public double Mod() { return Math.Abs(re * re + im * im); }
        static public bool operator true(MyComplex f)
        {
            if (f.Mod() > 1.0) return true;
            return false;
        }
        static public bool operator false(MyComplex f)
        {
            if (f.Mod() <= 1.0) return true;
            return false;
        }
        public override string ToString()
        {
            return $"{this.re} + {this.im}i";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyComplex mc1 = new(3, 4);
            MyComplex mc2 = new(4, 3);
            Console.WriteLine(mc1 + mc2);
            Console.WriteLine(mc1 - mc2);
            Console.WriteLine(mc1 * mc2);
            Console.WriteLine(mc1 / mc2);
        }
    }
}
