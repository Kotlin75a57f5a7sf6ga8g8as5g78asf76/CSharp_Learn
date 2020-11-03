using System;

namespace ZAV_Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Пароль
            const string password = "12345";

            string userPassword = null;
            int mistakes = 0;

            // Цикл до 3 ошибок
            while (mistakes != 3)
            {
                Console.WriteLine($"Введите пароль, осталось попыток {3 - mistakes}.");
                userPassword = Convert.ToString(Console.ReadLine());

                if (userPassword == password)
                {
                    Console.WriteLine("Cекретное сообщение =)");
                    break;
                }
                mistakes++;
            }
        }
    }
}
