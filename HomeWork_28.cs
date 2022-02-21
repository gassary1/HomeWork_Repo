using System;
using System.Collections.Generic;

namespace HomeWork_28
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();

            Player player1 = new Player("Riko","Dwarf", 1);
            Player player2 = new Player("Artas", "Human", 10);
            Player player3 = new Player("Simon", "Nord", 16);
            Player player4 = new Player();

            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);

            Console.WriteLine($"{"Имя",15} {"Расса",15} {"Уровень",5}");

            foreach (var user in players)
            {
                user.PrintInfo();
            }
        }
    }

    class Player
    {
        #region Fields
        private string _name;

        private string _race;

        private uint _level;
        #endregion

        #region Properties
        public string Name => _name;

        public string Race => _race;

        public uint Level => _level;
        #endregion

        #region Constructors
        public Player(string name, string race, uint level)
        {
            _name = name;
            _race = race;
            _level = level;
        }

        public Player() : this("", "", 0) { }
        #endregion

        #region Metods
        public string ChangeRace(string newRace)
        {
            return _race = newRace;
        }

        public string ChangeName(string newName)
        {
            return _name = newName;
        }

        public void AddLevel()
        {
            _level++;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{Name,15} {Race,15} {Level,5}");
        }
        #endregion
    }
}
