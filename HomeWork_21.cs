using System;

namespace HomeWork_21
{
    class HomeWork_21
    {
        static int TryConvertToInt32() 
        {
            while (true)
            {
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int result))
                {
                    return result;
                }

                else 
                {
                    Console.WriteLine("Ошибка ввода");
                } 
            }
        }

        static void Main(string[] args)
        {
            int a = TryConvertToInt32();
        }
    }
}