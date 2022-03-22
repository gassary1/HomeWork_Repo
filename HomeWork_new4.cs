using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int number = random.Next(1, 100);
            int basenum = 2;
            int stepen;
            int x;

            Console.WriteLine($"Сгенерированное число: {number}");
            Console.WriteLine($"Минимальная степень: {Pow(number)}");
            Console.WriteLine($"Результат: {Math.Pow(basenum,Pow(number))}");


        }

        static int Pow(int number)
        {
            int result = 0;
            for (int i = 1; number > Math.Pow(2, i); i++)
            {
                result = i;
            }
            return result + 1;
        }
    }
}
