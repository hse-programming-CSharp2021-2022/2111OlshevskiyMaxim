using System.Collections.Generic;
using Cinderella;
using static System.Console;

namespace Homework6
{
    class Program
    {
        static void Main(string[] args)
        {
            Something[] somethings = new Something[int.Parse(ReadLine())];
            List<Lentil> lentils = new();
            List<Ashes> ashes = new();
            for (int i = 0; i < somethings.Length; i++)
            {
                int rand = Something.Rand.Next(2);
                if (rand == 0)
                {
                    somethings[i] = new Lentil();
                    lentils.Add(somethings[i] as Lentil);
                }
                else
                {
                    somethings[i] = new Ashes();
                    ashes.Add(somethings[i] as Ashes);
                }
                WriteLine(somethings[i]);
            }
            WriteLine("\nLentils:");
            foreach (Lentil lentil in lentils)
                WriteLine(lentil);
            WriteLine("\nAshes:");
            foreach (Ashes ash in ashes)
                WriteLine(ash);
        }
    }
}
