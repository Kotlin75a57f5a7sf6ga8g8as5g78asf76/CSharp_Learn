using System;

namespace ZAV_Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string exitString = null;

            //Цикл пока строчка exitString не равна exit или Exit
            while (exitString != "exit" & exitString != "Exit")
            {
                Console.WriteLine("Чтобы завершить программу введите exit");
                exitString = Convert.ToString(Console.ReadLine());
            }
        }
    }
}
