using System;
using static System.Math;
using static System.Console;
using System.Collections.Generic;

namespace Seminar1
{
    class RegularPolygon
    {
        public int N { get; set; }

        public double InRadius { get; set; }

        public RegularPolygon(int n = 0, double r = 0) => (N, InRadius) = (n, r);

        // Округление до миллионных!
        public double P { get => Round(2 * InRadius * Tan(PI / N) * N, 6); }

        // Округление до миллионных!
        public double S { get => Round(P * InRadius / 2, 6); }

        public string PolygonData() => $"{N} {InRadius} {P} {S}";
    }

    class Program
    {
        public static void PrintAllData(List<RegularPolygon> rps, ref double sMin, ref double sMax)
        {
            for (int i = 0; i < rps.Count; i++)
            {
                Write($"{rps[i].N} {rps[i].InRadius} {rps[i].P} ");
                if (rps[i].S == sMax)
                    ForegroundColor = ConsoleColor.Green;
                else if (rps[i].S == sMin)
                    ForegroundColor = ConsoleColor.Red;
                WriteLine(rps[i].S);
                ResetColor();
            }
        }

        static void Main(string[] args)
        {
            List<RegularPolygon> rps = new();
            int i = -1;
            double sMin = double.MaxValue, sMax = 0;
            do
            {
                i++;
                rps.Add(new RegularPolygon(int.Parse(ReadLine()), double.Parse(ReadLine())));
                if (rps[i].S > sMax)
                    sMax = rps[i].S;
                if (rps[i].S < sMin)
                    sMin = rps[i].S;
                PrintAllData(rps, ref sMin, ref sMax);
            } while (rps[i].N > 0 || rps[i].InRadius > 0);
        }
    }
}
