using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstCondition = 3;
            int secondCondition = 3;
            int sum = 0;
            Random random = new Random();
            int number = random.Next(1, 101);

            Console.WriteLine(number);

            for (int i = 1; i <= number; i++)
            {
                if (number > 0 && (i % firstCondition == 0 || i % secondCondition == 0))
                {
                    sum += i;
                    Console.WriteLine($"{i,5}");
                }
            }

            Console.WriteLine(sum);
        }
    }
}
