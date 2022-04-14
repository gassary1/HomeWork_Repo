using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isActive = true;
            ConsoleKey userKey;

            Bookcase bookcase = new Bookcase(10);

            while (isActive)
            {
                bookcase.ShowBookcase();
                PrintMenu();
                Console.Write("Введите опцию: ");
                userKey = Console.ReadKey().Key;

                Console.Clear();

                switch (userKey)
                {
                    case ConsoleKey.D1:
                        bookcase.AddBook();
                        break;
                    case ConsoleKey.D2:
                        bookcase.DeleteBook();
                        break;
                    case ConsoleKey.D3:
                        bookcase.RequestInfo(RequestOptions.Author);
                        break;
                    case ConsoleKey.D4:
                        bookcase.RequestInfo(RequestOptions.BookName);
                        break;
                    case ConsoleKey.D5:
                        bookcase.RequestInfo(RequestOptions.DateOfCreate);
                        break;
                    case ConsoleKey.D6:
                        isActive = false;
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("\n1 - Добавить книгу\n2 - Удалить книгу\n3 - Показать книги по автору" +
                "\n4 - Показать книги по названию или его части\n5 - Показать книги, выпущеные до...\n6 - Выход\n");
        }
    }

    enum RequestOptions
    {
        BookName,
        Author,
        DateOfCreate
    }

    class Book
    {
        public string BookName { get; }
        public string Author { get; }
        public DateTime DateOfCreate { get; }

        public Book(string bookName, string author, DateTime dateOfCreate)
        {
            BookName = bookName;
            Author = author;
            DateOfCreate = dateOfCreate;
        }

        public void ShofInfo()
        {
            Console.WriteLine($"{BookName,25} {Author,30} {DateOfCreate.ToShortDateString(),20}");
        }
    }

    class Bookcase
    {
        private static Random _random;
        private static readonly string[] _authorsFirstNames;
        private static readonly string[] _authorsLastNames;
        private static readonly string[] _firstBookNames;
        private static readonly string[] _secondBookNames;
        private static readonly string[] _lastBookNames;
        private List<Book> _books;

        static Bookcase()
        {
            _random = new Random();

            _authorsFirstNames = new string[]
            {
                "Иван",
                "Алексей",
                "Олег",
                "Вадим",
                "Сергей",
                "Дмитрий",
                "Денис",
                "Александр",
                "Игорь"
            };

            _authorsLastNames = new string[]
            {
                "Иванов",
                "Ким",
                "Пак",
                "Стрельцов",
                "Кругликов",
                "Ермаков",
                "Чеплыгин",
                "Нельга",
                "Андро",
                "Борисов",
                "Барецкий",
                "Бочкарев"
            };

            _firstBookNames = new string[]
            {
                "Весна",
                "Война",
                "Песнь",
                "Холод",
                "Братсво",
                "Огонь",
                "Меч",
                "Последний"
            };

            _secondBookNames = new string[]
            {
                "",
                "на",
                "-",
                "под",
                "над",
                "в",
                "из",
                "и"
            };

            _lastBookNames = new string[]
            {
                "Камень",
                "Стол",
                "Закат",
                "Деньги",
                "Кровь",
                "Свадьба",
                "Война",
                "Еда"
            };
        }

        public Bookcase(uint count)
        {
            string authorFullName;
            string bookName;

            _books = new List<Book>();

            for (int i = 0; i < count; i++)
            {
                authorFullName = _authorsFirstNames[_random.Next(_authorsFirstNames.Length)] + " " + _authorsLastNames[_random.Next(_authorsLastNames.Length)];
                bookName = _firstBookNames[_random.Next(_firstBookNames.Length)] + " " + _secondBookNames[_random.Next(_secondBookNames.Length)] + " " + _lastBookNames[_random.Next(_lastBookNames.Length)];
                _books.Add(new Book(bookName, authorFullName, RandomTime()));
            }
        }

        public void ShowBookcase()
        {
            int position = 1;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{"Название", 25} {"Автор", 30} {"Дата создания", 22}");
            Console.ResetColor();

            foreach (var book in _books)
            {
                Console.Write(position++);
                book.ShofInfo();
            }
        }

        public void AddBook()
        {
            Console.Write("\nВведите название книги: ");
            string bookName = Console.ReadLine();
            Console.Write("\nВведите автора: ");
            string author = Console.ReadLine();
            Console.Write("\nВведите дату создания книги, например 01.01.2000: ");
            DateTime dateOfCreate = GetDateTime();

            _books.Add(new Book(bookName, author, dateOfCreate));
        }

        public void DeleteBook()
        {
            Console.Write("\nВведите номер позиции книги: ");
            int currentPosition = GetNumber();

            if (currentPosition > 0 && currentPosition <= _books.Count && TryGetBook(currentPosition, out Book book))
            {
                _books.Remove(book);
            }
            else
            {
                Console.WriteLine("Неверный индекс игрока");
            }
        }

        public void RequestInfo(RequestOptions options)
        {
            List<Book> tempBookcase;
            string userInput;
            DateTime endDate;

            if (options.Equals(RequestOptions.BookName))
            {
                Console.WriteLine("\nВведите название книги или его часть: ");
                userInput = Console.ReadLine().ToLower();

                tempBookcase = _books.Where(book => book.BookName.ToLower().Contains(userInput)).ToList();

                ShowBookcase(tempBookcase);
            }
            if (options.Equals(RequestOptions.Author))
            {
                Console.WriteLine("\nВведите автора: ");
                userInput = Console.ReadLine().ToLower();

                tempBookcase = _books.Where(book => book.Author.ToLower().Contains(userInput)).ToList();

                ShowBookcase(tempBookcase);
            }
            if (options.Equals(RequestOptions.DateOfCreate))
            {
                Console.Write("\nВведите дату до которой написана книга, например 01.01.2000: ");
                endDate = GetDateTime();

                tempBookcase = _books.Where(book => book.DateOfCreate < endDate).ToList();

                ShowBookcase(tempBookcase);
            }
        }

        private DateTime RandomTime()
        {
            DateTime startTime = new DateTime(1960, 1, 1);
            int days = (DateTime.Now - startTime).Days;
            return startTime.AddDays(_random.Next(days));
        }

        private DateTime GetDateTime()
        {
            bool isActive = true;
            DateTime result = DateTime.MinValue;

            while (isActive)
            {
                string userInput = Console.ReadLine();

                if (DateTime.TryParse(userInput, out result))
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

        private int GetNumber()
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

        private bool TryGetBook(int currentPosition, out Book book)
        {
            int bookPosition = currentPosition - 1;
            book = null;

            if (_books[bookPosition] == null)
            {
                return false;
            }

            book = _books[bookPosition];
            return true;
        }

        private void ShowBookcase(List<Book> books)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{"Название",25} {"Автор",30} {"Дата создания",22}");
            Console.ResetColor();

            foreach (var book in books)
            {
                book.ShofInfo();
            }
        }
    }
}
