using System;

namespace HomeWork_9
{
    class HomeWork_9
    {
        static void Main(string[] args)
        {
            float rub;
            float usd;
            float jpy;
            float usdToRub = 0.013f;
            float rubToUsd = 74.99f;
            float rubToJpy = 0.65f;
            float jpyToRub = 1.53f;
            float usdToJpy = 0.0087f;
            float jpyToUsd = 115.39f;
            float currencyCount;
            string stringCurrencyCount;
            bool isActive = true;
            ConsoleKeyInfo answerKey;

            Console.Title = "Конвертер валют";

            Console.Write("Введите баланс в RUB: ");
            rub = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите баланс в USD: ");
            usd = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите баланс в JPY: ");
            jpy = Convert.ToSingle(Console.ReadLine());

            while (isActive)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Баланс {rub} - рублей, {usd} - долларов, {jpy} - иен");
                Console.ResetColor();

                Console.WriteLine("\nМеню управления валютами:\n1 - Конвертировать рубли в доллары\n2 - Конвертировать доллары в рубли" +
                    "\n3 - Конвертировать рубли в иены\n4 - Конвертировать иены в рубли\n5 - Конвертировать доллары в иены" +
                    "\n6 - Конвертировать иены в доллары\n7 - Выход");
                Console.Write("Выберите нужную функцию: ");
                answerKey = Console.ReadKey();

                Console.Clear();

                switch (answerKey.Key)
                {
                    case ConsoleKey.D1:
                        Console.Write("Сколько рублей конвертировать: ");
                        stringCurrencyCount = Console.ReadLine();

                        if (float.TryParse(stringCurrencyCount, out currencyCount) == false)
                        {
                            Console.WriteLine("Ошибка ввода");
                        }

                        else if (currencyCount > rub)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Недостаточно средств!");
                            Console.ResetColor();
                        }
                        else
                        {
                            rub -= currencyCount;
                            usd += currencyCount / rubToUsd;
                        }
                        break;

                    case ConsoleKey.D2:
                        Console.Write("Сколько долларов конвертировать: ");
                        stringCurrencyCount = Console.ReadLine();

                        if (float.TryParse(stringCurrencyCount, out currencyCount) == false)
                        {
                            Console.WriteLine("Ошибка ввода");
                        }

                        else if (currencyCount > usd)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Недостаточно средств на счете!");
                            Console.ResetColor();
                        }
                        else
                        {
                            rub += currencyCount / usdToRub;
                            usd -= currencyCount;
                        }
                        break;

                    case ConsoleKey.D3:
                        Console.Write("Сколько рублей конвертировать: ");
                        stringCurrencyCount = Console.ReadLine();

                        if (float.TryParse(stringCurrencyCount, out currencyCount) == false)
                        {
                            Console.WriteLine("Ошибка ввода");
                        }

                        else if (currencyCount > rub)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Недостаточно средств на счете!");
                            Console.ResetColor();
                        }
                        else
                        {
                            rub -= currencyCount;
                            jpy += currencyCount / rubToJpy;
                        }
                        break;

                    case ConsoleKey.D4:
                        Console.Write("Сколько иен конвертировать: ");
                        stringCurrencyCount = Console.ReadLine();

                        if (float.TryParse(stringCurrencyCount, out currencyCount) == false)
                        {
                            Console.WriteLine("Ошибка ввода");
                        }

                        else if (currencyCount > jpy)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Недостаточно средств на счете!");
                            Console.ResetColor();
                        }
                        else
                        {
                            jpy -= currencyCount;
                            rub += currencyCount / jpyToRub;
                        }
                        break;

                    case ConsoleKey.D5:
                        Console.Write("Сколько долларов конвертировать: ");
                        stringCurrencyCount = Console.ReadLine();

                        if (float.TryParse(stringCurrencyCount, out currencyCount) == false)
                        {
                            Console.WriteLine("Ошибка ввода");
                        }

                        else if (currencyCount > usd)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Недостаточно средств на счете!");
                            Console.ResetColor();
                        }
                        else
                        {
                            usd -= currencyCount;
                            jpy += currencyCount / usdToJpy;
                        }
                        break;

                    case ConsoleKey.D6:
                        Console.Write("Сколько иен конвертировать: ");
                        stringCurrencyCount = Console.ReadLine();

                        if (float.TryParse(stringCurrencyCount, out currencyCount) == false)
                        {
                            Console.WriteLine("Ошибка ввода");
                        }

                        else if (currencyCount > jpy)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Недостаточно средств на счете!");
                            Console.ResetColor();
                        }
                        else
                        {
                            jpy -= currencyCount;
                            usd += currencyCount / jpyToUsd;
                        }
                        break;

                    case ConsoleKey.D7:
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
