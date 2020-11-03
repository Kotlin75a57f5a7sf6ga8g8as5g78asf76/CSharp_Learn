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
            int bossHealth = random.Next(900, 1300);
            bool turn = Convert.ToBoolean(random.Next(0, 2));

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

            Console.WriteLine($"Здоровье игрока: {playerHealth}");
            Console.WriteLine($"Здоровье босса:  {bossHealth}");

            Console.WriteLine("Выберите атуку (Чтобы выбрать введите номер атаки):");
            Console.WriteLine("1) Атака посохом (Атака: 50-100) - Слабая атака посохом.");
            Console.WriteLine("2) Призыв армии мёртвых (Урон по себе: 250, Атака: 10-25, Эффект: Армия мёртвых) " +
                              "- Это заклинание лучше использывать с чём то другим.");
            Console.WriteLine("3) Атака Бездны (Условие: Армия мёртвых, Атака 100-200) - Бездна атакует врага.");
            Console.WriteLine("4) Последний контракт (Условие: Ваш уровень здоровья должен быть ниже 25%, " +
                "Восстановление здоровья: 250 - 500, Недостаток: Можно использывать один раз за бой)");
            Console.WriteLine("5) ");
            Console.ReadLine();
        }
    }
}
