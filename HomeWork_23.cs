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
            DrawArray(numbers);

            Console.WriteLine("\nМассив после перемешивания:");
            Shuffle(numbers);
        }

        static void Shuffle(int[] array)
        {
            Random random = new Random();

            for (int i = array.Length - 1; i >= 0; i--)
            {
                int j = random.Next(i+1);
                int temp = array[j];
                array[j] = array[i];
                array[i] = temp;
                Console.Write($"{array[i], 2}");
            }
        }

        static void DrawArray(int[] array)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 10);
                Console.Write($"{array[i], 2}");
            }
        }
    }
}
