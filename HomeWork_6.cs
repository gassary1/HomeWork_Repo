using System;

namespace HomeWork_3
{
    class HomeWork_6
    {
        static void Main(string[] args)
        {
            string name, surname, specialization;
            int age;

            Console.Write("Введите ваше имя: ");
            name = Console.ReadLine();
            Console.Write("Введите вашу фамилию: ");
            surname = Console.ReadLine();
            Console.Write("Введите ваш возраст: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите вашей специализацию: ");
            specialization = Console.ReadLine();

            Console.WriteLine($"Ваше имя - {name}. Ваша фамилия - {surname}." +
                $"\nВаш возраст составляет {age} лет.\nСпециализация - {specialization}");
        }
    }
}
