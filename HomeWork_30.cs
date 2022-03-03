using System;
using System.Collections.Generic;

namespace HomeWork_30
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string nickname;
            int playerPosition;
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
                        Console.Write("Введите имя: ");
                        name = Console.ReadLine();
                        Console.Write("Введите ник игрока: ");
                        nickname = Console.ReadLine();
                        repository.AddPlayer(name, nickname);
                        break;

                    case ConsoleKey.D2:
                        Console.Write("Введите номер позиции игрока: ");
                        playerPosition = GetPosition();
                        repository[playerPosition].Ban();
                        break;

                    case ConsoleKey.D3:
                        Console.Write("Введите номер позиции игрока: ");
                        playerPosition = GetPosition();
                        repository.DeletePlayer(playerPosition);
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
            Console.WriteLine("1 - Добавить игрока\n2 - Забанить игрока по номеру\n3 - удалить игрока\n4 - Выход");
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

        static int GetPosition()
        {
            int playerPosition = GetNumber();
            int currentPosition = playerPosition - 1;
            return currentPosition;
        }
    }

    class Player
    {
        private string _name;
        private string _nickname;
        private bool _flag;
        static Random random;
        static List<string> dbNicknames;

        public string Name => _name;
        public string Nickname => _nickname;
        public bool Flag => _flag;

        static Player()
        {
            random = new Random();
            dbNicknames = new List<string>();
        }

        public Player(string name, string nickname, bool flag)
        {
            _name = name;
            _nickname = nickname;
            _flag = flag;

            if (_nickname == string.Empty || Player.dbNicknames.Contains(_nickname))
            {
                _nickname = $"{Guid.NewGuid().ToString().Substring(0, 5)}";
            }

            Player.dbNicknames.Add(_nickname);
        }

        public Player() : this("", "", false) { }

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
            _flag = true;
        }

        public void Unban()
        {
            _flag = false;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{Name,10} {Nickname,10} {Flag,10}");
        }
    }

    class Repository
    {
        private List<Player> _players;
        static Random random;
        static readonly string[] names;
        private readonly bool randomFlag;

        static Repository()
        {
            random = new Random();

            names = new string[]
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

        public Repository(int count)
        {
            CreatePlayers();

            for (int i = 0; i < count; i++)
            {
                _players.Add(new Player(names[random.Next(names.Length)], "", randomFlag));
                randomFlag = random.Next(2) == 1 ? true : false;
            }
        }

        public Player this[int index]
        {
            get { return _players[index]; }
            set { _players[index] = value; }
        }

        public void CreatePlayers()
        {
            _players = new List<Player>();
        }

        public void AddPlayer(string name, string nickname)
        {
            _players.Add(new Player(name, nickname, false));
        }

        public void DeletePlayer(int position)
        {
            if (position > 0)
            {
                _players.Remove(_players[position]);
            }
            else
            {
                Console.WriteLine("Неверный индекс игрока");
            }
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
