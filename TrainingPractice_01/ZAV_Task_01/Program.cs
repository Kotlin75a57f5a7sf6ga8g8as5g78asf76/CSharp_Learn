using System;

namespace ZAV_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Стоимость 1 кристалла
            const int price = 100;

            Console.WriteLine("Введите колличество золота:");
            int gold = Convert.ToInt32(Console.ReadLine());

            // Проверяем возможна ли покупка в магазине
            while (gold < price)
            {
                Console.WriteLine($"Вы не можете зайти в магазин пока ваще золото не будет больше {price} иначе вы ничего не сможете купить.");
                Console.WriteLine("Введите колличество золота:");
                gold = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine($"Сколько кристаллов вы хотите купить? Курс 1 кр. = {price} золота");
            int crystal = Convert.ToInt32(Console.ReadLine());

            bool flag = Convert.ToBoolean(gold / (crystal * price));
            
            // Используем цикл while вместо if else.
            while (!flag)
            {
                Console.WriteLine($"Невозможно совершить покупку, так как у вас {gold} золота, а вы хотите купить {crystal} кристалов."); ;
                Console.WriteLine($"Сколько кристаллов вы хотите купить? Курс 1 кр. = {price} золота");
                crystal = Convert.ToInt32(Console.ReadLine());

                flag = Convert.ToBoolean(gold / (crystal * price));
            }

            gold = gold - crystal * price;

            Console.WriteLine($"Сделка удалась. У вас {gold} золота и {crystal} кристалов");
        }
    }
}
