using System;

namespace ConsoleApp16
{
    //Легенда: Вы – теневой маг(можете быть вообще хоть кем) и у вас в арсенале есть несколько заклинаний, которые вы можете использовать против Босса. Вы должны уничтожить босса и только после этого будет вам покой.
    //Формально: перед вами босс, у которого есть определенное кол-во жизней и определенный ответный урон.У вас есть 4 заклинания для нанесения урона боссу.Программа завершается только после смерти босса или смерти пользователя.
    //Пример заклинаний
    //Рашамон – призывает теневого духа для нанесения атаки (Отнимает 100 хп игроку)
    //Хуганзакура(Может быть выполнен только после призыва теневого духа), наносит 100 ед.урона
    //Межпространственный разлом – позволяет скрыться в разломе и восстановить 250 хп.Урон босса по вам не проходит
    //Заклинания должны иметь схожий характер и быть достаточно сложными, они должны иметь какие-то условия выполнения(пример - Хуганзакура). Босс должен иметь возможность убить пользователя.
    class Program
    {
        static void Main(string[] args)
        {
            int percent = 100;
            ConsoleKey userInput;
            bool fireballFlag = false;
            Random random = new Random();

            string playerName = "Sif";
            float playerHealth = random.Next(90, 101);
            int playerDamage = random.Next(5, 25);
            int playerArmor = random.Next(25, 35);

            string bossName = "Nito";
            float bossHealth = random.Next(95, 101);
            int bossDamage = random.Next(20, 35);
            int bossArmor = random.Next(35, 45);

            while (playerHealth > 0 && bossHealth > 0)
            {
                Console.WriteLine($"Имя игрока: {playerName} | Здоровье: {playerHealth} | Наносимый урон: {playerDamage} | Броня: {playerArmor}");
                Console.WriteLine($"Имя босса: {bossName} | Здоровье: {bossHealth} | Наносимый урон: {bossDamage} | Броня: {bossArmor}");

                PrintMenu();
                Console.WriteLine("\nВыберите действие: ");
                userInput = Console.ReadKey().Key;

                Console.Clear();

                if (userInput == ConsoleKey.D1)
                {
                    playerHealth -= Convert.ToSingle(random.Next(0, bossDamage)) / percent * playerArmor;
                    bossHealth -= DoFireball() / percent * bossArmor;

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Заклинание прошло!");
                    Console.ResetColor();

                    fireballFlag = true;
                }
                else if (userInput == ConsoleKey.D2)
                {
                    if (fireballFlag == true)
                    {
                        playerHealth -= Convert.ToSingle(random.Next(0, bossDamage)) / percent * playerArmor;
                        bossHealth -= DoFireJail() / percent * bossArmor;
                        fireballFlag = false;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Заклинание не прошло!");
                        Console.ResetColor();

                        playerHealth -= Convert.ToSingle(random.Next(0, bossDamage)) / percent * playerArmor;
                    }
                }
                else if (userInput == ConsoleKey.D3)
                {
                    DoAshenCloud();
                    bossHealth -= Convert.ToSingle(random.Next(0, playerDamage)) / percent * bossArmor;
                }
                else if (userInput == ConsoleKey.D4)
                {
                    if (playerHealth < 100)
                    {
                        playerHealth += DoEstuss();

                        if (playerHealth > 100)
                        {
                            playerHealth = 100;
                        }

                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Здоровье пополнено");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("У вас полное здоровье");
                        Console.ResetColor();
                    }
                }
                else
                {
                    playerHealth -= Convert.ToSingle(random.Next(0, bossDamage)) / percent * playerArmor;
                    bossHealth -= Convert.ToSingle(random.Next(0, playerDamage)) / percent * bossArmor;
                }
            }

            if (playerHealth == 0 && bossHealth == 0)
            {
                Console.WriteLine("Ничья");
            }
            else if (playerHealth <= 0)
            {
                Console.WriteLine($"{bossName} одержал победу");
            }
            else
            {
                Console.WriteLine($"{playerName} одержал победу");
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine($"\n1 - Скастовать заклинание ОГНЕННЫЙ ШАР\n2 - Скастовать заклинание ОГНЕННАЯ ТЮРЬМА\n3 - Скастовать заклинание ПЕПЕЛЬНОЕ ОБЛАКО\n4 - Скастовать заклинание ЭСТУСС");
        }

        static float DoFireball()
        {
            int value = 25;
            return value;
        }

        static float DoFireJail()
        {
            int value = 35;
            return value;
        }

        static void DoAshenCloud()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Вы скрылись от взора противника!");
            Console.ResetColor();
        }

        static int DoEstuss()
        {
            int value = 30;
            return value;
        }
    }
}
