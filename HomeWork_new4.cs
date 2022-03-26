using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int number = random.Next(1, 100);
            int baseNumber = 2;

            Console.WriteLine($"Сгенерированное число: {number}");
            Console.WriteLine($"Минимальная степень: {FindMinimalDegree(number)}");
            Console.WriteLine($"Результат: {Math.Pow(baseNumber, FindMinimalDegree(number))}");
        }

        static int FindMinimalDegree(int number)
        {
            int result = 0;
            int degree = 0;
            int baseNumber = 2;

            for (int i = degree; number > Math.Pow(baseNumber, i); i++)
            {
                result = i;
            }

            return result + 1;
        }
    }
}
