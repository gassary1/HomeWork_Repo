using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player firstPlayer = new Player(3, 10, '@');
            Player secondPlayer = new Player(6, 5, '*');

            DrawHandler firstDrawHandler = new DrawHandler(firstPlayer);
            DrawHandler secondDrawHandler = new DrawHandler(secondPlayer);

            firstDrawHandler.DrawPlayer();
            secondDrawHandler.DrawPlayer();

            Console.ReadLine();
        }
    }

    class Player
    {
        private int _xPosition;
        private int _yPosition;
        private char _playerSymbol;

        public int XPosition => _xPosition;
        public int YPosition => _yPosition;
        public char PlayerSymbol => _playerSymbol;

        public Player(int xPosition, int yPosition, char playerSymbol)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
            _playerSymbol = playerSymbol;
        }
    }

    class DrawHandler
    {
        private Player _player;

        public DrawHandler(Player player)
        {
            _player = player;
        }

        public void DrawPlayer()
        {
            Console.SetCursorPosition(_player.XPosition, _player.YPosition);
            Console.Write(_player.PlayerSymbol);
        }
    }
}
