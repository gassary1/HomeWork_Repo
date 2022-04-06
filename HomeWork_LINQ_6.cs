using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6
{
    //Существует класс солдата.В нём есть поля: имя, вооружение, звание, срок службы(в месяцах).
    //Написать запрос, при помощи которого получить набор данных состоящий из имени и звания.
    //Вывести все полученные данные в консоль.
    //(Не менее 5 записей)
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    enum Rank
    {
        Soldier,
    }

    class Warrior
    {
        private string _name;
        private string _lastName;
        private Rank _rank;

        public string Name => _name;
        public string LastName => _lastName;

        public Warrior(string name, string lastName, Rank rank)
        {
            _name = name;
            _lastName = lastName;
            _rank = rank;
        }

        public string GetRank()
        {
            switch (_rank)
            {
                case Rank.Soldier:
                    return "Рядовой";
                default:
                    return "-";
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine();
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

            };

            _lastNames = new string[]
            {

            };
        }

        public Squad(uint count)
        {
            _warriors = new List<Warrior>();

            for (int i = 0; i < count; i++)
            {
                _warriors.Add(new Warrior(_names[_random.Next(_names.Length)], _lastNames[_random.Next(_lastNames.Length)],
                    (Rank)_random.Next(Enum.GetValues(typeof(Rank)).Length)));
            }
        }

        public void PrintSquad()
        {
            Console.WriteLine();

            foreach (var warrior in _warriors)
            {
                warrior.ShowInfo();
            }
        }
    }
}
