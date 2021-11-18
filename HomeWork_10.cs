using System;

namespace HomeWork_10
{
    class HomeWork_10
    {
        static void Main(string[] args)
        {
            #region Variables / Raw Data

            bool isActive = true;
            bool succes;
            string name = string.Empty;
            string surname = string.Empty;
            string stringAge = string.Empty;
            string stringIncome = string.Empty;
            string stringConsumption = string.Empty;
            int income = 0;
            int consumption = 0;
            int profit = 0;
            int age = 0;

            #endregion

            #region Program control menu

            while (isActive)
            {
                Console.WriteLine("Меню управления финансами:\n1 - Ввод имени\n2 - Ввод фамилии" +
                    "\n3 - Ввод возраста\n4 - Ввод дохода\n5 - Ввод расходов\n6 - Расчет прибыли" +
                    "\n7 - Печать информации\n8 - Выход");

                Console.Write("Выберите нужную функцию: ");

                ConsoleKeyInfo answerKey = Console.ReadKey();

                Console.Clear();

                switch (answerKey.Key)
                {

                    case ConsoleKey.D1:
                        Console.Write("Введите свое имя: ");
                        name = Console.ReadLine();
                        break;

                    case ConsoleKey.D2:
                        Console.Write("Введите свою фамилию: ");
                        surname = Console.ReadLine();
                        break;

                    case ConsoleKey.D3:
                        Console.Write("Введите свой возраст: ");
                        stringAge = Console.ReadLine();
                        succes = int.TryParse(stringAge, out age);
                        if (!succes)
                        {
                            Console.WriteLine("Ошибка ввода данных");
                        } 
                        break;

                    case ConsoleKey.D4:
                        Console.Write("Введите свой доход: ");
                        stringIncome = Console.ReadLine();
                        succes = int.TryParse(stringIncome, out income);
                        if (!succes)
                        {
                            Console.WriteLine("Ошибка ввода данных");
                        }
                        break;

                    case ConsoleKey.D5:
                        Console.Write("Введите свои затраты: ");
                        stringConsumption = Console.ReadLine();
                        succes = int.TryParse(stringConsumption, out consumption);
                        if (!succes)
                        {
                            Console.WriteLine("Ошибка ввода данных");
                        }
                        break;

                    case ConsoleKey.D6:
                        profit = income - consumption;
                        Console.WriteLine($"Вваш доход составляет - {profit}");
                        if (profit == 0)
                        {
                            Console.WriteLine("Недостаточно данных для расчета или прибыль равна 0");
                        }
                        else if (profit < 0)
                        {
                            Console.WriteLine("Дохода нет...одни убытки");
                        }
                        break;

                    case ConsoleKey.D7:
                        Console.WriteLine($"Ваше имя - {name}\nВаша фамилия - {surname}\nВаш возраст - {age}" +
                            $"\nДоход составляет - {income}\nРасход составляет - {consumption}" +
                            $"\nВаща прибыль - {profit}");
                        break;

                    case ConsoleKey.D8:
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
