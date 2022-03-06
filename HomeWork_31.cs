using System;
using System.Collections.Generic;

namespace HomeWork_31
{
    class Program
    {
        static void Main(string[] Args)
        {

        }
    }

    class Player
    {
        private string _name;
        private int _gold;

        public string Name => _name;
        public int Gold => _gold;
    }

    class Seller
    {
        private string _name;
        private int _gold;
        private List<Product> _products;

        public string Name => _name;
        public int Gold => _gold;
    }

    class Product
    {
        private string _name;
        private int _amount;
        private int _price;

        public string Name => _name;
        public int Amount => _amount;
        public int Price => _price;

        public Product(string name, int amount, int price)
        {
            _name = name;
            _amount = amount;
            _price = price;
        }
    }
}