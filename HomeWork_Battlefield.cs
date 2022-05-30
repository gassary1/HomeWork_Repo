using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    //Есть 2 взвода. 1 взвод страны один, 2 взвод страны два.
    //    Каждый взвод внутри имеет солдат.
    //    Нужно написать программу, которая будет моделировать бой этих взводов.
    //    Каждый боец - это уникальная единица, он может иметь уникальные способности или же уникальные характеристики, такие как повышенная сила.
    //Побеждает та страна, во взводе которой остались выжившие бойцы.
    //Не важно, какой будет бой, рукопашный, стрелковый.
    class Program
    {
        static void Main(string[] args)
        {
            Squad firstSquad = new Squad("Отряд Гамма");
            Squad seconSquad = new Squad("Отряд Дельта");

            Battlefield poligon = new Battlefield(firstSquad, seconSquad);

            ShowSquads(firstSquad, seconSquad);

            Console.WriteLine("Нажмите Enter чтобы начать иммитацию битвы");
            Console.ReadLine();

            poligon.Fight();

            ShowSquads(firstSquad, seconSquad);

            poligon.ShowResult();
        }

        static void ShowSquads(Squad firstSquad, Squad secondSquad)
        {
            firstSquad.ShowSquad();
            Console.WriteLine();
            secondSquad.ShowSquad();
            Console.WriteLine();
        }
    }

    abstract class Warrior
    {
        private static List<string> _dataBaseOfNames;

        private int _health;
        private string _name;
        private int _damage;

        static Warrior()
        {
            _dataBaseOfNames = new List<string>();
        }

        public Warrior(string name, int health, int damage)
        {
            if (name == string.Empty || Warrior._dataBaseOfNames.Contains(name))
            {
                name = $"{Guid.NewGuid().ToString().Substring(0, 5)}";
            }
            _name = name;
            _health = health;
            _damage = damage;

            _dataBaseOfNames.Add(name);
        }

        public void Attack(Warrior target)
        {
            if (target != this && target._health > 0)
            {
                target.TakeDamage(_damage);
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_name,9} | {_health,17} | {_damage,13} | {GetType().Name}");
        }

        public bool IsDied()
        {
            return _health == 0;
        }

        protected virtual int DamageEffect(int damage)
        {
            return damage;
        }

        private void TakeDamage(int damage)
        {
            if (_health - DamageEffect(damage) <= 0)
            {
                _health = 0;
                DieMessage();
            }
            else
            {
                _health -= DamageEffect(damage);
            }
        }

        private void DieMessage()
        {
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{_name} - пал в бою");
            Console.ResetColor();
        }
    }

    class Stormtrooper : Warrior
    {
        private const int Armor = 30;

        public Stormtrooper(string name) : base(name, 90, 10)
        {

        }
        public Stormtrooper() : this("")
        {

        }

        protected override int DamageEffect(int damage)
        {
            int percent = 100;

            return damage - Armor * damage / percent;
        }
    }

    class Sniper : Warrior
    {
        public const float Accuracy = 1.2f;

        public Sniper(string name) : base(name, 95, 15)
        {

        }
        public Sniper() : this("")
        {

        }
        protected override int DamageEffect(int damage)
        {
            return (int)(damage * Accuracy);
        }
    }

    class Engineer : Warrior
    {
        private const float FirePower = 2.1f;

        public Engineer(string name) : base(name, 100, 8)
        {

        }

        public Engineer() : this("")
        {

        }

        protected override int DamageEffect(int damage)
        {
            return (int)(damage * FirePower);
        }
    }

    class Squad
    {
        private static Random _random;
        private List<Warrior> _warriors;

        public string SquadName { get; }
        public int CountOfWarriors => _warriors.Count;

        static Squad()
        {
            _random = new Random();
        }

        public Squad(string name)
        {
            _warriors = new List<Warrior>();
            SquadName = name;

            CreateSquad();
        }

        public Warrior this[int index] => _warriors[index];

        public void ShowSquad()
        {
            DeleteDeathWarriors();

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Название отряда - {SquadName}");
            Console.ResetColor();
            Console.WriteLine($"{"Имя юнита"} | {"Количество жизней"} | {"Наносимый урон"} | {"Класс юнита"}");

            foreach (var warrior in _warriors)
            {
                warrior.ShowInfo();
            }

            Console.WriteLine($"Количество юнитов - {CountOfWarriors}");
        }

        public void AttackSquad(Squad squad)
        {
            for (int i = 0; i < _warriors.Count; i++)
            {
                _warriors[i].Attack(squad[_random.Next(squad.CountOfWarriors)]);
            }
        }

        private void DeleteDeathWarriors()
        {
            _warriors.RemoveAll(warrior => warrior.IsDied() == true);
        }

        private void CreateSquad()
        {
            int countOfWarriors = 10;

            for (int i = 0; i < countOfWarriors; i++)
            {
                switch (_random.Next(0, 3))
                {
                    case 0:
                        _warriors.Add(new Stormtrooper());
                        break;
                    case 1:
                        _warriors.Add(new Sniper());
                        break;
                    case 2:
                        _warriors.Add(new Engineer());
                        break;
                }
            }
        }
    }

    class Battlefield
    {
        private Squad _firstSquad;
        private Squad _secondSquad;

        public Battlefield(Squad firstSquad, Squad secondSquad)
        {
            _firstSquad = firstSquad;
            _secondSquad = secondSquad;
        }

        public void Fight()
        {
            int rounds = 6;

            for (int i = 0; i < rounds; i++)
            {
                _firstSquad.AttackSquad(_secondSquad);
                _secondSquad.AttackSquad(_firstSquad);
            }
        }

        public void ShowResult()
        {
            if (_firstSquad.CountOfWarriors > _secondSquad.CountOfWarriors)
            {
                Console.WriteLine($"Отряд - {_firstSquad.SquadName} победил");
            }
            else if (_firstSquad.CountOfWarriors == _secondSquad.CountOfWarriors)
            {
                Console.WriteLine("Ничья");
            }
            else
            {
                Console.WriteLine($"Отряд - {_secondSquad.SquadName} победил");
            }
        }

    }
}
