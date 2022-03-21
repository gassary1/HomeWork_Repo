using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player firstPlayer = new Player(3, 10);
            firstPlayer.DrawPlayer('@');

            Player secondPlayer = new Player(6, 5);
            secondPlayer.DrawPlayer('*');

            Console.ReadLine();
        }
    }

    class Player
    {
        private int _xPosition;
        private int _yPosition;

        public int XPosition => _xPosition;
        public int YPosition => _yPosition;

        public Player(int xPosition, int yPosition)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
        }

        public void DrawPlayer(char playerSimbol)
        {
            Console.SetCursorPosition(XPosition, YPosition);

            Console.WriteLine(playerSimbol);
        }
    }
}
