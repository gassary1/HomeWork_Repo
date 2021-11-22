using System;

namespace HomeWork_12
{
    class HomeWork_12
    {
        static void Main(string[] args)
        {
            Console.Write("Введите свое имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите символ, которым будет отрисована рамка: ");
            char symbol = Console.ReadKey().KeyChar;
            Console.WriteLine();

            for (int i = 0; i < name.Length + 2; i++)
            {
                Console.Write(symbol);
            }

            Console.WriteLine("\n" + symbol + name + symbol);

            for (int i = 0; i < name.Length + 2; i++)
            {
                Console.Write(symbol);
            }
        }
    }
}