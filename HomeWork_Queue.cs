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
            int position = 1;
            int cost = 0;
            int billOfClient;

            Queue<int> price = new Queue<int>();
            price.Enqueue(50);
            price.Enqueue(100);
            price.Enqueue(40);
            price.Enqueue(150);

            while (price.Count > 0)
            {
                Console.WriteLine($"Очередь клиента - {position}");

                billOfClient = price.Dequeue();

                Console.WriteLine($"Сумма покупки равна - {billOfClient}");

                cost += billOfClient;
                position++;

                Console.ReadLine();

                Console.Clear();
            }

            if (price.Count == 0)
            {
                Console.WriteLine("Клиентов больше нет!");
            }

            Console.WriteLine($"Касса на сегодня составила - {cost} р.");
        }
    }
}
