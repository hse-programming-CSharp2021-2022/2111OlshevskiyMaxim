using System;
using System.Text;
using static System.Math;

namespace Homework5
{
    class Program
    {
        // 2. Написать метод ConvertHex2Bin(), выполняющий перевод шестнадцатеричного числа в двоичное. Заголовок метода следующий:
        // string ConvertHex2Bin(string HexNumber)
        // Здесь HexNumber – строка, представляющая шестнадцатеричное число, например 5A1.Функция должна возвращать строку с двоичным представлением числа. Например,
        // для шестнадцатеричного числа,представленного строкой 5A1 функция должна вернуть строку 10110100001.Показать работоспособность функции на трех примерах.
        // 32 бита

        public static string ConvertHex2Bin(string HexNumber)
        {
            long number = 0;
            for (int i = 0; i < HexNumber.Length; i++)
            {
                if (HexNumber[i] >= '0' && HexNumber[i] <= '9')
                    number += (HexNumber[i] - '0') * (long)Pow(16, HexNumber.Length - i - 1);
                else if (HexNumber[i] >= 'A' && HexNumber[i] <= 'F')
                    number += (HexNumber[i] - 'A' + 10) * (long)Pow(16, HexNumber.Length - i - 1);
            }
            if (number > 0)
            {
                StringBuilder binary = new(33);
                bool flag = false;
                for (int i = 32; i >= 0; i--)
                {
                    if (number - Pow(2, i) >= 0)
                    {
                        binary.Append('1');
                        number -= (long)Pow(2, i);
                        flag = true;
                    }
                    else if (flag)
                        binary.Append('0');
                }
                return binary.ToString();
            }
            return "0";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("HEX 5A1 = BIN " + ConvertHex2Bin("5A1"));
            Console.WriteLine("HEX AAAAAAAA = BIN " + ConvertHex2Bin("AAAAAAAA"));
            Console.WriteLine("HEX FFFFFFFF = BIN " + ConvertHex2Bin("FFFFFFFF"));
            Console.WriteLine("HEX DEAD = BIN " + ConvertHex2Bin("DEAD"));
            Console.WriteLine("HEX 0 = BIN " + ConvertHex2Bin("0"));
        }
    }
}
