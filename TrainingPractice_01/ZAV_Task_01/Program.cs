﻿using System;

namespace ZAV_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Стоимость 1 кристалла
            const int price = 100;
            int crystal = 0;

            Console.WriteLine("Введите колличество золота:");
            int gold = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Сколько кристаллов вы хотите купить? Курс 1 кр. = {price} золота");
            crystal = Convert.ToInt32(Console.ReadLine());

            if (gold < crystal * price)
            {
                Console.WriteLine($"Невозможно совершить покупку, так как у вас {gold} золота, а вы хотите купить {crystal} кристалов.");

            }
            else
            {
                gold = gold - crystal * price;
                Console.WriteLine($"Сделка удалась. У вас {gold} золота и {crystal} кристалов");
            }

        }
    }
}