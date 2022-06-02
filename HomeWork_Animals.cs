using System;
using System.Collections.Generic;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            Volier v1 = new Volier();
            Volier v2 = new Volier();

            v1.ShowInfo();
            Console.WriteLine();
            v2.ShowInfo();
        }
    }

    abstract class Animal
    {
        public abstract void Moto();

        public void ShowAnimalInfo()
        {
            Console.WriteLine(GetType().Name);
        }
    }

    class Horse : Animal
    {
        public Horse()
        {

        }

        public override void Moto()
        {
            Console.WriteLine("1");
        }
    }

    class Sheep : Animal
    {
        public Sheep()
        {

        }

        public override void Moto()
        {
            Console.WriteLine("2");
        }
    }

    class Duck : Animal
    {
        public Duck()
        {

        }

        public override void Moto()
        {
            Console.WriteLine("3");
        }
    }

    class Lion : Animal
    {
        public Lion()
        {

        }

        public override void Moto()
        {
            Console.WriteLine("4");
        }
    }

    class Tiger : Animal
    {
        public Tiger()
        {

        }

        public override void Moto()
        {
            Console.WriteLine("5");
        }
    }

    class Volier
    {
        private List<Animal> _animals;
        private static Random _random;

        static Volier()
        {
            _random = new Random();
        }

        public Volier()
        {
            _animals = new List<Animal>();
            CreateAnimals();
        }

        private void CreateAnimals()
        {
            for (int i = 0; i < _random.Next(1,11); i++)
            {
                switch (_random.Next(1, 6))
                {
                    case 1:
                        _animals.Add(new Horse());
                        break;
                    case 2:
                        _animals.Add(new Sheep());
                        break;
                    case 3:
                        _animals.Add(new Duck());
                        break;
                    case 4:
                        _animals.Add(new Lion());
                        break;
                    case 5:
                        _animals.Add(new Tiger());
                        break;
                }
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("Вольер");
            foreach (var animal in _animals)
            {
                animal.ShowAnimalInfo();
            }
        }
    }
}
