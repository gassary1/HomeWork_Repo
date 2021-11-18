using System;

namespace HomeWork_13
{
    class HomeWork_13
    {
        static void Main(string[] args)
        {
            string password = "020395";
            string userInput = string.Empty;
            int tryCount = 3;

            for (int i = 0; i < tryCount; i++)
            {
                Console.Write($"Для досутпа у вас есть {tryCount} попыток. Введите пароль: ");
                userInput = Console.ReadLine();

                if (userInput == password)
                {
                    Console.WriteLine("Торжественно клянусь, что замышляю только шалость");
                }
                else
                {
                    Console.WriteLine($"Доступ запрещен. Количество попыток равно - {tryCount-i-1}");
                }
            }
        }
    }
}
