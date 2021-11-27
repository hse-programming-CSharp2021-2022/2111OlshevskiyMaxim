using System.Text;
using static System.Console;

namespace TaskListSolution
{
    // Сиквел.
    // Разработчики из HSE company просят доработать ваше приложение!
    // Дело в том, что разработчики тоже ошибаются, и приходится откатывать приложение к предыдущей версии.
    // К тому же, HSE company не хочет расходовать много памяти,
    // поэтому было принято решение хранить только определенное колличество последних версий приложений.
    // 
    // На вход программе подаются запросы следующего типа:
    // 1) add <application_name> <version> - добавить актуальную версию приложения.
    // 2) back <application_name> - откатить приложение до предыдущей версии. Если предыдущей нет, то удалить приложение.
    // 3) get <application_name> - получить актуальную версию приложения. Если приложения нет, то сообщить об этом.
    // 4) exit - завершить программу.
    
    class Program
    {
        static void Main(string[] args)
        {
            RedisClient.Connect();
            Write(">");
            string input = ReadLine();
            while (input != "exit")
            {
                string[] split = input.Split(" ");
                if (split[0] == "add")
                {
                    if (RedisClient.Exist(split[1]))
                        WriteLine(RedisClient.GetSet(split[1], $"{split[2]} {RedisClient.Get(split[1])}").Split(' ')[0]);
                    else
                    {
                        RedisClient.Set(split[1], split[2]);
                        WriteLine($"{split[1]} {split[2]} added");
                    }
                }
                else if (split[0] == "back")
                {
                    string[] versions = RedisClient.Get(split[1]).Split(" ");
                    if (versions.Length == 1)
                        RedisClient.Delete(split[1]);
                    else
                        RedisClient.Set(split[1], string.Join(' ', versions[1..]));
                }
                else if (split[0] == "get")
                {
                    if (RedisClient.Exist(split[1]))
                        WriteLine(RedisClient.Get(split[1]).Split(' ')[0]);
                    else
                        WriteLine("No such app");
                }
                Write(">");
                input = ReadLine();
            }
        }
    }
}
