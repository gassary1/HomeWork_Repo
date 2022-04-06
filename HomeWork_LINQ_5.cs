using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository products = new Repository(15);

            Console.WriteLine("Список продуктов: \n");
            products.PrintRepository();

            Console.WriteLine("\nСписок просроченных продуктов: \n");
            products.ShowOverdue();
        }
    }

    class Product
    {
        private static List<string> _names;
        private string _name;
        private uint _expirationDate;
        private DateTime _productionDate;

        public string Name => _name;
        public uint ExpirationDate => _expirationDate;
        public DateTime ProductionDate => _productionDate;

        static Product()
        {
            _names = new List<string>();
        }

        public Product(string name, DateTime productionDate, uint expirationDate)
        {
            _name = name;
            _productionDate = productionDate;
            _expirationDate = expirationDate;

            if (_name == string.Empty || Product._names.Contains(_name))
            {
                _name = $"{Guid.NewGuid().ToString().Substring(0, 5)}";
            }

            Product._names.Add(name);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name,6} {ProductionDate.ToShortDateString(),15} {ExpirationDate,12}");
        }
    }

    class Repository
    {
        private static Random _random;
        private List<Product> _products;

        static Repository()
        {
            _random = new Random();
        }

        public Repository(uint count)
        {
            _products = new List<Product>();

            for (int i = 0; i < count; i++)
            {
                _products.Add(new Product("", RandomTime(), (uint)_random.Next(1, 5)));
            }
        }

        public void PrintRepository()
        {
            Header();

            foreach (var product in _products)
            {
                product.ShowInfo();
            }
        }

        public void ShowOverdue()
        {
            List<Product> tempProducts = _products.Where(product => DateTime.Now.Year - product.ProductionDate.Year >= product.ExpirationDate).ToList();

            Header();

            foreach (var product in tempProducts)
            {
                product.ShowInfo();
            }
        }

        private void Header()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{"Название",5} {"Дата производства",5} {"Срок годности",5}");
            Console.ResetColor();
        }

        private DateTime RandomTime()
        {
            DateTime startTime = new DateTime(2018, 1, 1);
            int days = (DateTime.Now - startTime).Days;
            return startTime.AddDays(_random.Next(days));
        }
    }
}
