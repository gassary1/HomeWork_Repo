using System.Collections.Generic;
using System;

namespace HomeWork17
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNotes;
            bool isActive = true;
            ConsoleKey userOption;

            List<KeyValuePair<string, string>> dossiers = new List<KeyValuePair<string, string>>();

            Console.WriteLine("Введите количество записей досье (если значение будет больше 0, то произойдет автоматическое заполнение ячеек): ");
            countNotes = GetNumber();
            FillDossiers(dossiers, countNotes);

            Console.Clear();

            while (isActive)
            {
                PrintMenu();
                userOption = Console.ReadKey().Key;
                Console.Clear();

                switch (userOption)
                {
                    case ConsoleKey.D1:
                        AddDossier(dossiers);
                        break;

                    case ConsoleKey.D2:
                        PrintDossiers(dossiers);
                        break;

                    case ConsoleKey.D3:
                        DeleteDossier(ref dossiers);
                        break;

                    case ConsoleKey.D4:
                        isActive = false;
                        break;

                    default:
                        Console.WriteLine("Ошибка ввода");
                        break;
                }
            }

        }

        static KeyValuePair<string, string> CreateData()
        {
            string fullNames;
            string positions;
            KeyValuePair<string, string> sourceData;

            Random random = new Random();

            string[] sourceFirstNames = new string[]
            {
                "Вадим",
                "Олег",
                "Александр",
                "Елена",
                "Лилия",
                "Агата",
                "Дмитрий"
            };

            string[] sourceLastNames = new string[]
            {
                "Пак",
                "Романенко",
                "Чеплыги",
                "Нельга",
                "Кан",
                "Круг",
                "Метал"
            };

            string[] sourcePositions = new string[]
            {
                "Инженер",
                "Бухгалтер",
                "Логист",
                "Инженер 2 категории",
                "Заместитель инженера",
                "Тестировщик",
                "Сантехник"
            };

            fullNames = sourceFirstNames[random.Next(sourceFirstNames.Length)] + " " + sourceLastNames[random.Next(sourceLastNames.Length)];
            positions = sourcePositions[random.Next(sourcePositions.Length)];
            sourceData = new KeyValuePair<string, string>(positions, fullNames);

            return sourceData;
        }

        static void FillDossiers(List<KeyValuePair<string, string>> list, int count)
        {
            for (int i = 0; i < count; i++)
            {
                list.Add(CreateData());
            }
        }

        static void PrintDossiers(List<KeyValuePair<string, string>> list)
        {
            int currentPosition = 1;

            Console.WriteLine("Печать досье сотрудников");

            foreach (KeyValuePair<string, string> item in list)
            {
                Console.WriteLine($"{currentPosition++}){item.Value} - {item.Key}");
            }
        }

        static bool DeleteDossier(ref List<KeyValuePair<string, string>> list)
        {
            Console.Write("Введите номер записи: ");
            int noteIndex = GetNumber();
            int currentPosition = noteIndex - 1;

            if (noteIndex > 0 && noteIndex <= list.Count)
            {
                list.Remove(list[currentPosition]);
                return true;
            }
            else
            {
                return false;
            }
        }

        static void AddDossier(List<KeyValuePair<string, string>> list)
        {
            KeyValuePair<string, string> newDossier;

            Console.Write("Введите ФИО: ");
            string fullName = Console.ReadLine();
            Console.Write("\nВведите должность: ");
            string position = Console.ReadLine();

            newDossier = new KeyValuePair<string, string>(position, fullName);
            list.Add(newDossier);
        }

        static void PrintMenu()
        {
            Console.WriteLine("1 - Добавить досье\n2 - Печать досье сотрудников\n3 - Удалить досье\n4 - Выход");
        }

        static int GetNumber()
        {
            bool isActive = true;
            int result = 0;

            while (isActive)
            {
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out result))
                {
                    isActive = false;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода");
                }
            }
            return result;
        }
    }
}
