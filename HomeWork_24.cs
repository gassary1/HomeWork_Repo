using System.Collections.Generic;
using System;

namespace HomeWork17
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isActive = true;
            Dictionary<string, string> vocabulary = new Dictionary<string,string>();
            vocabulary.Add("home", "дом");
            vocabulary.Add("table", "стол");
            vocabulary.Add("console", "консоль");
            vocabulary.Add("head", "голова");

            Console.WriteLine("Введите слово на английском языке для получения перевода. Для выхода из программы наберите exit");

            while (isActive)
            {
                string userInput = Console.ReadLine();

                if (vocabulary.TryGetValue(userInput.ToLower(), out string value))
                {
                    Console.WriteLine($"Слово найдено. Перевод слова - {value}");
                }
                else if (userInput=="exit")
                {
                    Console.WriteLine("Работа с программой закончена");
                    isActive = false;
                }
                else
                {
                    Console.WriteLine("Такого слова нет");
                }
            }
        }
    }
}
