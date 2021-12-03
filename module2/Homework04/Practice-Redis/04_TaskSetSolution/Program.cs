using static System.Console;

namespace TaskSetSolution
{
    // Сиквел.
    // У Склад.LIFE большое количество различных складов с различными видами товаров.
    // Руководству важно знать, какие виды товаров находятся на различных складах. Помогите Склад.LIFE. 
    // P.S. В последнее время с заказами все плохо, поэтому на склад только завозят новые виды товаров.
    //
    // На вход программе поступают следующие запросы:
    // 1) add <storage_name> <product_name> - добавить вид товара на склад.
    // 2) get <storage_name> - получить список всех видов товаров на складе.
    // 3) exist <storage_name> <product_name> - узнать находится ли вид товара на складе.
    // 4) exit - завершить программу.

    class Program
    {
        static void Main(string[] args)
        {
            RedisClient.Connect();
            try
            {
                Write(">");
                string input = ReadLine();
                while (input != "exit")
                {
                    string[] split = input.Split(" ");
                    if (split[0] == "add")
                        RedisClient.AddOne(split[1], split[2]);
                    else if (split[0] == "remove")
                        RedisClient.RemoveOne(split[1], split[2]);
                    else if (split[0] == "get")
                        foreach (string key in RedisClient.GetKeys(split[1]))
                            WriteLine(key);
                    else if (split[0] == "exist")
                        WriteLine(RedisClient.Exist(split[1], split[2]));
                    Write(">");
                    input = ReadLine();
                }
            }
            catch (System.Exception e)
            {
                WriteLine(e.Message);
            }
        }
    }
}
