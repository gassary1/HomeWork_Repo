using System;
using System.Collections.Generic;

namespace HomeWork_30
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNotes;
            bool isActive = true;
            ConsoleKey useroption;

            Console.WriteLine("Введите количество записей (если значение будет больше 0, то произойдет автоматическое заполнение ячеек): ");
            countNotes = GetNumber();
            Repository repository = new Repository(countNotes);

            Console.Clear();

            while (isActive)
            {
                repository.PrintRepository();
                PrintMenu();
                useroption = Console.ReadKey().Key;
                Console.Clear();

                switch (useroption)
                {
                    case ConsoleKey.D1:
                        repository.AddPlayer();
                        break;

                    case ConsoleKey.D2:
                        repository.BanPlayer();
                        break;

                    case ConsoleKey.D3:
                        repository.DeletePlayer();
                        break;

                    case ConsoleKey.D4:
                        isActive = false;
                        break;

                    default:
                        Console.WriteLine("Ошибка ввода");
                        break;
                }
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Добавить игрока\n2 - Забанить игрока по номеру\n3 - Удалить игрока\n4 - Выход");
        }

        static int GetNumber()
        {
            bool isActive = true;
            int result = 0;

            while (isActive)
            {
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput,out result))
                {
                    isActive = false;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода");
                }
            }
            return result;
        }
    }

    class Player
    {
        private string _name;
        private string _nickname;
        private bool _banStatus;
        private static List<string> _nicknames;

        public string Name => _name;
        public string Nickname => _nickname;
        public bool BanStatus => _banStatus;

        public Player(string name, string nickname, bool banStatus)
        {
            _name = name;
            _nickname = nickname;
            _banStatus = banStatus;

            if (_nickname == string.Empty || Player._nicknames.Contains(_nickname))
            {
                _nickname = $"{Guid.NewGuid().ToString().Substring(0, 5)}";
            }

            Player._nicknames.Add(_nickname);
        }

        public Player() : this("", "", false) { }

        static Player()
        {
            _nicknames = new List<string>();
        }

        public void ChangeName(string newName)
        {
            _name = newName;
        }

        public void ChangeNickname(string newNickname)
        {
            _nickname = newNickname;
        }

        public void Ban()
        {
            _banStatus = true;
        }

        public void Unban()
        {
            _banStatus = false;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{Name,10} {Nickname,10} {BanStatus,10}");
        }
    }

    class Repository
    {
        private List<Player> _players;
        private static Random _random;
        private readonly bool _randomBanStatus;
        private static readonly string[] _names;

        public Repository(int count)
        {
            CreatePlayers();

            for (int i = 0; i < count; i++)
            {
                _players.Add(new Player(_names[_random.Next(_names.Length)], "", _randomBanStatus));
                _randomBanStatus = _random.Next(2) == 1 ? true : false;
            }
        }

        private Player this[int index] => _players[index];

        static Repository()
        {
            _random = new Random();

            _names = new string[]
            {
                "Вадим",
                "Алексей",
                "Лилия",
                "Андрей",
                "Елена",
                "Сергей",
                "Светлана",
                "Борис",
                "Алиса"
            };
        }

        public void CreatePlayers()
        {
            _players = new List<Player>();
        }

        public void AddPlayer()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите ник игрока: ");
            string nickname = Console.ReadLine();

            _players.Add(new Player(name, nickname, false));
        }

        public void BanPlayer()
        {
            Console.Write("Введите номер позиции игрока: ");
            int currentPostion = GetNumber();
            int playerPosition = currentPostion - 1;

            if (currentPostion > 0 && currentPostion <= _players.Count) 
            {
                _players[playerPosition].Ban();
            }
            else
            {
                Console.WriteLine("Неверный индекс игрока");
            }
        }

        public void DeletePlayer()
        {
            Console.Write("Введите номер позиции игрока: ");
            int currentPostion = GetNumber();
            int playerPosition = currentPostion - 1;

            if (currentPostion > 0 && currentPostion <= _players.Count)
            {
                _players.Remove(_players[playerPosition]);
            }
            else
            {
                Console.WriteLine("Неверный индекс игрока");
            }
        }

        private int GetNumber()
        {
            bool isActive = true;
            int result = 0;

            while (isActive)
            {
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out result))
                {
                    isActive = false;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода");
                }
            }
            return result;
        }

        public void PrintRepository()
        {
            int playerPosition = 1;

            Console.WriteLine($"{"Имя",10} {"Ник",10} {"Статус бана",12}");

            foreach (var player in _players)
            {
                Console.Write(playerPosition++);
                player.PrintInfo();
            }
        }
    }
}
