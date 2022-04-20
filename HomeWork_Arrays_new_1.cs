using System;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[30];
            FillArray(numbers);

            PrintArray(numbers);

            FindTheSameNumbers(numbers);
        }

        static void FillArray(int[] array)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1,11);
            }
        }

        static void PrintArray(int[] array)
        {
            Console.WriteLine("Печать исходного массива:");

            foreach (var number in array)
            {
                Console.Write($"{number, 3}");
            }
        }

        static void FindTheSameNumbers(int[] array)
        {
            int index = 0;
            int count = 1;
            int maxCount = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[i - 1])
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
                if (count >= maxCount)
                {
                    maxCount = count;
                    index = i;
                }
            }

            Console.WriteLine($"\nСамое часто повторяющееся подряд число - {array[index]}. Количество повторений - {maxCount}");
        }
    }
}
