using System;

namespace Seminar02
{
    public class UIString
    {
        public void NewStringValueHappenedHandler(object sender, MyArgs s) { str = s.S; }
        string str = "Default text";
        public string Str { get { return str; } private set { str = value; } }
    }
    class ConsoleUI
    {
        public event EventHandler<MyArgs> NewStringValueHappened;
        UIString s = new UIString(); // специальная строка
        public UIString S { get { return s; } set { s = value; } }
        public void GetStringFromUI()
        {
            Console.Write("Введите новое значение строки: ");
            string str = Console.ReadLine();
            MyArgs myArgs = new() { S = str };
            NewStringValueHappened?.Invoke(this, myArgs);
            RefreshUI();
        }
        public void CreateUI()
        {
            RefreshUI();
            NewStringValueHappened += s.NewStringValueHappenedHandler;
        }
        public void RefreshUI()
        {      // обновление строки     
            Console.Clear();
            Console.WriteLine("Текст строки: " + s.Str);
        }
    }

    public class MyArgs : EventArgs
    {
        public string S { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUI c = new ConsoleUI();
            c.CreateUI(); // запускаем выполнение объекта класса ConsoleUI
            do
            {
                c.GetStringFromUI();  // изменяем значение строки
                Console.WriteLine("Чтобы закончить эксперименты, нажмите ESC...");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
