using System;

//Попрактикуйтесь в создании переменных, объявить 10 переменных разных типов.
//Напоминание: переменные именуются с маленькой буквы, если название состоит из нескольких слов, то комбинируем их следующим образом - названиеПеременной.
//Также имя всегда должно отражать суть того, что хранит переменная.

namespace HomeWork_1
{
    class Program
    {
        static void Main(string[] args)
        {
            byte memory = 128;
            sbyte diskretValue = -3;

            short countOfDeparments = 32000;
            ushort countOfWorkers = 60000;

            int integerNumber = -5;
            uint unsignedIntegerNumber = 5;

            long distance = 9000000000000000000; 
            float speed = 64.6f;
            double resultOfDivision = 78.76532;

            string name = "Vadim";
            char specialSymbol = '#';

            bool answer = true;
        }
    }
}
