using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Squad squad = new Squad(10);
            squad.PrintSquad();
            Console.WriteLine();
            squad.RequestInfo();
        }
    }

    enum Rank
    {
        Soldier,
        Corporal,
        Sergent,
        Ensign,
        Lieutenant
    }

    class Warrior
    {
        private string _name;
        private string _lastName;
        private uint _serviceTime;
        private Rank _rank;

        public string Name => _name;
        public string LastName => _lastName;
        public uint ServiceTime => _serviceTime;

        public Warrior(string name, string lastName, Rank rank, uint serviceTime)
        {
            _name = name;
            _lastName = lastName;
            _rank = rank;
            _serviceTime = serviceTime;
        }

        public string GetRank()
        {
            switch (_rank)
            {
                case Rank.Soldier:
                    return "Рядовой";
                case Rank.Corporal:
                    return "Ефрейтор";
                case Rank.Sergent:
                    return "Сержант";
                case Rank.Ensign:
                    return "Прапорщик";
                case Rank.Lieutenant:
                    return "Лейтенант";
                default:
                    return "-";
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name,10} {LastName,10} {GetRank(),10} {ServiceTime,10}");
        }
    }

    class Squad
    {
        private static Random _random;
        private static readonly string[] _names;
        private static readonly string[] _lastNames;
        private List<Warrior> _warriors;

        static Squad()
        {
            _random = new Random();

            _names = new string[]
            {
                "Иван",
                "Алексей",
                "Олег",
                "Вадим",
                "Сергей",
                "Дмитрий",
                "Денис",
                "Александр",
                "Игорь"
            };

            _lastNames = new string[]
            {
                "Иванов",
                "Ким",
                "Пак",
                "Стрельцов",
                "Кругликов",
                "Ермаков",
                "Чеплыгин",
                "Нельга",
                "Андро"
            };
        }

        public Squad(uint count)
        {
            _warriors = new List<Warrior>();

            for (int i = 0; i < count; i++)
            {
                _warriors.Add(new Warrior(_names[_random.Next(_names.Length)], _lastNames[_random.Next(_lastNames.Length)],
                    (Rank)_random.Next(Enum.GetValues(typeof(Rank)).Length), (uint)_random.Next(12, 48)));
            }
        }

        public void PrintSquad()
        {
            Header();

            foreach (var warrior in _warriors)
            {
                warrior.ShowInfo();
            }
        }

        public void RequestInfo()
        {
            var tempWarriors = _warriors.Select(warrior => new
            {
                Name = warrior.Name,
                LastName = warrior.LastName,
                Rank = warrior.GetRank()
            }).ToList();

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{"Имя",10} {"Фамилия",10} {"Звание",10}");
            Console.ResetColor();

            foreach (var warrior in tempWarriors)
            {
                Console.WriteLine($"{warrior.Name,10} {warrior.LastName,10} {warrior.Rank,10}");
            }
        }

        private void Header()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{"Имя",10} {"Фамилия",10} {"Звание",10} {"Срок службы",15}");
            Console.ResetColor();
        }
    }
}
