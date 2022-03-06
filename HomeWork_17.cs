using System;

namespace HomeWork17
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] userArray = new int[0];
            int sum = 0;
            int userInput;
            string stringUserInput;
            bool isActive = true;

            Console.WriteLine("Вводите числа через Enter." +
                "\nДля подсчета суммы введите sum." +
                "\nДля выхода из программы и вывода полученного массива нажмите exit");

            while (isActive)
            {
                int[] tempArray = new int[userArray.Length + 1];

                stringUserInput = Console.ReadLine();

                if (stringUserInput == "sum")
                {
                    for (int i = 0; i < userArray.Length; i++)
                    {
                        sum += userArray[i];
                    }
                    Console.WriteLine($"\nСумма равна {sum}");
                    sum = 0;
                }

                else if (int.TryParse(stringUserInput, out userInput))
                {
                    tempArray[userArray.Length] = userInput;
                    for (int i = 0; i < userArray.Length; i++)
                    {
                        tempArray[i] = userArray[i];
                    }
                    userArray = tempArray;
                }

                else if (stringUserInput=="exit")
                {
                    isActive = false;
                }

                else Console.WriteLine("Ошибка ввода данных");
            }

            foreach (var item in userArray)
            {
                Console.Write($"{item,5}");
            }
        }
    }
}
