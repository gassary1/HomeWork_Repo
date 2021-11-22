using System;

namespace HomeWork_9
{
    class HomeWork_9
    {
        static void Main(string[] args)
        {
            float rub;
            float usd;
            float rubToUsd = 70.98f;
            float usdToRub = 68.74f;
            float currencyCount;
            string stringCurrencyCount;
            bool succes = true;
            bool isActive = true;
            ConsoleKeyInfo answerKey;

            Console.Title = "Конвертер валют";

            Console.Write("Введите баланс в RUB: ");
            rub = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите баланс в USD: ");
            usd = Convert.ToSingle(Console.ReadLine());

            while (isActive)
            {
                Console.WriteLine("Меню управления валютами:\n1 - Конвертировать RUB в USD\n2 - Конвертировать USD в RUB\n3 - Выход");
                Console.Write("Выберите нужную функцию: ");
                answerKey = Console.ReadKey();

                Console.Clear();

                switch (answerKey.Key)
                {
                    case ConsoleKey.D1:
                        Console.Write("Сколько рублей конвертировать: ");
                        stringCurrencyCount = Console.ReadLine();

                        if (succes!=float.TryParse(stringCurrencyCount, out currencyCount)) 
                        {
                            Console.WriteLine("Ошибка ввода");
                        }

                        if (currencyCount>rub)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Недостаточно средств!");
                            Console.ResetColor();
                        }
                        else
                        {
                            rub -= currencyCount;
                            usd += currencyCount / rubToUsd;
                            Console.WriteLine($"Баланс {rub} - RUB, {usd} - USD");
                        }
                        break;

                    case ConsoleKey.D2:
                        Console.Write("\nСколько долларов конвертировать: ");
                        stringCurrencyCount = Console.ReadLine();

                        if (succes!=float.TryParse(stringCurrencyCount, out currencyCount))
                        {
                            Console.WriteLine("Ошибка ввода");
                        }

                        if (currencyCount>usd)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Недостаточно средств на счете!");
                            Console.ResetColor();
                        }
                        else
                        {
                            rub += currencyCount * usdToRub;
                            usd -= currencyCount;
                            Console.WriteLine($"Баланс {rub} - RUB, {usd} - USD");
                        }
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine("До новых встреч!");
                        isActive = false;
                        break;

                    default:
                        Console.WriteLine("Нет такой функции или ошибка ввода");
                        break;
                }
            }
        }
    }
}