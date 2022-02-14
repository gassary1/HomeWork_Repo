using System;

namespace HomeWork_19
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullName;
            string position;
            string lastName;
            int countNotes;
            int noteIndex;
            bool isActive = true;
            ConsoleKey userOption;

            Console.WriteLine("Введите количество записей в досье (если значение будет больше 0, то произойдет автоматическое заполнение ячеек): ");
            countNotes = GetNumber();

            string[] fullNames = new string[countNotes];
            string[] positions = new string[fullNames.Length];
            FillDossier(fullNames, positions);

            Console.Clear();

            while (isActive)
            {
                PrintMenu();
                userOption = Console.ReadKey().Key;
                Console.Clear();

                switch (userOption)
                {
                    case ConsoleKey.D1:
                        PrintDossier(fullNames, positions);
                        break;

                    case ConsoleKey.D2:
                        Console.Write("Введите ФИО: ");
                        fullName = Console.ReadLine();
                        Console.Write("\nВведите должность: ");
                        position = Console.ReadLine();
                        AddDossier(fullName, position, ref fullNames, ref positions);
                        break;

                    case ConsoleKey.D3:
                        Console.Write("Введите номер позиции досье: ");
                        noteIndex = GetNumber();
                        DeleteDossier((uint)noteIndex, ref fullNames, ref positions);
                        break;

                    case ConsoleKey.D4:
                        Console.Write("Введите фамилию: ");
                        lastName = Console.ReadLine();
                        SearchByLastName(lastName, fullNames, positions);
                        break;

                    case ConsoleKey.D5:
                        isActive = false;
                        break;

                    default:
                        Console.WriteLine("Неизвестный выбор");
                        break;
                }
            }
        }

        static void PrintDossier(string[] names, string[] positions)
        {
            Console.WriteLine($"{"Позиция",2} {"ФИО",10} {"Должность",20}");

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{i + 1,4}) {names[i],17} - {positions[i],14}");
            }
        }

        static void FillDossier(string[] fullNames, string[] positions)
        {
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

            for (int i = 0; i < fullNames.Length; i++)
            {
                fullNames[i] = sourceFirstNames[random.Next(sourceFirstNames.Length)] + " " + sourceLastNames[random.Next(sourceLastNames.Length)];
                positions[i] = sourcePositions[random.Next(sourcePositions.Length)];
            }
        }

        static void SearchByLastName(string lastName, string[] fullNames, string[] positions)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < fullNames.Length ; i++)
            {
                if (fullNames[i].Contains(lastName))
                {
                    Console.WriteLine($"{i + 1,4}) {fullNames[i],17} - {positions[i],14}");
                }
            }

            Console.ResetColor();
        }

        static void AddDossier(string fullName, string position, ref string[] fullNames, ref string[] positions)
        {
            Array.Resize(ref fullNames, fullNames.Length + 1);
            fullNames[fullNames.Length - 1] = fullName;
            Array.Resize(ref positions, positions.Length + 1);
            positions[positions.Length - 1] = position;
        }

        static bool DeleteDossier(uint index, ref string[] fullNames, ref string[] positions)
        {
            bool result;

            if (index > 0 && index <= fullNames.Length)
            {
                for (uint i = index - 1; i < fullNames.Length - 1; i++)
                {
                    fullNames[i] = fullNames[i + 1];
                    positions[i] = positions[i + 1];
                }
                Array.Resize(ref fullNames, fullNames.Length - 1);
                Array.Resize(ref positions, positions.Length - 1);
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        static void PrintMenu() 
        {
            Console.WriteLine("1 - вывести все досье\n2 - добавить досье\n3 - удалить досье\n4 - поиск досье по фамилии\n5 - выход");
        }

        static int GetNumber()
        {
            bool isActive = true;
            int result = 0;

            while(isActive)
            {
                string userInput = Console.ReadLine();

                if(int.TryParse(userInput, out result))
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
