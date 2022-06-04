using System;
using System.Collections.Generic;

namespace ConsoleApp7
{
    //Написать программу администрирования супермаркетом.
    //В супермаркете есть очередь клиентов.
    //У каждого клиента в корзине есть товары, также у клиентов есть деньги.
    //Клиент, когда подходит на кассу, получает итоговую сумму покупки и старается её оплатить.
    //Если оплатить клиент не может, то он рандомный товар из корзины выкидывает до тех пор, пока его денег не хватит для оплаты.
    //Клиентов можно делать ограниченное число на старте программы.
    class Program
    {
        static void Main(string[] args)
        {
            int buyersCount = GetNumber();

            List<Product> products = new List<Product>()
            {
                new Product("Молоко", 45),
                new Product("Хлеб", 25),
                new Product("Курица", 239),
                new Product("Печенье", 60),
                new Product("Конфеты", 140),
                new Product("Вода", 30)
            };
            Shop shop = new Shop(products, buyersCount);

            shop.Work();
        }

        static int GetNumber()
        {
            bool isActive = true;
            int result = 0;

            while (isActive)
            {
                string userInput = Console.ReadLine();

                if (int.Parse(userInput) > 0 && int.TryParse(userInput, out result))
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
    }

    class Shop
    {
        private List<Product> _products;
        private Queue<Buyer> _buyers;
        private int _money;

        public Shop(List<Product> products, int buyersCount)
        {
            _products = products;
            _buyers = new Queue<Buyer>();

            CreateBuyers(buyersCount);
        }

        public void Work()
        {
            foreach (var buyer in _buyers)
            {
                buyer.TakeProducts(_products);
            }

            SendForPayment();
            ShowInfo();
        }

        private void SendForPayment()
        {
            while (_buyers.Count > 0)
            {
                Buyer buyer = _buyers.Dequeue();
                Console.WriteLine($"Сейчас очередь {buyer.Name}");
                _money += buyer.Pay();
            }
        }

        private void ShowInfo()
        {
            Console.WriteLine($"Магазин заработал {_money} р. Приходите к нам еще");
        }

        private void CreateBuyers(int buyersCount)
        {
            for (int i = 0; i < buyersCount; i++)
            {
                _buyers.Enqueue(new Buyer());
            }
        }
    }

    class Buyer
    {
        private const int MinProductsCount = 1;
        private const int MaxProductsCount = 10;
        private const int MinBuyerMoney = 300;
        private const int MaxBuyerMoney = 1100;

        private static List<string> _dataBaseOfNames;
        private static Random _random;
        private Basket _basket;

        public int Money { get; private set; }
        public string Name { get; private set; }

        static Buyer()
        {
            _dataBaseOfNames = new List<string>();
            _random = new Random();
        }

        public Buyer(string name)
        {
            Money = _random.Next(MinBuyerMoney, MaxBuyerMoney);
            _basket = new Basket();

            if (name == string.Empty || _dataBaseOfNames.Contains(name))
            {
                name = $"{Guid.NewGuid().ToString().Substring(0, 5)}";
            }

            Name = name;
            _dataBaseOfNames.Add(name);
        }

        public Buyer() : this("")
        {

        }

        public void TakeProducts(List<Product> products)
        {
            for (int i = 0; i < _random.Next(MinProductsCount, MaxProductsCount); i++)
            {
                _basket.AddProduct(products[_random.Next(0, products.Count)]);
            }
        }

        public int Pay()
        {
            while (_basket.CostBasket > Money)
            {
                _basket.RemoveRandomProduct();
            }

            Money -= _basket.CostBasket;
            return _basket.CostBasket;
        }
    }

    class Basket
    {
        private static Random _random;
        private List<Product> _products;

        public int CostBasket { get; private set; }

        static Basket()
        {
            _random = new Random();
        }

        public Basket()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            CostBasket += product.Price;
            _products.Add(product);
        }

        public void RemoveRandomProduct()
        {
            int productIndex = _random.Next(0, _products.Count);

            CostBasket -= _products[productIndex].Price;
            _products.Remove(_products[productIndex]);
        }
    }

    class Product
    {
        public string Name { get; }
        public int Price { get; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
