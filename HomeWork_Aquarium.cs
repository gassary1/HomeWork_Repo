using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();
            aquarium.ManageAquarium();
        }
    }

    class Fish
    {
        private const int MinFishAge = 1;
        private const int MaxFishAge = 7;

        private static List<string> _dataBaseOfNames;
        private static Random _random;
        private int _age;
        private string _name;

        public string Name => _name;
        public int Age => _age;
        public string LiveStatus => _age > MaxFishAge ? "Мертва" : "Живая";

        static Fish()
        {
            _random = new Random();
            _dataBaseOfNames = new List<string>();
        }

        public Fish(string name)
        {
            _age = _random.Next(MinFishAge, MaxFishAge);

            if (name == string.Empty || Fish._dataBaseOfNames.Contains(name))
            {
                name = $"{Guid.NewGuid().ToString().Substring(0, 5)}";
            }

            _name = name;
            _dataBaseOfNames.Add(name);
        }

        public Fish() : this("")
        {

        }

        public bool IsDied()
        {
            return _age > MaxFishAge;
        }

        public void ShowFishInfo()
        {
            Console.WriteLine($"{Name,9} | {Age,7} | {LiveStatus}");
        }

        public void AddAge()
        {
            _age++;

            if (_age > MaxFishAge)
            {
                DieMessage();
            }
        }

        private void DieMessage()
        {
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Name} - умерла");
            Console.ResetColor();
        }
    }

    class Aquarium
    {
        private const int MinCountOfFish = 7;
        private const int MaxCountOfFish = 15;

        private static Random _random;
        private List<Fish> _fishes;

        static Aquarium()
        {
            _random = new Random();
        }

        public Aquarium()
        {
            _fishes = new List<Fish>();

            CreateFish();
        }

        public void ManageAquarium()
        {
            bool isActive = true;
            string userInput;

            while (isActive)
            {
                ShowAquariomInfo();

                Console.WriteLine("\n1-Добавить рыбу, 2-Убрать рыбу 3- Выйти\n");
                Console.Write("Выберите действие: ");

                userInput = Console.ReadLine();

                Console.Clear();

                switch (userInput)
                {
                    case "1":
                        AddFish();
                        break;
                    case "2":
                        RemoveFish();
                        break;
                    case "3":
                        isActive = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка ввода");
                        break;
                }

                foreach (var fish in _fishes)
                {
                    fish.AddAge();
                }
            }
        }

        public void ShowAquariomInfo()
        {
            DeleteDeathFishes();

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{"Имя рыбки"} | {"Возраст"} | {"Статус"}");
            Console.ResetColor();

            foreach (var fish in _fishes)
            {
                fish.ShowFishInfo();
            }
        }

        private void AddFish()
        {
            _fishes.Add(new Fish());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Рыбка {_fishes[_fishes.Count - 1].Name} добавлена");
            Console.ResetColor();
        }

        private void RemoveFish()
        {
            int currentPosition;
            int fishPosition;

            if (_fishes.Count > 0)
            {
                Console.WriteLine("Введите номер рыбки, которую хотите убрать");

                while (int.TryParse(Console.ReadLine(), out fishPosition))
                {
                    currentPosition = fishPosition - 1;

                    if (currentPosition >= 0 && currentPosition < _fishes.Count)
                    {
                        _fishes.RemoveAt(currentPosition);
                    }
                    else
                    {
                        Console.WriteLine("Такой рыбки нет");
                    }
                }
            }
        }

        private void CreateFish()
        {
            for (int i = 0; i < _random.Next(MinCountOfFish, MaxCountOfFish); i++)
            {
                _fishes.Add(new Fish());
            }
        }

        private void DeleteDeathFishes()
        {
            _fishes.RemoveAll(fish => fish.IsDied() == true);
        }
    }
}
