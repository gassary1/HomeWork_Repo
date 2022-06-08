using System;
using System.Collections.Generic;

namespace ConsoleApp9
{
    //Создать 5 бойцов, пользователь выбирает 2 бойцов и они сражаются друг с другом до смерти.У каждого бойца могут быть свои статы.
    //Каждый игрок должен иметь особую способность для атаки, которая свойственна только его классу!
    //Если можно выбрать одинаковых бойцов, то это не должна быть одна и та же ссылка на одного бойца, чтобы он не атаковал сам себя.
    //Пример, что может быть уникальное у бойцов. Кто-то каждый 3 удар наносит удвоенный урон, другой имеет 30% увернуться от полученного урона,
    //кто-то при получении урона немного себя лечит.Будут новые поля у наследников.У кого-то может быть мана и это только его особенность.
    class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heroes = new List<Hero>()
            {
                new Warrior("Geck"),
                new Druid("Rob"),
                new Barbarian("Konan"),
                new Assasin("Altair"),
                new Vampire("Alucard")
            };

            Arena arena = new Arena(heroes);

            arena.SelectHeroes();
            arena.ShowBattleResult();
        }
    }

    abstract class Hero
    {
        private static Random _random;
        private static List<string> _dataBaseOfNames;
        private int _damage;

        public int Health { get; protected set; }
        public string Name { get; private set; }
        public int Damage => GetRandomDamage();

        static Hero()
        {
            _dataBaseOfNames = new List<string>();
            _random = new Random();
        }

        public Hero(string name, int health, int damage)
        {
            if (name == string.Empty || Hero._dataBaseOfNames.Contains(name))
            {
                name = $"{Guid.NewGuid().ToString().Substring(0, 5)}";
            }
            Name = name;
            Health = health;
            _damage = damage;

            _dataBaseOfNames.Add(name);
        }

        public void Attack(Hero target)
        {
            int mode = _random.Next(0, 2);

            switch (mode)
            {
                case 0:
                    UseBaseAttack(target);
                    break;
                case 1:
                    UseAbility(target);
                    break;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name,9} | {Health,17} | {_damage,13} | {GetType().Name}");
        }

        public bool IsDied()
        {
            return Health <= 0;
        }

        protected void UseBaseAttack(Hero target)
        {
            if (target != this && target.Health > 0)
            {
                target.TakeDamage(this.Damage);
            }
        }

        protected virtual void UseAbility(Hero target)
        {

        }

        protected virtual int DamageEffect(int damage)
        {
            return damage;
        }

        private void TakeDamage(int damage)
        {
            Health -= DamageEffect(damage);

            if (IsDied())
            {
                Health = 0;
                DieMessage();
            }
        }

        private void DieMessage()
        {
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Name} - пал в бою");
            Console.ResetColor();
        }

        private int GetRandomDamage()
        {
            return _random.Next(0, _damage);
        }
    }

    class Warrior : Hero
    {
        private const int Multiply = 2;

        private int _armor;

        public Warrior(string name) : base(name, 90, 10)
        {
            _armor = 30;
        }
        public Warrior() : this("")
        {

        }

        protected override int DamageEffect(int damage)
        {
            int percent = 100;

            return damage - _armor * damage / percent;
        }

        protected override void UseAbility(Hero target)
        {
            int specialDamage = 0;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} - применил ДРАКОНЬЯ КОЖА");
            Console.ResetColor();

            DamageEffect(specialDamage);
        }
    }

    class Druid : Hero
    {
        public const int Intelligence = 2;

        public Druid(string name) : base(name, 90, 7)
        {

        }

        public Druid() : this("")
        {

        }

        protected override int DamageEffect(int damage)
        {
            return (int)(damage * Intelligence);
        }

        protected override void UseAbility(Hero target)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} - применил ЛЕЧЕНИЕ");
            Console.ResetColor();

            if (Health > 0)
            {
                Health += Damage * Intelligence;
            }
        }
    }

    class Barbarian : Hero
    {
        private const int Strength = 3;

        public Barbarian(string name) : base(name, 100, 10)
        {

        }

        public Barbarian() : this("")
        {

        }

        protected override int DamageEffect(int damage)
        {
            return (int)(damage * Strength);
        }

        protected override void UseAbility(Hero target)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} - применил НЕИСТОВСТВО");
            Console.ResetColor();

            for (int i = 0; i < Strength; i++)
            {
                UseBaseAttack(target);
            }

            Health -= Damage;
        }
    }

    class Assasin : Hero
    {
        private const int AttacksCount = 5;

        public Assasin(string name) : base(name, 90, 15)
        {

        }

        public Assasin() : this("")
        {

        }
        protected override void UseAbility(Hero target)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} - применил СКРЫТЫЙ УДАР");
            Console.ResetColor();

            for (int i = 0; i < AttacksCount; i++)
            {
                UseBaseAttack(target);
            }
        }
    }

    class Vampire : Hero
    {
        public Vampire(string name) : base(name, 98, 8)
        {

        }

        public Vampire() : this("")
        {

        }
        protected override void UseAbility(Hero target)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} - применил ВАМПИРИЗМ");
            Console.ResetColor();

            Health += Damage;
        }
    }

    class Arena
    {
        private Hero _firstHero;
        private Hero _secondHero;
        private List<Hero> _heroes;
        private int _currentSelectIndex;

        public Arena(List<Hero> heroes)
        {
            _heroes = heroes;
            _currentSelectIndex = 0;
        }

        public void SelectHeroes()
        {
            Console.WriteLine("Выберите героев\n");

            ShowHeroes();

            _firstHero = _heroes[TrySelectHero() - 1];
            _secondHero = _heroes[TrySelectHero() - 1];

            Fight();
        }

        public void ShowBattleResult()
        {
            if (_firstHero.Health < 0)
            {
                Console.WriteLine($"{_secondHero.Name} победил");
            }
            else if (_firstHero.Health < 0 && _secondHero.Health < 0)
            {
                Console.WriteLine("Ничья");
            }
            else
            {
                Console.WriteLine($"{_secondHero.Name} победил");
            }
        }

        private int TrySelectHero()
        {
            while (int.TryParse(Console.ReadLine(), out int index))
            {
                if (index > 0 && index <= _heroes.Count)
                {
                    if (index == _currentSelectIndex)
                    {
                        Console.WriteLine("Этот боец уже выбран, выберите другого");
                    }
                    else
                    {
                        _currentSelectIndex = index;
                        return index;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка ввода");
                }
            }
            return 0;
        }

        private void Fight()
        {
            _firstHero.ShowInfo();
            _secondHero.ShowInfo();

            Console.WriteLine("Битва началась\n");

            while (_firstHero.Health > 0 && _secondHero.Health > 0)
            {
                Console.WriteLine("****************");

                _firstHero.Attack(_secondHero);
                _secondHero.Attack(_firstHero);

                _firstHero.ShowInfo();
                _secondHero.ShowInfo();
            }

            Console.WriteLine("#############");
            Console.WriteLine("Бой окончен");
        }

        private void ShowHeroes()
        {
            int index = 1;

            foreach (var hero in _heroes)
            {
                Console.Write($"{index++} ");
                hero.ShowInfo();
            }
        }
    }
}
