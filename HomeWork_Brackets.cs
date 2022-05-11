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
            int deep;

            Console.Write("Введите скобочное выраженение: ");
            input = Console.ReadLine();

            if (input.Length == 0)
            {
                Console.WriteLine("Строка пустая");
            }

            if (CheckExpression(input))
            {
                Console.WriteLine("Скобочное выражение верное!");
                deep = ToDefineDeep(input);
                Console.WriteLine($"Глубина скобочного выражения равна - {deep}");
            }
            else
            {
                Console.WriteLine("Скобочное выражение неверное!");
            }
        }

        static bool CheckExpression(string input)
        {
            int count = 0;

            if (!input.StartsWith('('))
            {
                return false;
            }
            else
            {
                foreach (char symbol in input)
                {
                    if (symbol == '(')
                    {
                        count++;
                    }
                    else if (symbol == ')')
                    {
                        count--;
                    }
                }
            }
            return count == 0;
        }

        static int ToDefineDeep(string input)
        {
            int deep = 0;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == '(')
                {
                    if (input[i + 1] != ')')
                    {
                        deep++;
                    }
                }
            }

            return ++deep;
        }
    }
}
