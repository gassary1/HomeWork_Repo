using System;

namespace HomeWork_7
{
    class HomeWork_7
    {
        static void Main(string[] args)
        {
            int countOfRepeat = 10;

            Console.Write("Введите любое сообщение: ");
            string message = Console.ReadLine();

            for (int i=0; i<countOfRepeat; i++)
            {
                Console.WriteLine(message);
            }

            Console.ReadLine();
        }
    }
}
