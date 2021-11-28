using System;
using FigureLibrary;
using static System.Console;
using static System.Math;

namespace Homework8
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new();
            while (true)
            {
                try
                {
                    Write("Введите количество фигур\n>");
                    Figure[] figures = new Figure[int.Parse(ReadLine())];
                    int rand;
                    WriteLine("Фигуры в массиве:");
                    for (int i = 0; i < figures.Length; i++)
                    {
                        rand = random.Next(2);
                        while (true)
                        {
                            try
                            {
                                if (rand == 0)
                                    figures[i] = new EqTriangle(new(random.Next(-50, 51), random.Next(-50, 51)), random.Next(-25, 26));
                                else
                                    figures[i] = new Square(new(random.Next(-50, 51), random.Next(-50, 51)), random.Next(-25, 26));
                                break;
                            }
                            catch { }
                        }
                        WriteLine(figures[i]);
                    }
                    rand = random.Next(2);
                    Figure figure;
                    while (true)
                    {
                        try
                        {
                            if (rand == 0)
                                figure = new EqTriangle(new(random.Next(-50, 51), random.Next(-50, 51)), random.Next(-25, 26));
                            else
                                figure = new Square(new(random.Next(-50, 51), random.Next(-50, 51)), random.Next(-25, 26));
                            break;
                        }
                        catch { }
                    }
                    WriteLine($"\nЕщё одна фигура:\n{figure}\n\nФигуры из массива, которые пересекаются с новой фигурой:");
                    double sum = 0, n = 0, min = int.MaxValue;
                    Square square = new(new(0, 0), 0);
                    foreach (Figure fig in figures)
                    {
                        if (figure.Near(fig))
                            WriteLine(fig);
                        if (fig.GetType().ToString() == "FigureLibrary.EqTriangle")
                        {
                            sum += fig.Area;
                            n++;
                        }
                        else if (fig.Area < min)
                        {
                            min = fig.Area;
                            square = fig as Square;
                        }
                    }
                    double average = sum / n;
                    if (n == 0)
                        WriteLine($"\nМинимальное значение площади квадрата: {min}\n{square}\n");
                    else if (min == int.MaxValue)
                        WriteLine($"\nCредняя площадь треугольников из массива: {Round(average, 3)}\n");
                    else
                        WriteLine($"\nCредняя площадь треугольников из массива: {Round(average, 3)}\n\nМинимальное значение площади квадрата: {min}\n{square}\n");
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            }
        }
    }
}
