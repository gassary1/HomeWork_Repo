using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int number = random.Next(1,28);
            int endNumber = 1000;
            int multiply;

            Console.WriteLine($"Сгенерированное число: {number}");
            Console.WriteLine($"Числа, кратные {number}:");

            for (int i = 100; i < endNumber; i++)
            {
                for (multiply = 1; number * multiply < endNumber; multiply++)
                {
                    if (i==number*multiply)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }
    }
}
