using System.Collections.Generic;
using System;

namespace HomeWork17
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> userCollection = new List<int>();
            int sum;
            int userNumber;
            string stringUserInput;
            bool isActive = true;

            Console.WriteLine("Вводите числа через Enter." +
                "\nДля подсчета суммы введите sum." +
                "\nДля выхода из программы и вывода полученного массива нажмите exit");

            while (isActive)
            {
                stringUserInput = Console.ReadLine();

                if (stringUserInput == "sum")
                {
                    sum = Sum(userCollection);
                    Console.WriteLine(sum);
                }

                else if (int.TryParse(stringUserInput, out userNumber))
                {
                    userCollection.Add(userNumber);
                }

                else if (stringUserInput == "exit")
                {
                    isActive = false;
                }

                else Console.WriteLine("Ошибка ввода данных");
            }

            PrintList(userCollection);
        }

        static void PrintList(List<int> collection)
        {
            foreach (var item in collection)
            {
                Console.Write($"{item,5}");
            }
        }

        static int Sum(List<int> collection)
        {
            int sum = 0;

            foreach (var item in collection)
            {
                sum += item;
            }

            return sum;
        }
    }
}
