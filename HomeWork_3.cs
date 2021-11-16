using System;

namespace HomeWork_3
{
    class HomeWork_2
    {
        static void Main(string[] args)
        {
            int countOfPhoto = 52;
            int cols = 3;

            int fullRow = countOfPhoto / cols;
            int remainOfPhoto = countOfPhoto % cols;

            Console.WriteLine($"Всего заполненных рядов - {fullRow}\nОстаток фотографии - {remainOfPhoto}");
            Console.ReadLine();
        }
    }
}
