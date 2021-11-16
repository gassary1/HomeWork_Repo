using System;

namespace HomeWork_3
{
    class HomeWork_4
    {
        static void Main(string[] args)
        {
            int gold;
            int counOfDiamond;
            int price = 15;

            Console.Write("Введите имеющееся количество золота: ");
            gold = Convert.ToInt32(Console.ReadLine());

            Console.Write($"Добро пожаловать! Сегодня алмазы стоят {price} золотых.\nСколько алмахов вы хотите купить? ");
            counOfDiamond = Convert.ToInt32(Console.ReadLine());

            gold -= price * counOfDiamond;

            Console.WriteLine($"Вы купили {counOfDiamond} алмазов. У вас осталось {gold} золота");
            Console.ReadLine();

        }
    }
}
