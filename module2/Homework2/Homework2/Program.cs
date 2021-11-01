using System;
using static System.Console;
public class ConsolePlate
{
    char _plateChar; // символ
    ConsoleColor _plateColor, _backgroundColor; // цвет символа
                                                   // конструкторы
    public ConsolePlate(char plateChar = 'A', ConsoleColor plateColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        this.PlateChar = plateChar; // используем свойства 
        this.PlateColor = plateColor;
        this.BackgroundColor = backgroundColor;
    }
    // Объявление свойств    

    public char PlateChar
    {
        set
        {
            if (value > 'A' && value <= 'Z') // отбрасываем командные символы
                _plateChar = value;
            else
                _plateChar = 'A';
        }
        get { return _plateChar; }
    }
    public ConsoleColor PlateColor
    {
        set { _plateColor = value; }
        get { return _plateColor; }
    }
    public ConsoleColor BackgroundColor
    {
        set { _backgroundColor = value; }
        get { return _backgroundColor; }
    }
}
class Program
{
    public static void PrintPlate(ConsolePlate cp)
    {
        ForegroundColor = cp.PlateColor;
        BackgroundColor = cp.BackgroundColor;
        Write(cp.PlateChar);
    }

    static void Main()
    {
        ConsolePlate x = new('X', ConsoleColor.White, ConsoleColor.Red);
        ConsolePlate o = new('O', ConsoleColor.White, ConsoleColor.Magenta);
        int n = int.Parse(ReadLine());
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < n; j += 2)
                {
                    PrintPlate(x);
                    if (j + 1 < n)
                        PrintPlate(o);
                }
            }
            else
            {
                for (int j = 0; j < n; j += 2)
                {
                    PrintPlate(o);
                    if (j + 1 < n)
                        PrintPlate(x);
                }
            }
            ResetColor();
            WriteLine();
        }
        
    }
}
