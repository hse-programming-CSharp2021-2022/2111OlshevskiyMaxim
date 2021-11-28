using System;

namespace Cinderella
{
    public abstract class Something
    {
        private static readonly Random rand = new();

        public static Random Rand { get => rand; }
    }

    public class Lentil : Something
    {
        private readonly double weight = Rand.Next(2) + Rand.NextDouble();

        public double Weight { get => weight; }

        public override string ToString() => $"Lentil with weight {Weight}";
    }

    public class Ashes : Something
    {
        private readonly double volume = Rand.NextDouble();

        public double Volume { get => volume; }

        public override string ToString() => $"Ashes with volume {Volume}";
    }
}
