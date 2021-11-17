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
            int hoursOfWaiting;
            int minutesOfWaiting;

            Console.Write("Введите количество людей: ");
            countOfPepole = Convert.ToInt32(Console.ReadLine());

            timeOfWaiting = countOfPepole * timeOfService;
            hoursOfWaiting = timeOfWaiting / 60;
            minutesOfWaiting = timeOfWaiting % 60;

            Console.WriteLine($"Ожидание в очереди составит {hoursOfWaiting} ч. и {minutesOfWaiting} м.");
        }
    }
}
