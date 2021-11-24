using System;

namespace HomeWork_16
{
    class HomeWork_16
    {
        static void Main(string[] args)
        {
            int[] matrix = new int[30];
            Random random = new Random();

            Console.WriteLine("Дан массив чисел:\n");

            for (int i=0; i<matrix.Length; i++)
            {
                matrix[i] = random.Next(1, 10);
                Console.Write($"{matrix[i], 3}");
            }

            Console.WriteLine("\n\nЛокальные максимумы данного массива:\n");

            Console.ForegroundColor = ConsoleColor.Red;

            if (matrix[0] > matrix[1])
            {
                Console.Write($"{matrix[0],5}");
            }

            Console.ResetColor();

            for (int i = 1; i < matrix.Length-1; i++)
            {
                if (matrix[i] > matrix[i - 1] && matrix[i] > matrix[i + 1])
                {
                    Console.Write($"{matrix[i],5}");
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;

            if (matrix[matrix.Length - 1] > matrix[matrix.Length - 2])
            {
                Console.Write($"{matrix[matrix.Length-1], 5}");
            }

            Console.ResetColor();
        }
    }
}
