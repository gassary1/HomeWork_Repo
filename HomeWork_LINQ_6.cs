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

    class Warrior
    {
        public string Name { get; }
        public string LastName { get; }
        public uint ServiceTime { get; }
        public string Rank { get; }

        public Warrior(string name, string lastName, string rank, uint serviceTime)
        {
            Name = name;
            LastName = lastName;
            Rank = rank;
            ServiceTime = serviceTime;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name,10} {LastName,10} {Rank,10} {ServiceTime,10}");
        }
    }

    class Squad
    {
        private static Random _random;
        private static readonly string[] _names;
        private static readonly string[] _lastNames;
        private static readonly string[] _ranks;
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
                "Андро",
                "Борисов",
                "Барецкий",
                "Бочкарев"
            };

            _ranks = new string[]
            {
                "Рядовой",
                "Ефрейтор",
                "Сержант",
                "Прапорщик",
                "Лейтенант"
            };
        }

        public Squad(uint count)
        {
            _warriors = new List<Warrior>();

            for (int i = 0; i < count; i++)
            {
                _warriors.Add(new Warrior(_names[_random.Next(_names.Length)], _lastNames[_random.Next(_lastNames.Length)],
                    _ranks[_random.Next(_ranks.Length)], (uint)_random.Next(12, 48)));
            }
        }

        public void PrintSquad()
        {
            ShowHeader();

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
                Rank = warrior.Rank
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

        private void ShowHeader()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{"Имя",10} {"Фамилия",10} {"Звание",10} {"Срок службы",15}");
            Console.ResetColor();
        }
    }
}
