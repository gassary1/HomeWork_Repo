using System;

namespace ConsoleApp18
{
    //Дан массив чисел. Нужно его сдвинуть циклически на указанное пользователем значение позиций влево, не используя других массивов. Пример для сдвига один раз: {1, 2, 3, 4} => {2, 3, 4, 1}
    class Program
    {
        static void Main(string[] args)
        {
            int tempNumber;
            uint step;
            int[] numbers = { 1, 2, 3, 4, 5, 6 };

            Console.WriteLine("Введите число, на которое нужно сдвинуть массив: ");
            step = GetNumber();

            for (int i = 0; i < step; i++)
            {
                tempNumber = numbers[numbers.Length - 1];

                for (int j = numbers.Length - 1; j > 0; j--)
                {
                    numbers[j] = numbers[j - 1];
                }

                numbers[0] = tempNumber;
            }

            foreach (var number in numbers)
            {
                Console.Write($"{number,2}");
            }
        }

        static uint GetNumber()
        {
            bool isActive = true;
            uint result = 0;

            while (isActive)
            {
                string userInput = Console.ReadLine();

                if (uint.TryParse(userInput, out result))
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
