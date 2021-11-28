using System;
using System.IO;
using System.Collections.Generic;
using static System.Console;

namespace Homework7
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string s = null;
                WriteLine(s.Length);
            }
            catch (NullReferenceException exception)
            {
                WriteLine(exception.GetType());
            }
            try
            {
                string s = "abc";
                WriteLine(s[3]);
            }
            catch (IndexOutOfRangeException exception)
            {
                WriteLine(exception.GetType());
            }
            try
            {
                int a = 2000000000;
                int b = checked (a * 2);
            }
            catch (OverflowException exception)
            {
                WriteLine(exception.GetType());
            }
            try
            {
                int a = 0;
                int b = 1 / a;
            }
            catch (DivideByZeroException exception)
            {
                WriteLine(exception.GetType());
            }
            try
            {
                double a = 1.5;
                int b = int.Parse(a.ToString());
            }
            catch (FormatException exception)
            {
                WriteLine(exception.GetType());
            }
            try
            {
                string s = null;
                int b = int.Parse(s);
            }
            catch (ArgumentNullException exception)
            {
                WriteLine(exception.GetType());
            }
            try
            {
                StreamReader streamReader = new("kek");
            }
            catch (FileNotFoundException exception)
            {
                WriteLine(exception.GetType());
            }
            try
            {
                StreamReader streamReader = new("C:/a/a.txt");
            }
            catch (DirectoryNotFoundException exception)
            {
                WriteLine(exception.GetType());
            }
            try
            {
                StreamWriter streamWriter = new("a");
                StreamWriter streamWriter2 = new("a");
            }
            catch (IOException exception)
            {
                WriteLine(exception.GetType());
            }
            try
            {
                StreamWriter streamWriter = new("\\a");
            }
            catch (UnauthorizedAccessException exception)
            {
                WriteLine(exception.GetType());
            }
            try
            {
                throw new MyException();
            }
            catch (MyException exception)
            {
                WriteLine(exception.GetType());
            }
            // ОПАСНЫЙ КОД
            //try
            //{
            //    List<int> list = new();
            //    while (true)
            //        list.Add(int.MaxValue);
            //}
            //catch (OutOfMemoryException exception)
            //{
            //    WriteLine(exception.GetType());
            //}
            // ОПАСНЫЙ КОД
        }
    }

    class MyException : SystemException { }
}
