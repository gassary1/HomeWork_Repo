using System;

namespace HomeWork_20
{
    class HomeWork_20
    {
        static void Main(string[] args)
        {
            DrawBar(100, 10, ConsoleColor.Red, 0, '_');
            DrawBar(40, 10, ConsoleColor.Blue, 1, '_');

            static void DrawBar(uint percent, uint maxValue, ConsoleColor color, int position, char symbol)
            {
                double value = ((double)percent / 100) * maxValue;

                Console.SetCursorPosition(0, position);
                Console.Write("[");

                ConsoleColor defaultColor = Console.BackgroundColor;
                Console.BackgroundColor = color;

                for (int i = 0; i < value && value > 0 && value < 100; i++)
                {
                    Console.Write(symbol);
                }

                Console.BackgroundColor = defaultColor;

                for (double i = value; i < maxValue; i++)
                {
                    Console.Write(symbol);
                }

                Console.Write("]");
            }
        }
    }
}
