using System;

namespace HomeWork_21
{
    class HomeWork_21
    {
        static void Main(string[] args)
        {
            int number = GetNumber();
            Console.WriteLine($"Полученное число - {number}");
        }

        static int GetNumber()
        {
            bool isActive = true;
            int result = 0;

            while (isActive)
            {
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out result))
                {
                    isActive = false;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода");
                }
            }
            return result;
        }
    }
}
