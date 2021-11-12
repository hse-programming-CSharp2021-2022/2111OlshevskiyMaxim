using static System.Console;

namespace Seminar3
{
    abstract class Animal
    {
        public string Name { get; protected set; }
        public string Age { get; protected set; }
        public abstract string AnimalSound();
        public abstract string AnimalInfo();
    }

    sealed class Dog : Animal
    {
        public string Breed { get; private set; }
        public bool IsTrained { get; private set; }
        public Dog(string name, string age, string breed, bool isTrained) => (Name, Age, Breed, IsTrained) = (name, age, breed, isTrained);
        public override string AnimalSound() => "Гав.";
        public override string AnimalInfo() => $"Кличка: {Name}; Возраст: {Age}; Порода: {Breed}; Дрессирована: {IsTrained}.";
    }

    sealed class Cow : Animal
    {
        public int MilkPerDay { get; private set; }
        public Cow(string name, string age, int milkPerDay) => (Name, Age, MilkPerDay) = (name, age, milkPerDay);
        public override string AnimalSound() => "Му.";
        public override string AnimalInfo() => $"Кличка: {Name}; Возраст: {Age}; Количество молока в день: {MilkPerDay} литра.";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new("Бобик", "2 года", "Немецкая овчарка", true);
            Cow cow = new("Люся", "3 года", 2);
            WriteLine($"{dog.AnimalInfo()}\n{dog.AnimalSound()}");
            WriteLine($"{cow.AnimalInfo()}\n{cow.AnimalSound()}");
        }
    }
}
