using System;
using System.Collections.Generic;

namespace ConsoleApp19
{
    //У вас есть множество целых чисел. Каждое целое число - это сумма покупки.
    //Вам нужно обслуживать клиентов до тех пор, пока очередь не станет пуста.
    //После каждого обслуженного клиента деньги нужно добавлять на наш счёт и выводить его в консоль.
    //После обслуживания каждого клиента программа ожидает нажатия любой клавиши, после чего затирает консоль и по новой выводит всю информацию, только уже со следующим клиентом
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<string> clientsList = new List<string>() { "Олег", "Алексей", "Александр" };
            int[] price = { 50, 100, 40, 150, 60, 110, 200, 10, 20 };
            Queue<string> clients = new Queue<string>(clientsList);
            int cost = 0;
            int billOfClient;

            while (clients.Count > 0)
            {
                Console.WriteLine($"Очередь клиента - {clients.Dequeue()}");

                billOfClient = price[random.Next(price.Length)];

                Console.WriteLine($"Сумма покупки равна - {billOfClient}");

                cost += billOfClient;

                Console.ReadLine();

                Console.Clear();
            }

            if (clients.Count == 0)
            {
                Console.WriteLine("Клиентов больше нет!");
            }

            Console.WriteLine($"Касса на сегодня составила - {cost} р.");
        }
    }
}
