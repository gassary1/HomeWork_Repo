using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = 1;
            int secondNumber = 29;
            int startPoint = 100;
            int endPoint = 1000;
            int multiply=1;
            int countOfNumbers = 0;
            Random random = new Random();
            int number = random.Next(firstNumber, secondNumber);

            Console.WriteLine($"Сгенерированное число: {number}");

            for (int i = number; i < endPoint; i = multiply * number)
            {
                multiply++;

                if (i >= startPoint)
                {
                    countOfNumbers++;
                }
            }

            Console.WriteLine($"Количество чисел, кратные {number}: {countOfNumbers}");
        }
    }
}
