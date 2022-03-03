using System;
using System.Collections.Generic;

namespace HomeWork_30
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isActive = true;
            Repository repository = new Repository(10);
            repository.PrintRepository();
            Console.WriteLine();
            repository.PrintRepository();

        }

        static void PrintMenu()
        {
            Console.WriteLine("1 - Добавить игрока\n2 - Забанить игрока по номеру\n3 - удалить игрока\n4 - Выход");
        }
    }

    class Player
    {
        private string _name;
        private string _nickname;
        private bool _flag;
        //static uint indexName;
        static Random random;
        static List<string> dbNicknames;

        public string Name => _name;
        public string Nickname => _nickname;
        public bool Flag => _flag;

        static Player()
        {
            //indexName = 1;
            random = new Random();
            dbNicknames = new List<string>();
        }

        public Player(string name, string nickname, bool flag)
        {
            _name = name;
            _nickname = nickname;
            _flag = flag;

            if(nickname == string.Empty || Player.dbNicknames.Contains(nickname))
            {
                nickname = $"{Guid.NewGuid().ToString().Substring(0, 5)}";
            }

            Player.dbNicknames.Add(nickname);
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
        static readonly bool flags;

        public Repository(uint count)
        {
            CreatePlayers();

            for (int i = 0; i < count; i++)
            {
                _players.Add(new Player());
            }
        }

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

        public void CreatePlayers()
        {
            _players = new List<Player>();
        }

        public void PrintRepository()
        {
            foreach (var player in _players)
            {
                player.PrintInfo();
            }
        }
    }
}
