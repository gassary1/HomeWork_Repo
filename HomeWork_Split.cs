using System;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            char seporator = ' ';
            string sourceString = "Показать выходные данные";
            string[] stringArary = sourceString.Split(seporator);

            foreach (var item in stringArary)
            {
                Console.WriteLine(item);
            }
        }
    }
}
