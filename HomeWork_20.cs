using System;

namespace HomeWork_20
{
    class HomeWork_20
    {
        static void Main(string[] args)
        {
            DrawBar(75, 10, ConsoleColor.Red, 0, '_');
            DrawBar(40, 10, ConsoleColor.Blue, 1, '_');

            static void DrawBar(uint value, uint maxValue, ConsoleColor color, int position, char symbol)
            {
                Console.SetCursorPosition(0, position);
                Console.Write("[");

                ConsoleColor defaultColor = Console.BackgroundColor;
                Console.BackgroundColor = color;

                for (int i = 0; i < (value * maxValue) / 100; i++)
                {
                    Console.Write(symbol);
                }

                Console.BackgroundColor = defaultColor;

                for (int i = 0; i < maxValue - (value * maxValue) / 100; i++)
                {
                    Console.Write(symbol);
                }

                Console.Write("]");
            }
        }
    }
}