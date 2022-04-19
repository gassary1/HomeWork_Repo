using System;
using System.Collections.Generic;

namespace ConsoleApp8
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
            ConsoleKey userOption;
            bool isActive = true;
            Builder builder = new Builder();
            List<Builder> table = new List<Builder>();

            while (isActive)
            {

                PrintTable(table);

                PrintMenu();

                Console.Write("Введите опцию: ");
                userOption = Console.ReadKey().Key;


                switch (userOption)
                {
                    case ConsoleKey.D1:

                        builder.CreateDirection();
                        break;
                    case ConsoleKey.D2:
                        builder.CreateTrain();
                        break;
                    case ConsoleKey.D3:
                        table.Add(builder);
                        break;
                    case ConsoleKey.D4:
                        isActive = false;
                        break;
                }
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("1 - Создать направление\n2 - Сформировать поезд\n3 - Отправить поезд\n4 - Выход");
        }

        static void PrintTable(List<Builder> tables)
        {
            foreach (var table in tables)
            {
                table.ShowInfo();
            }
        }
    }

    class Direction
    {
        private static Random _random;

        public string Name { get; }
        public int CountOfPeople { get; }

        static Direction()
        {
            _random = new Random();
        }

        public Direction(string name)
        {
            Name = name;
            CountOfPeople = _random.Next(25, 200);
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
    }

    class Train
    {
        private Direction _direction;
        private List<Vagon> _vagons;

        public int CountOfVagons { get { return _vagons.Count; } }

        public int CountOfPlacements
        {
            get
            {
                int sum = 0;

                foreach (var vagon in _vagons)
                {
                    sum += vagon.Capacity;
                }

                return sum;
            }
        }

        public Train(Direction direction)
        {
            _direction = direction;
            _vagons = new List<Vagon>();
        }

        public void CreateVagons()
        {
            int countOfPassangers = _direction.CountOfPeople;

            for (int i = 0; i < countOfPassangers; i++)
            {
                _vagons.Add(new Vagon());
                countOfPassangers -= _vagons[i].Capacity;
            }
        }
    }

    class Builder
    {
        private Train _train;
        private Direction _direction;

        public int CountOfVagons { get { return _train.CountOfVagons; } }

        public void CreateDirection()
        {
            string direction;

            Console.Write("Введите название направления: ");
            direction = Console.ReadLine();

            _direction = new Direction(direction);
            Console.WriteLine($"На направление {direction} продано {_direction.CountOfPeople} билетов");
        }

        public void CreateTrain()
        {
            _train = new Train(_direction);
            _train.CreateVagons();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Направление - {_direction.Name} | Количество вагонов - {_train.CountOfVagons} | Количество мест - {_train.CountOfPlacements} | Количетсво пассажиров - {_direction.CountOfPeople}");
        }
    }
}
