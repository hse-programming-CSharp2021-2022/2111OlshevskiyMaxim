using System;
using System.Collections.Generic;
using static System.Console;

namespace Homework9
{
    abstract class Person
    {
        private string name;
        private string pocket;
        public static readonly Random rand = new();

        public string Name
        {
            set => name = value;
            get => name;
        }

        public string Pocket
        {
            set => pocket = value;
            get => pocket;
        }

        public Person(string name) => Name = name;

        public abstract void Receive(string present);

        public override string ToString() => $"{Name} получил(а) подарок {Pocket}";
    }

    class SnowMaiden : Person
    {
        public SnowMaiden(string name) : base(name) { }

        public string[] CreatePresents(int amount)
        {
            string[] presents = new string[amount];
            for (int i = 0; i < amount; i++)
            {
                string a = ((char)rand.Next('a', 'z' + 1)).ToString();
                string b = ((char)rand.Next('a', 'z' + 1)).ToString();
                string c = ((char)rand.Next('a', 'z' + 1)).ToString();
                presents[i] = a + b + c + b + a;
            }
            return presents;
        }

        public override void Receive(string present)
        {
            if (Pocket != null)
                throw new ArgumentException("Снегурочка была поймана на попытке получить второй подарок!");
            Pocket = present;
        }
    }

    class Santa : Person
    {
        private List<string> sack;

        public Santa(string name) : base(name) { }

        public void Request(SnowMaiden snowMaiden, int amount) => sack = new(snowMaiden.CreatePresents(amount));

        public void Give(Person person)
        {
            if (sack.Count == 0)
                throw new Exception("Мешок Санты пуст!");
            int index = rand.Next(sack.Count);
            person.Receive(sack[index]);
            sack.RemoveAt(index);
        }

        public override void Receive(string present)
        {
            if (Pocket != null)
                throw new ArgumentException("Санта был пойман на попытке получить второй подарок!");
            Pocket = present;
        }
    }

    class Child : Person
    {
        private string additionalPocket;

        public Child(string name) : base(name) { }

        public override void Receive(string present)
        {
            if (Pocket == null)
                Pocket = present;
            else if (additionalPocket == null)
                additionalPocket = present;
            else
                throw new ArgumentException($"{Name} был(а) пойман(а) на попытке получить третий подарок!");
        }

        public override string ToString()
        {
            if (additionalPocket == null)
                return $"{Name} получил(а) подарок {Pocket}";
            return $"{Name} получил(а) подарок {additionalPocket}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Santa santa = new("Санта");
            SnowMaiden snowMaiden = new("Снегурочка");
            List<Person> people = new()
            {
                santa,
                snowMaiden,
                new Child("Артём"),
                new Child("Андрей"),
                new Child("Артемий"),
                new Child("Александр"),
                new Child("Алексей"),
                new Child("Анастасия"),
                new Child("Ася"),
                new Child("Аполлинария"),
                new Child("Анна"),
                new Child("Алиса")
            };
            santa.Request(snowMaiden, Person.rand.Next(1, 5));
            int index = 0;
            bool flag = true;
            while (people.Count != 1)
            {
                try
                {

                    index = Person.rand.Next(people.Count);
                    santa.Give(people[index]);
                    WriteLine(people[index]);
                    if (flag)
                        santa.Request(snowMaiden, Person.rand.Next(1, 5));

                }
                catch (ArgumentException e)
                {
                    WriteLine(e.Message);
                    if (e.Message == "Снегурочка была поймана на попытке получить второй подарок!")
                        flag = false;
                    else if (e.Message == "Санта был пойман на попытке получить второй подарок!")
                        return;
                    people.RemoveAt(index);
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                    return;
                }
            }
            WriteLine("Остался только Санта!");
        }
    }
}
