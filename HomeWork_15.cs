using System;

namespace HomeWork_15
{
    class HomeWork_15
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[10, 10];
            int maxNumber = 0;
            Random random = new Random();

            Console.WriteLine("Исходная матрица:\n");

            for (int i=0; i<matrix.GetLength(0); i++)
            {
                for (int j=0; j<matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(6, 27);
                    if (maxNumber < matrix[i, j])
                    {
                        maxNumber = matrix[i, j];
                    }
                    Console.Write($"{matrix[i, j], 5}");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\nМаксимальное число в массиве равно - {maxNumber}. Полученная матрица:\n");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j]==maxNumber)
                    {
                        matrix[i, j] = 0;
                    }
                    Console.ResetColor();
                    Console.Write($"{matrix[i, j], 5}");
                }
                Console.WriteLine();
            }
        }
    }
}