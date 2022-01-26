using System;

namespace HomeWork_20
{
    class HomeWork_20
    {
        static void Main(string[] args)
        {
            DrawBar(0, 10, ConsoleColor.Red, 0, '_');
            DrawBar(41, 10, ConsoleColor.Blue, 1, '_');

            static void DrawBar(uint percent, uint maxValue, ConsoleColor color, int position, char symbol)
            {
                double value = ((double)percent / 100) * maxValue;

                Console.SetCursorPosition(0, position);
                Console.Write("[");

                ConsoleColor defaultColor = Console.BackgroundColor;
                Console.BackgroundColor = color;

                for (int i = 0; i < Math.Round(value) && value > 0 && value <= maxValue; i++)
                {
                    Console.Write(symbol);
                }

                Console.BackgroundColor = defaultColor;

                for (double i = Math.Round(value); i < maxValue; i++)
                {
                    Console.Write(symbol);
                }

                Console.Write("]");
            }
        }
    }
}
