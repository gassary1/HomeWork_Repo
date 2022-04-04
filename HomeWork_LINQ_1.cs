using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository(10);
            repository.PrintRepository();
            Console.WriteLine();
            Console.WriteLine("После амнистии за преступления:");
            Repository amnestied = repository.ToAmnist();
            amnestied.PrintRepository();
        }
    }

    enum Crime
    {
        Murder,
        Theft,
        Hooliganism,
        Antigovernment
    }

    class Criminal
    {
        private string _name;
        private string _lastName;
        private Crime _crime;

        public string Name => _name;
        public string LastName => _lastName;

        public Criminal(string name, string lastName, Crime crime)
        {
            _name = name;
            _lastName = lastName;
            _crime = crime;
        }

        public string GetCrimeInfo()
        {
            switch (_crime)
            {
                case Crime.Murder:
                    return "Убийство";
                case Crime.Theft:
                    return "Кража";
                case Crime.Hooliganism:
                    return "Хулиганство";
                case Crime.Antigovernment:
                    return "Антиправительственное";
                default:
                    return "-";
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name,10} {LastName,10} {GetCrimeInfo(),30}");
        }
    }

    class Repository
    {
        private static Random _random;
        private static readonly string[] _names;
        private static readonly string[] _lastNames;
        private List<Criminal> _criminals;

        static Repository()
        {
            _random = new Random();

            _names = new string[]
            {
                "Ахмед",
                "Николай",
                "Олег",
                "Хуан",
                "Раджеш",
                "Алесандр",
                "Иничи",
                "Роберт",
                "Николас",
                "Патрик"
            };

            _lastNames = new string[]
            {
                "Ли",
                "Ким",
                "Никидзе",
                "Джексон",
                "Хирокава",
                "Абудаби",
                "Иванов",
                "Огурцов",
                "Нолан",
                "Пэг",
                "Кейдж"
            };
        }

        public Repository(uint count)
        {
            _criminals = new List<Criminal>();

            for (int i = 0; i < count; i++)
            {
                _criminals.Add(new Criminal(_names[_random.Next(_names.Length)], _lastNames[_random.Next(_lastNames.Length)],
                    (Crime)_random.Next(Enum.GetValues(typeof(Crime)).Length)));
            }
        }

        private Repository(List<Criminal> criminals)
        {
            _criminals=criminals;
        }

        public void PrintRepository()
        {
            Console.WriteLine($"{"Имя",10} {"Фамилия",10} {"Преступление",30}");

            foreach (var criminal in _criminals)
            {
                criminal.ShowInfo();
            }
        }

        public Repository ToAmnist()
        {
            List<Criminal> tempCriminals = _criminals.Where(criminal => criminal.GetCrimeInfo() != "Антиправительственное").ToList();
            return new Repository(tempCriminals);
        }
    }
}
