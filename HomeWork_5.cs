using System;

namespace HomeWork_3
{
    class HomeWork_5
    {
        static void Main(string[] args)
        {
            int countOfPepole;
            int timeOfService = 10;
            int timeOfWaiting;

            Console.Write("Введите количество людей: ");
            countOfPepole = Convert.ToInt32(Console.ReadLine());

            timeOfWaiting = countOfPepole * timeOfService;

            Console.WriteLine($"Ожидание в очереди составит {timeOfWaiting / 60} ч. и {timeOfWaiting % 60} м.");
        }
    }
}
