using System;

namespace HomeWork_3
{
    class HomeWork_3
    {
        static void Main(string[] args)
        {
            int countOfPictures = 52;
            int columns = 3;

            int fullRow = countOfPictures / columns;
            int remainOfPhoto = countOfPictures % columns;

            Console.WriteLine($"Всего заполненных рядов - {fullRow}\nОстаток фотографии - {remainOfPhoto}");
            Console.ReadLine();
        }
    }
}
