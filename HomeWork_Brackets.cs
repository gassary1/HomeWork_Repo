using System;

namespace ConsoleApp21
{
    //Дана строка из символов '(' и ')'. Определить, является ли она корректным скобочным выражением. Определить максимальную глубину вложенности скобок.
    //Пример “(()(()))” - строка корректная и максимум глубины равняется 3.
    //Пример не верных строк: "(()", "())", ")(", "(()))(()"

    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int deep = 0;
            int maxDeep = 0;

            Console.Write("Введите скобочное выраженение: ");
            input = Console.ReadLine();

            if (input.Length == 0)
            {
                Console.WriteLine("Строка пустая");
            }

            foreach (char symbol in input)
            {
                if (symbol == '(')
                {
                    deep++;

                    if (deep > maxDeep)
                    {
                        maxDeep = deep;
                    }
                }
                else if (symbol == ')')
                {
                    deep--;

                    if (deep < 0)
                    {
                        break;
                    }
                }
            }

            if (deep == 0 && input.StartsWith('('))
            {
                Console.WriteLine($"Скобочное выражение верное. Максимальная глубина равна - {maxDeep}");
            }
            else
            {
                Console.WriteLine("Скобочное выражение неверное!");
            }
        }
    }
}
