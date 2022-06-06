using System;
using System.Collections.Generic;

namespace ConsoleApp8
{
    //У вас есть автосервис, в который приезжают люди, чтобы починить свои автомобили.
    //У вашего автосервиса есть баланс денег и склад деталей.
    //Когда приезжает автомобиль, у него сразу ясна его поломка, и эта поломка отображается у вас в консоли вместе с ценой за починку
    //(цена за починку складывается из цены детали + цена за работу).
    //Поломка всегда чинится заменой детали, но количество деталей ограничено тем, что находится на вашем складе деталей.
    //Если у вас нет нужной детали на складе, то вы можете отказать клиенту, и в этом случае вам придется выплатить штраф.
    //Если вы замените не ту деталь, то вам придется возместить ущерб клиенту.
    //За каждую удачную починку вы получаете выплату за ремонт, которая указана в чек-листе починки.
    //Класс Деталь не может содержать значение “количество”. Деталь всего одна, за количество отвечает тот, кто хранит детали.
    //При необходимости можно создать дополнительный класс для конкретной детали и работе с количеством.
    class Program
    {
        static void Main(string[] args)
        {
            int carsCount = 5;
            int detailsCount = 20;

            Random random = new Random();

            List<Detail> details = new List<Detail>()
            {
                new Detail("Тормозная жидкость", 800),
                new Detail("Антифриз", 700),
                new Detail("Сальники Masuma", 1500),
                new Detail("Сальники Toyota", 2000),
                new Detail("Салонный фильтр", 1000),
                new Detail("Воздушный фильтр", 1200),
                new Detail("Тормозные диски", 4000),
                new Detail("Тормозные колодки", 2000),
                new Detail("Свечи Denso", 5000),
                new Detail("Свечи Toyota", 6000)
            };

            List<Stack> stacks = new List<Stack>();

            for (int i = 0; i < details.Count; i++)
            {
                stacks.Add(new Stack(details[i], random.Next(0, detailsCount)));
            }

            Queue<Car> cars = new Queue<Car>();
            {
                for (int i = 0; i < carsCount; i++)
                {
                    cars.Enqueue(new Car(details[random.Next(0, details.Count)]));
                }
            }

            CarService carService = new CarService(cars, stacks);
            carService.Work();

        }
    }

    class CarService
    {
        private const int FixPrice = 1000;
        private const int Fofreit = 1000;

        private Queue<Car> _cars;
        private List<Stack> _stacks;
        private Car _car;
        private Detail _sparePart;
        private int _money;

        public CarService(Queue<Car> cars, List<Stack> stacks)
        {
            _cars = cars;
            _stacks = stacks;
        }

        public void Work()
        {
            while (_cars.Count > 0)
            {
                Console.Clear();

                Console.WriteLine($"Касса автосервиса - {_money}");
                ShowPartsInfo();

                _car = _cars.Dequeue();
                _car.ShowWreckInfo();
                FixCar();
                //Console.ReadLine();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Работа закончена");
            Console.ResetColor();
        }

        public void FixCar()
        {
            int payment;

            if (TryGetDetail())
            {
                payment = _sparePart.Cost + FixPrice;
                _money += payment;
                Console.WriteLine($"Вы заработали - {_money}");
            }
        }

        private bool TryGetDetail()
        {
            bool isSucces = false;

            Console.WriteLine("\nВыберите деталь со склада\n");

            int.TryParse(Console.ReadLine(), out int index);

            int detailtPostion = index - 1;

            if (detailtPostion > 0 && detailtPostion < _stacks.Count && _stacks[detailtPostion].Detail.Name == _car.WreckDetail.Name)
            {
                _sparePart = _stacks[detailtPostion].GetDetail();

                return true;
            }
            else
            {
                _money -= Fofreit;

                Console.WriteLine($"Выбрана неверная деталь. Выплачен штраф в размере - {Fofreit}");
            }

            return isSucces;
        }

        private void ShowPartsInfo()
        {
            int index = 1;
            Console.WriteLine("Деталей на складе: ");

            foreach (var stack in _stacks)
            {
                Console.Write($"{index++} ");
                stack.ShowDetailInfo();
            }
        }
    }

    class Car
    {
        public Detail WreckDetail { get; private set; }

        public Car(Detail wreckDetail)
        {
            WreckDetail = wreckDetail;
        }

        public void ShowWreckInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nТребуется замена - {WreckDetail.Name}");
            Console.ResetColor();
        }
    }

    class Stack
    {
        public Detail Detail { get; private set; }
        public int DetailsCount { get; private set; }

        public Stack(Detail detail, int detailsCount)
        {
            Detail = detail;
            DetailsCount = detailsCount;
        }

        public Detail GetDetail()
        {
            if (DetailsCount > 0)
            {
                DetailsCount--;
                return Detail;
            }
            else
            {
                return null;
            }
        }

        public void ShowDetailInfo()
        {
            Console.WriteLine($"Количество {Detail.Name} - {DetailsCount}");
        }
    }

    class Detail
    {
        public string Name { get; private set; }
        public int Cost { get; private set; }

        public Detail(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}
