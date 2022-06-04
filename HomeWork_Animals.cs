using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    //Пользователь запускает приложение и перед ним находится меню, в котором он может выбрать, к какому вольеру подойти.
    //При приближении к вольеру, пользователю выводится информация о том, что это за вольер, сколько животных там обитает, их пол и какой звук издает животное.
    //Вольеров в зоопарке может быть много, в решении нужно создать минимум 4 вольера.
    class Program
    {
        static void Main(string[] args)
        {
            bool isActive = true;
            string userInput;
            int currentPosition;
            Aviary currentAviary = null;

            Zoo zoo = new Zoo();

            while (isActive)
            {
                zoo.ShowListOfAviaries();

                Console.Write("\nВведите номер вольера (наберите exit, чтобы выйти): ");
                userInput = Console.ReadLine();

                Console.Clear();

                if (int.TryParse(userInput, out currentPosition))
                {
                    if (zoo.TryGetAviary(currentPosition, out currentAviary))
                    {
                        currentAviary.ShowAviaryInfo();
                    }
                    else
                    {
                        Console.WriteLine("Вольер не найден");
                    }
                }
                else if (userInput == "exit")
                {
                    isActive = false;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода");
                }
            }
        }
    }

    abstract class Animal
    {
        private const byte MinAge = 1;
        private const byte MaxAge = 20;

        private static Random _random;
        private byte _age;

        static Animal()
        {
            _random = new Random();
        }

        public Animal()
        {
            _age = Convert.ToByte(_random.Next(MinAge, MaxAge));
        }

        public string ShowAnimalInfo()
        {
            return $"{GetType().Name,5} | {_age,12} | {Voice(),5}";
        }

        private string Voice()
        {
            switch (GetType().Name)
            {
                case "Horse":
                    return "Фррр";
                case "Sheep":
                    return "Бееее";
                case "Duck":
                    return "Кря-кря";
                case "Lion":
                    return "Кхрааа";
                case "Tiger":
                    return "Рррррр";
                default:
                    return " ";
            }
        }
    }

    class Horse : Animal
    {
        public Horse()
        {

        }
    }

    class Sheep : Animal
    {
        public Sheep()
        {

        }
    }

    class Duck : Animal
    {
        public Duck()
        {

        }
    }

    class Lion : Animal
    {
        public Lion()
        {

        }
    }

    class Tiger : Animal
    {
        public Tiger()
        {

        }
    }

    class Aviary
    {
        private const int MinCountOfAnimals = 2;
        private const int MaxCountOfAnimals = 9;

        private static Random _random;
        private List<Animal> _animals;

        public string Name { get; }
        public int CountOfAnimals => _animals.Count;

        static Aviary()
        {
            _random = new Random();
        }

        public Aviary(string name)
        {
            Name = name;
            _animals = new List<Animal>();

            CreateAnimals();
        }

        public void ShowAviaryInfo()
        {
            Console.WriteLine($"Вольер - {Name}");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{"Вид",5} | {"Возраст, лет",5} | {"Звук",5}");
            Console.ResetColor();

            foreach (var animal in _animals)
            {
                Console.WriteLine($"{animal.ShowAnimalInfo()}");
            }

            Console.WriteLine($"Количество животных - {CountOfAnimals}");
        }

        private void CreateAnimals()
        {
            for (int i = 0; i < _random.Next(MinCountOfAnimals, MaxCountOfAnimals); i++)
            {
                switch (_random.Next(1, 6))
                {
                    case 1:
                        _animals.Add(new Horse());
                        break;
                    case 2:
                        _animals.Add(new Sheep());
                        break;
                    case 3:
                        _animals.Add(new Duck());
                        break;
                    case 4:
                        _animals.Add(new Lion());
                        break;
                    case 5:
                        _animals.Add(new Tiger());
                        break;
                }
            }
        }
    }

    class Zoo
    {
        private const int MinCountOfAnimals = 3;
        private const int MaxCountOfAnimals = 7;

        private static Random _random;
        private List<Aviary> _aviaries;

        static Zoo()
        {
            _random = new Random();
        }

        public Zoo()
        {
            _aviaries = new List<Aviary>();

            CreateAviaries();
        }

        public bool TryGetAviary(int currentPosition, out Aviary aviary)
        {
            int aviaryPosition = currentPosition - 1;
            aviary = null;

            if (currentPosition < 0 || currentPosition > _aviaries.Count|| _aviaries[aviaryPosition] == null)
            {
                return false;
            }

            aviary = _aviaries[aviaryPosition];
            return true;
        }

        public void ShowListOfAviaries()
        {
            Console.WriteLine("Список вольеров");

            foreach (Aviary aviary in _aviaries)
            {
                Console.WriteLine(aviary.Name);
            }
        }

        private void CreateAviaries()
        {
            for (int i = 1; i <= _random.Next(MinCountOfAnimals, MaxCountOfAnimals); i++)
            {
                _aviaries.Add(new Aviary($"Вольер - {i}"));
            }
        }
    }
}
