using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = 1;
            int secondNumber = 29;
            int startPoint;
            int endPoint = 1000;
            int multiply;
            Random random = new Random();
            int number = random.Next(firstNumber, secondNumber);

            Console.WriteLine($"Сгенерированное число: {number}");
            Console.WriteLine($"Числа, кратные {number}:");

            for (startPoint = 100; startPoint < endPoint; startPoint++)
            {
                for (multiply = 1; number * multiply < endPoint; multiply++)
                {
                    if (startPoint==number*multiply)
                    {
                        Console.WriteLine(startPoint);
                    }
                }
            }
        }
    }
}
