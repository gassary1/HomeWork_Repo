using System;

namespace HomeWork_23
{
    class HomeWork_23
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] numbers = new int[random.Next(4, 6)];

            Console.WriteLine("Исходный массив:");
            FillArray(numbers);
            PrintArray(numbers);

            Console.WriteLine("\nМассив после перемешивания:");
            Shuffle(numbers);
            PrintArray(numbers);
        }

        static void Shuffle(int[] array)
        {
            int randomIndex;
            int temp;
            Random random = new Random();

            for (int i = array.Length - 1; i >= 0; i--)
            {
                randomIndex = random.Next(i + 1);
                temp = array[randomIndex];
                array[randomIndex] = array[i];
                array[i] = temp;
            }
        }
        
        static void FillArray(int[] array)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 10);
            }
        }

        static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item, 2}");
            }
        }
    }
}
