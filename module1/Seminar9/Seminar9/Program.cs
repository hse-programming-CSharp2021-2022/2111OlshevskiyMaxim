using System;
using System.IO;
using System.Text;
using static System.Console;
using System.Collections.Generic;

namespace ConsoleApp23
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Data.txt";

            // Создаем файл с данными
            // Сейчас данные для записи вбиты в коде
            // TODO1: сохранить в файл целые случайные значения из диапазона [10;100)
            WriteLine("Введите количество строчек, содержащих по 5 случайных элементов.");
            int amount = int.Parse(ReadLine());
            StringBuilder sb = new(amount);
            Random rand = new();
            for (int i = 0; i < amount; i++)
            {
                for (int j = 0; j < 5; j++)
                    sb.Append(rand.Next(10, 100) + " ");
                sb.Append("\n ");
            }
            sb.Remove(sb.Length - 1, 1);
            string createText = sb.ToString();
            File.WriteAllText(path, createText, Encoding.UTF8);

            // Open the file to read from
            if (File.Exists(path))
            {
                string readText = File.ReadAllText(path);
                string[] stringValues = readText.Split(' ');
                int[] arr = StringArrayToIntArray(stringValues);
                PrintArray(arr);

                // обрабатываем элементы массива
                // TODO2: Создать два массива по исходному
                // в первый поместить индексы чётных элементов, во второй - нечётных
                // TODO3: Заменяем все нечётные числа исходного массива нулями
                List<int> even = new();
                List<int> odd = new();
                int j = 0;
                foreach (int el in arr)
                {
                    if (el % 2 == 0)
                        even.Add(j);
                    else
                    {
                        odd.Add(j);
                        arr[j] = 0;
                    }
                    j++;
                }
                PrintArray(even.ToArray());
                PrintArray(odd.ToArray());
                PrintArray(arr);
            }
        } // end of Main()
        // преобразование массива строк в массив целых чисел
        public static int[] StringArrayToIntArray(string[] str)
        {
            List<int> listInt = new();
            for (int i = 0; i < str.Length; i += 6)
            {
                for (int j = 0; j < 5; j++)
                    listInt.Add(int.Parse(str[i + j]));
            }  
            return listInt.ToArray();
        } // end of StringToIntArray()

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i += 5)
            {
                for (int j = 0; j < 5; j++)
                    Write(array[i + j] + " ");
                WriteLine();
            }
            WriteLine();
        }
    } // end of Program
}
