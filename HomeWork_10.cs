using System;

namespace HomeWork_10
{
    class HomeWork_10
    {
        static void Main(string[] args)
        {
            #region Переменные/Исходные данные

            bool isActive = true;
            string name = string.Empty;
            string surname = string.Empty;
            int age = 0;
            int income = 0;
            int consumption = 0;
            int profit = 0;

            #endregion

            #region Меню управления программой

            while (isActive)
            {
                Console.WriteLine("Меню управления финансами:\n1 - Ввод имени\n2 - Ввод фамилии" +
                    "\n3 - Ввод возраста\n4 - Ввод дохода\n5 - Ввод расходов\n6 - Расчет прибыли" +
                    "\n7 - Печать информации\n8 - Выход");
                Console.Write("Выберите нужную функцию: ");

                ConsoleKeyInfo answerKey = Console.ReadKey();

                switch (answerKey.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.Write("Введите свое имя: ");
                        name = Console.ReadLine();
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.Write("Введите свою фамилию: ");
                        surname = Console.ReadLine();
                        break;

                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.Write("Введите свой возраст: ");
                        try { age = Convert.ToInt32(Console.ReadLine()); }
                        catch { Console.WriteLine("Введено некорректное значение"); }
                        break;

                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.Write("Введите свой доход: ");
                        try { income = Convert.ToInt32(Console.ReadLine()); }
                        catch { Console.WriteLine("Введено некорректное значение"); }
                        break;

                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.Write("Введите свои затраты: ");
                        try { consumption = Convert.ToInt32(Console.ReadLine()); }
                        catch { Console.WriteLine("Введено некорректное значение"); }
                        break;

                    case ConsoleKey.D6:
                        Console.Clear();
                        profit = income - consumption;
                        Console.WriteLine($"Вваш доход составляет - {profit}");
                        if (profit == 0) Console.WriteLine("Недостаточно данных для расчета или прибыль равна 0");
                        break;

                    case ConsoleKey.D7:
                        Console.Clear();
                        Console.WriteLine($"Ваше имя - {name}\nВаша фамилия - {surname}\nВаш возраст - {age}" +
                            $"\nДоход составляет - {income}\nРасход составляет - {consumption}" +
                            $"\nВаща прибыль - {profit}");
                        break;

                    case ConsoleKey.D8:
                        Console.Clear();
                        Console.WriteLine("До новых встреч!");
                        isActive = false;
                        break;

                    default:
                        Console.WriteLine("Нет такой команды");
                        break;
                }

            }

            #endregion
        }
    }
}