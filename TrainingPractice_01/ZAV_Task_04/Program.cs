using System;

namespace ZAV_Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int typeOfBoss = random.Next(0, 10);
            int playerHealth = random.Next(700, 1000);
            int playerHealthFull = playerHealth;
            int bossHealth = random.Next(900, 1300);
            bool turn = Convert.ToBoolean(random.Next(0, 2));
            string playerEffects = "Нет";
            int playerAttack = 0;
            int damage = 0;
            int abyssAttackUses = 0;
            int playerHealing = 0;
            int theLastContractUses = 0;

            string typeOfBossString = null;
            switch (typeOfBoss)
            {
                case 0:
                    typeOfBossString = "Болотный Слизень";
                    break;
                case 1:
                    typeOfBossString = "Снежный Великан";
                    break;
                case 2:
                    typeOfBossString = "Красный Дракон";
                    break;
                case 3:
                    typeOfBossString = "Скелет-Воин";
                    break;
                case 4:
                    typeOfBossString = "Рыцарь Ужаса";
                    break;
                case 5:
                    typeOfBossString = "Король Минотавров";
                    break;
                case 6:
                    typeOfBossString = "Элементаль Магмы";
                    break;
                case 7:
                    typeOfBossString = "Могучая Горгона";
                    break;
                case 8:
                    typeOfBossString = "Великий Василиск";
                    break;
                case 9:
                    typeOfBossString = "Гидра Хаоса";
                    break;
            }

            Console.WriteLine("Игра - Победи БОССА");
            if (turn == true)
                Console.WriteLine($"Перед вами {typeOfBossString} атакуйте");
            else
                Console.WriteLine($"На вас напал(а) {typeOfBossString}");

            while (playerHealth > 0 && bossHealth > 0)
            {
                Console.WriteLine($"Здоровье игрока: {playerHealth}");
                Console.WriteLine($"Здоровье босса:  {bossHealth}");
                Console.WriteLine($"Эффекты:         {playerEffects}");

                Console.WriteLine("Выберите атуку (Чтобы выбрать введите номер атаки):");
                Console.WriteLine("1) Атака посохом (Атака: 50-100) - Слабая атака посохом.");
                Console.WriteLine("2) Призыв армии мёртвых (Урон по себе: 250, Атака: 10-25, Эффект: Армия мёртвых) " +
                                  "- Это заклинание лучше использывать с чём то другим.");
                Console.WriteLine("3) Атака Бездны (Условие: Армия мёртвых, Атака 100-200) - Бездна атакует врага.");
                Console.WriteLine("4) Последний контракт (Условие: Ваш уровень здоровья должен быть ниже 25%, " +
                                  "Восстановление здоровья: 250 - 500, Недостаток: Можно использывать один раз за бой)");
                Console.WriteLine("5) Армагеддон (Урон по себе: 25%, Атака 10%) - Вы вызываете армагеддон.");
                Console.WriteLine("0) Пропустить ход.");
                Console.WriteLine("Ваш выбор:");
                playerAttack = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                switch (playerAttack)
                {
                    case 0:
                        Console.WriteLine("0) Вы пропустили ход.");
                        Console.WriteLine();
                        break;
                    case 1:
                        Console.WriteLine($"1) Вы атаковали {typeOfBossString} на {damage = random.Next(50, 101)}");
                        Console.WriteLine();
                        bossHealth -= damage;
                        break;
                    case 2:
                        Console.WriteLine($"2) Вы призвали армию мёртвых и атаковали {typeOfBossString} на {damage = random.Next(10, 26)}" +
                                $"Вы потеряли 250 здоровья.");
                        Console.WriteLine();
                        playerEffects = "Армия мёртвых";
                        playerHealth -= 250;
                        bossHealth -= damage;
                        break;
                    case 3:
                        if (playerEffects == "Армия мёртвых")
                        {
                            abyssAttackUses++;
                            Console.WriteLine($"3) Вы успешно использовали Атаку Бездны и атаковали {typeOfBossString} на " +
                            $"{damage = random.Next(100, 201)}");
                            bossHealth -= damage;
                            if (abyssAttackUses == 2)
                            {
                                playerEffects = "Нет";
                                Console.WriteLine($"3) Эффект Армия мёртвых закончился.");
                            }
                            Console.WriteLine();
                        }
                        else 
                            Console.WriteLine($"3) Условие использования Атаки Бездны не соблюдено, вы пропускаете ход");
                        Console.WriteLine();
                        break;
                    case 4:
                        if (playerHealth < (playerHealthFull / 100) * 25 && theLastContractUses == 0)
                        {
                            theLastContractUses++;
                            Console.WriteLine($"4) Вы успешно использовали Последний контракт и восстановили себе" +
                                $" {playerHealing = random.Next(250, 501)} здоровья");
                            playerHealth += playerHealing;
                        }
                        else
                            Console.WriteLine($"4) Условие использования Последнего контракта не соблюдено, вы пропускаете ход");
                        Console.WriteLine();
                        break;
                    case 5:
                        Console.WriteLine($"5) Вы использовали Армагеддон. (Урон по себе: 25%, Атака 10%).");
                        playerHealthFull -= (playerHealthFull / 100) * 25;
                        bossHealth -= (bossHealth / 100) * 25;
                        break;
                    case 6:
                        typeOfBossString = "Элементаль Магмы";
                        break;
                    case 7:
                        typeOfBossString = "Могучая Горгона";
                        break;
                    case 8:
                        typeOfBossString = "Великий Василиск";
                        break;
                    case 9:
                        typeOfBossString = "Гидра Хаоса";
                        break;
                }
            }
        }
    }
}
