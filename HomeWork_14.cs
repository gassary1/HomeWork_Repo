using System;

namespace HomeWork_14
{
    class HomeWork_14
    {
        static void Main(string[] args)
        {
            int column = 1;
            int row = 2;
            int sum = 0;
            int multiplication = 1;

            Random random = new Random();

            int[,] matrix = new int[3, 3];

            Console.WriteLine("Мсходная матрица:");
            for (int i = 0; i < matrix.GetLength(0); i++) 
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(3, 26);
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum += matrix[row-1, j];
            }

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                multiplication *= matrix[i, column-1];
            }

            Console.WriteLine($"Результат сложения строки №{row} - {sum}");
            Console.WriteLine($"Результат умножения столбца №{column} - {multiplication}");
        }
    }
}