using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string disease;
            bool isActive = true;
            ConsoleKey userOption;

            Repository repository = new Repository(20);
            Repository requestRepository;

            while (isActive)
            {
                Console.Clear();

                repository.PrintRepository();
                PrintMenu();

                Console.Write("\nВведите номер опции: ");
                userOption = Console.ReadKey().Key;

                if (userOption == ConsoleKey.D1)
                {
                    repository = repository.SortByName();
                }
                else if (userOption == ConsoleKey.D2)
                {
                    repository = repository.SortByAge();
                }
                else if (userOption == ConsoleKey.D3)
                {
                    Console.Write("\nВведите название заболевания: ");
                    disease = Console.ReadLine();

                    requestRepository = repository.RequestDisease(disease);
                    Console.WriteLine($"Список больных с заболеванием {disease.ToUpper()}");
                    requestRepository.PrintRepository();

                    Console.ReadLine();
                }
                else if (userOption == ConsoleKey.D4)
                {
                    isActive = false;
                }
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("\n1 - Отсортировать всех больных по имени\n2 - Отсортировать всех больных по возрасту\n3 - Вывести больных с определенным заболеванием\n4 - Выход");
        }
    }

    class Patient
    {
        private string _name;
        private string _lastName;
        private string _disease;
        private uint _age;

        public string Name => _name;
        public string LastName => _lastName;
        public string Disease => _disease;
        public uint Age => _age;

        public Patient(string name, string lastName, uint age, string disease)
        {
            _name = name;
            _lastName = lastName;
            _age = age;
            _disease = disease;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name,10} {LastName,10} {Age,5} {Disease,15}");
        }
    }

    class Repository
    {
        private static Random _random;
        private static readonly string[] _names;
        private static readonly string[] _lastNames;
        private static readonly string[] _diseases;
        private List<Patient> _patients;

        static Repository()
        {
            _random = new Random();

            _names = new string[]
            {
                "Вадим",
                "Олег",
                "Александр",
                "Елена",
                "Лилия",
                "Агата",
                "Дмитрий"
            };

            _lastNames = new string[]
            {
                "Пак",
                "Романенко",
                "Чеплыги",
                "Нельга",
                "Кан",
                "Круг",
                "Метал"
            };

            _diseases = new string[]
            {
                "Гастрит",
                "Туберкулез",
                "Диарея",
                "Катаракта",
                "Грипп",
                "Пневмония",
                "Отравление",
                "Гипертония",
                "Оспа"
            };
        }

        public Repository(uint count)
        {
            _patients = new List<Patient>();

            for (int i = 0; i < count; i++)
            {
                _patients.Add(new Patient(_names[_random.Next(_names.Length)], _lastNames[_random.Next(_lastNames.Length)],
                    (uint)_random.Next(18, 100), _diseases[_random.Next(_diseases.Length)]));
            }
        }

        private Repository(List<Patient> patients)
        {
            _patients = patients;
        }

        public void PrintRepository()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{"Имя",10} {"Фамилия",10} {"Возраст",5} {"Диагноз",13}");
            Console.ResetColor();

            foreach (var patient in _patients)
            {
                patient.ShowInfo();
            }
        }

        public Repository RequestDisease(string disease)
        {
            List<Patient> tempPatients = _patients.Where(patient => patient.Disease.ToLower() == disease.ToLower()).ToList();

            return new Repository(tempPatients);
        }

        public Repository SortByName()
        {
            List<Patient> tempPatients = _patients.OrderBy(patient => patient.Name).ToList();

            return new Repository(tempPatients);
        }

        public Repository SortByAge()
        {
            List<Patient> tempPatients = _patients.OrderBy(patient => patient.Age).ToList();

            return new Repository(tempPatients);
        }
    }
}
