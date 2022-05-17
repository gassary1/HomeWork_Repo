using System;

//Вы задаете вопросы пользователю, по типу "как вас зовут", "какой ваш знак зодиака" и тд, после чего, по данным, которые он ввел, 
//формируете небольшой текст о пользователе.
//Вас зовут Алексей, вам 21 год, вы водолей и работаете на заводе."

namespace HomeWork_3
{
    class HomeWork_3
    {
        static void Main(string[] args)
        {
            int countOfPictures = 52;
            int columns = 3;

            int fullRows = countOfPictures / columns;
            int remainOfPictures = countOfPictures % columns;

            Console.WriteLine($"Всего заполненных рядов - {fullRows}\nОстаток фотографии - {remainOfPictures}");
            Console.ReadLine();
        }
    }
}
