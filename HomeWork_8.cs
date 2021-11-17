using System;

namespace HomeWork_8
{
    class HomeWork_8
    {
        static void Main(string[] args)
        {
            bool isActive = true;

            Console.WriteLine("Для выхода из программы наберите exit");

            while (isActive)
            {
                Console.Write("Введите любое сообщение: ");
                string message = Console.ReadLine();
                Console.WriteLine(message);

                if (message == "exit") isActive = false;
            }

        }
    }
}
