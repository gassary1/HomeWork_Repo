using System;

namespace ConsoleApp17
{
    //Дан массив чисел (минимум 10 чисел). Надо вывести в консоль числа отсортированы, от меньшего до большего.
    //Нельзя использовать Array.Sort.Можно найти подходящий алгоритм сортировки и использовать его для задачи.
    class Program
    {
        static void Main(string[] args)
        {
            int index;
            int tempNumber;

            int[] numbers = { 1, 12, 4, 9, 5, 2, 7, 20, 14, 1 };

            Console.WriteLine("Исходнный масссив: ");

            PrintArray(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                index = i;

                for (int j = i; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[index])
                    {
                        index = j;
                    }
                }

                if (numbers[index] == numbers[i])
                {
                    continue;
                }

                tempNumber = numbers[i];
                numbers[i] = numbers[index];
                numbers[index] = tempNumber;
            }

            Console.WriteLine("\nПосле сортировки: ");

            PrintArray(numbers);
        }

        static void PrintArray(int[] numbers)
        {
            foreach (int number in numbers)
            {
                Console.Write($"{number,4}");
            }
        }
    }
}
