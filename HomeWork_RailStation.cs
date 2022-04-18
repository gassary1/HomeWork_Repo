using System;
using System.Collections.Generic;

namespace ConsoleApp9
{
    //У вас есть программа, которая помогает пользователю составить план поезда.
    //Есть 4 основных шага в создании плана:
    //-Создать направление - создает направление для поезда(к примеру Бийск - Барнаул)
    //-Продать билеты - вы получаете рандомное кол-во пассажиров, которые купили билеты на это направление
    //-Сформировать поезд - вы создаете поезд и добавляете ему столько вагонов(вагоны могут быть разные по вместительности), сколько хватит для перевозки всех пассажиров.
    //-Отправить поезд - вы отправляете поезд, после чего можете снова создать направление.
    //В верхней части программы должна выводиться полная информация о текущем рейсе или его отсутствии.
    class Program
    {
        static void Main(string[] args)
        {
            Builder builder = new Builder();
            builder.CreateDirection("Рязань-Москва");
            builder.CreateTrain();
            Console.WriteLine(builder.CountOfVagons);
        }
    }

    public class Vagon
    {
        private static Random _random;

        public int Capacity { get; }

        static Vagon()
        {
            _random = new Random();
        }

        public Vagon()
        {
            Capacity = _random.Next(10, 33);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Capacity}");
        }
    }

    class Train
    {
        private Direction _direction;
        private List<Vagon> _vagons;

        public int CountOfVagons { get { return _vagons.Count; } }

        public Train(Direction direction)
        {
            _direction = direction;
            _vagons = new List<Vagon>();
        }

        public void CreateVagons(int countOfPassengers)
        {
            for (int i = 0; i < countOfPassengers; i++)
            {
                _vagons.Add(new Vagon());
                countOfPassengers -= _vagons[i].Capacity;
            }
        }

        public void PrintVagons()
        {
            foreach (var vagon in _vagons)
            {
                vagon.ShowInfo();
            }
        }
    }

    class Direction
    {
        public string Name { get; }

        public Direction(string name)
        {
            Name = name;
        }
    }

    class Builder
    {
        private Train _train;
        private Direction _direction;

        public int CountOfVagons { get { return _train.CountOfVagons; } }

        public void CreateDirection(string direction)
        {
            _direction = new Direction(direction);
        }

        public void SellTickets(uint count)
        {

        }

        public void CreateTrain()
        {
            _train = new Train(_direction);
            _train.CreateVagons(100);
            _train.PrintVagons();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Направление - {_direction.Name} | Количество вагонов - {_train.CountOfVagons}")
        }
    }
}
