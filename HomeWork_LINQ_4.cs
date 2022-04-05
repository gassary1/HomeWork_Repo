using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repositoryTopThree;
            Repository repository = new Repository(15);

            Console.WriteLine("Список игроков: \n");
            repository.PrintRepository();

            Console.WriteLine("\nТоп 3 игрока по силе: \n");
            repositoryTopThree = repository.RequestTopLevels();
            repositoryTopThree.PrintRepository();

            Console.WriteLine("\nТоп 3 игрока по уровню: \n");
            repositoryTopThree = repository.RequestTopStrengths();
            repositoryTopThree.PrintRepository();
        }
    }

    class Player
    {
        private static List<string> _names;
        private string _name;
        private uint _strength;
        private uint _level;

        public string Name => _name;
        public uint Strength => _strength;
        public uint Level => _level;

        static Player()
        {
            _names = new List<string>();
        }

        public Player(string name, uint strength, uint level)
        {
            _name = name;
            _strength = strength;
            _level = level;

            if (_name == string.Empty || Player._names.Contains(_name))
            {
                _name = $"{Guid.NewGuid().ToString().Substring(0, 5)}";
            }

            Player._names.Add(_name);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name,5} {Strength,5} {Level,5}");
        }
    }

    class Repository
    {
        private static Random _random;
        private List<Player> _players;

        static Repository()
        {
            _random = new Random();
        }

        public Repository(uint count)
        {
            _players = new List<Player>();

            for (int i = 0; i < count; i++)
            {
                _players.Add(new Player("", (uint)_random.Next(1, 30), (uint)_random.Next(1, 101)));
            }
        }

        private Repository(List<Player> players)
        {
            _players = players;
        }

        public void PrintRepository()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{"Имя",5} {"Сила",5} {"Уровень",5}");
            Console.ResetColor();

            foreach (var player in _players)
            {
                player.ShowInfo();
            }
        }

        public Repository RequestTopLevels()
        {
            List<Player> tempPlayers = _players.OrderByDescending(player => player.Level).Take(3).ToList();

            return new Repository(tempPlayers);
        }

        public Repository RequestTopStrengths()
        {
            List<Player> tempPlayers = _players.OrderByDescending(player => player.Strength).Take(3).ToList();

            return new Repository(tempPlayers);
        }
    }
}
