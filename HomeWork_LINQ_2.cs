using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            uint height;
            uint weight;
            string nationality;
            string userInput;
            bool isActive = true;

            Repository repository = new Repository(10);
            Repository requestRepository;

            while (isActive)
            {
                Console.WriteLine("1 - Cделать запрос\n2 - Выйти из программы");
                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Console.WriteLine("Список преступников:");
                    repository.PrintRepository();

                    Console.Write("\nВведите рост предполагаемого преступника: ");
                    height = (uint)GetNumber();
                    Console.Write("Введите вес предполагаемого преступника: ");
                    weight = (uint)GetNumber();
                    Console.Write("Введите национальность предполагаемого преступника: ");
                    nationality = Console.ReadLine().ToLower();
                    Console.Clear();

                    Console.WriteLine($"Результаты запроса: рост от {height} см. Вес от {weight} кг. Национальность - {nationality}");
                    requestRepository = repository.Request(height, weight, nationality);
                    requestRepository.PrintRepository();
                }
                else if (userInput =="2")
                {
                    isActive = false;
                }
                else
                {
                    Console.WriteLine("Ошиббка ввода");
                }
            }
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

    enum Nationality
    {
        Russian,
        German,
        Chinese,
        Japanese,
        Korean,
        Caucasian,
        Armenian,
        Georgian
    }

    class Criminal
    {
        private Nationality _nationality;
        private string _name;
        private string _lastName;
        private uint _height;
        private uint _weight;
        private bool _isConvicted;

        public string Name => _name;
        public string LastName => _lastName;
        public uint Height => _height;
        public uint Weight => _weight;
        public string IsConvicted => _isConvicted == true ? "Осужден" : "На свободе";

        public Criminal(string name, string lastName, Nationality nationality, uint height, uint weight, bool isConvicted)
        {
            _name = name;
            _lastName = lastName;
            _nationality = nationality;
            _height = height;
            _weight = weight;
            _isConvicted = isConvicted;
        }

        public string GetNationality()
        {
            switch (_nationality)
            {
                case Nationality.Russian:
                    return "Русский";
                case Nationality.German:
                    return "Немец";
                case Nationality.Chinese:
                    return "Китаец";
                case Nationality.Japanese:
                    return "Японец";
                case Nationality.Korean:
                    return "Кореец";
                case Nationality.Caucasian:
                    return "Кавказец";
                case Nationality.Armenian:
                    return "Арменин";
                case Nationality.Georgian:
                    return "Грузин";
                default:
                    return "-";
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name,10} {LastName,10} {GetNationality(),10} {Height,8} {Weight,6} {IsConvicted,15}");
        }
    }

    class Repository
    {
        private static Random _random;
        private static readonly string[] _names;
        private static readonly string[] _lastNames;
        private readonly bool _randomConvictedStatus;
        private List<Criminal> _criminals;

        static Repository()
        {
            _random = new Random();

            _names = new string[]
            {
                "Ахмед",
                "Николай",
                "Олег",
                "Хуан",
                "Раджеш",
                "Алесандр",
                "Иничи",
                "Роберт",
                "Николас",
                "Патрик"
            };

            _lastNames = new string[]
            {
                "Ли",
                "Ким",
                "Никидзе",
                "Джексон",
                "Хирокава",
                "Абудаби",
                "Иванов",
                "Огурцов",
                "Нолан",
                "Пэг",
                "Кейдж"
            };
        }

        public Repository(uint count)
        {
            _criminals = new List<Criminal>();

            for (int i = 0; i < count; i++)
            {
                _randomConvictedStatus = _random.Next(2) == 1 ? true : false;
                _criminals.Add(new Criminal(_names[_random.Next(_names.Length)], _lastNames[_random.Next(_lastNames.Length)],
                    (Nationality)_random.Next(Enum.GetValues(typeof(Nationality)).Length), (uint)_random.Next(60, 200),
                    (uint)_random.Next(40, 150), _randomConvictedStatus));
            }
        }

        private Repository(List<Criminal> criminals)
        {
            _criminals = criminals;
        }

        public void PrintRepository()
        {
            Console.WriteLine($"{"Имя",10} {"Фамилия",10} {"Национальность",10} {"Рост",5} {"Вес",5} {"Статус",15}");

            foreach (var criminal in _criminals)
            {
                criminal.ShowInfo();
            }
        }

        public Repository Request(uint height, uint weight, string nationality)
        {
            List<Criminal> tempCriminals = _criminals.Where(criminal => criminal.Height >= height &&
            criminal.Weight >= weight && criminal.GetNationality().ToLower() == nationality && criminal.IsConvicted == "На свободе").ToList();

            return new Repository(tempCriminals);
        }
    }
}
