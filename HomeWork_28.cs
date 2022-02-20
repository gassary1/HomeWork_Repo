using System;
using System.Collections.Generic;

namespace HomeWork_28
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();

            Player player1 = new Player("Riko");
            Player player2 = new Player("Artas", "Warrior", 10);
            Player player3 = new Player("Simon", 16);
            Player player4 = new Player("Nikolas", "Druid");

            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);

            Console.WriteLine($"{"Имя",15} {"Класс",15} {"Уровень",5}");

            foreach (var user in players)
            {
                user.PrintInfo();
            }
        }
    }

    class Player
    {
        #region Constructors
        public Player(string Name, string Class, uint Level)
        {
            _name = Name;
            _class = Class;
            _level = Level;
        }

        public Player(string Name, string Class)
        {
            _name = Name;
            _class = Class;
        }

        public Player(string Name, uint Level)
        {
            _name = Name;
            _level = Level;
        }

        public Player(string Name)
        {
            _name = Name;
        }
        #endregion

        #region Metods
        public void PrintInfo()
        {
            Console.WriteLine($"{Name,15} {Class,15} {Level,5}");
        }
        #endregion

        #region Properties
        public string Name { get { return _name; } }

        public uint Level { get { return _level; } set { value = _level; } }

        public string Class { get { return _class; } }
        #endregion

        #region Fields
        private string _name;

        private uint _level;

        private string _class;
        #endregion
    }
}
