using System;
using static System.Console;
using static System.Array;

namespace Sem5
{
    class Program
    {
        // 3. Дан массив из 100 элементов не по порядку от 1 до 100, какой-то элемент повторяется дважды, а какого-то нет. Найти элемент, который повторяется дважды.
        // Считайте; что вы не знаете какой элемент удалён. Не использовать сортировку, вложенные циклы. Алгоритм должен быть линейным. Можно использовать доп массив, арифметические и бинарные операции
        static void Main(string[] args)
        {
            const int n = 100;
            int[] array = new int[n];
            Random random = new();
            int absentNumber = random.Next(1, n + 1), doubleNumber;
            while (true)
            {
                doubleNumber = random.Next(1, n + 1);
                if (absentNumber != doubleNumber)
                    break;
            }
            for (int i = 1, j = 0; i <= n; i++)
            {
                if (i != absentNumber)
                {
                    array[j] = i;
                    j++;
                    if (i == doubleNumber)
                    {
                        array[j] = i;
                        j++;
                    }
                }
            }
            for (int i = 1; i <= n; i++)
            {
                int[] find = FindAll(array, x => x == i);
                if (find.Length == 2)
                {
                    WriteLine(i);
                    break;
                }
            }
        }
    }
}
