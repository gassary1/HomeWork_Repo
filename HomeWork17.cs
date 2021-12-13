using System;

namespace HomeWork17
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] userArray = new int[1];
            int sum = 0;
            int userInput;
            string stringUserInput;
            bool isActive = true;

            for (int i = 0; i < userArray.Length; i++)
            {
                userArray[i] = Convert.ToInt32(Console.ReadLine());
            }

            while (isActive)
            {
                int[] tempArray = new int[userArray.Length + 1];

                for (int i = 0; i < userArray.Length; i++) 
                {
                    tempArray[i] = userArray[i];
                }

                stringUserInput = Console.ReadLine();

                if (stringUserInput == "sum")
                {
                    for (int i = 0; i < userArray.Length; i++)
                    {
                        sum += userArray[i];
                        isActive = false;
                    }
                }

                else if (int.TryParse(stringUserInput, out userInput))
                {
                    tempArray[userArray.Length] = userInput;
                    userArray = tempArray;
                }

                else Console.WriteLine("Ошибка ввода данных");
            }

            foreach (var item in userArray)
            {
                Console.Write($"{item,5}");
            }

            Console.WriteLine($"\nСумма равна {sum}");
        }
    }
}
