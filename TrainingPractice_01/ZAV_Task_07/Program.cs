using System;

namespace ZAV_Task_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Console.WriteLine("Введите размер массива: ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 100);
            }

            Console.WriteLine("\nИсходный массив:");
            PrintArray(array);

            Shuffle(array);
            Console.WriteLine("\nПеремешанный массив:");
            PrintArray(array);
        }
        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array[i]} ");
            Console.Write("\n");
        }
        static void Shuffle(int[] arr)
        {
            Random random = new Random();

            for (int i = arr.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);

                int tmp = arr[j];
                arr[j] = arr[i];
                arr[i] = tmp;
            }
        }
    }
}
