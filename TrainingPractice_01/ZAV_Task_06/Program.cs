using System;

namespace ZAV_Task_06
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fullName = new string[0];
            string[] post = new string[0];
            while (true)
            {
                drawMenu();
                ConsoleKeyInfo menuChoice = Console.ReadKey();
                switch (menuChoice.KeyChar)
                {
                    case '1':
                        AddDossier(ref fullName, ref post);
                        break;
                    case '2':
                        SnowDossier(fullName, post);
                        break;
                    case '3':
                        DeleteDossier(ref fullName, ref post);
                        break;
                    case '4':
                        SearchLastName(fullName, post);
                        break;
                    case '5':
                       Console.WriteLine("\nЗавершение работы программы.");
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Вы не ввели пункт меню.\n");
                        break;
                }
            }
        }

        static void AddDossier(ref string[] fullName, ref string[] post)
        {
            IncreaseArraysSizeBy1(ref fullName, ref post);
            Console.WriteLine("\nДобавление досье:\n");
            Console.WriteLine("Введите фамилию: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Введите имя: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите отчество: ");
            string patronymic = Console.ReadLine();
            Console.WriteLine("Введите должность: ");
            string position = Console.ReadLine();

            fullName[fullName.Length - 1] = surname + ' ' + name + ' ' + patronymic;
            post[post.Length - 1] = position;
            Console.WriteLine($"\nВ базу добавлен {surname + ' ' + name + ' ' + patronymic} с должностью {position}, номер: {fullName.Length}");
        }
        static void IncreaseArraysSizeBy1(ref string[] fullNameExpand, ref string[] postExpand)
        {
            // Увеличиваем fullName
            string[] tempArray = new string[fullNameExpand.Length + 1];
            for (int i = 0; i < fullNameExpand.Length; i++)
            {
                tempArray[i] = fullNameExpand[i];
            }
            fullNameExpand = tempArray;
            // Увеличиваем post
            tempArray = new string[postExpand.Length + 1];
            for (int i = 0; i < postExpand.Length; i++)
            {
                tempArray[i] = postExpand[i];
            }
            postExpand = tempArray;
        }

        static void SnowDossier(string[] fullName, string[] post)
        {
            Console.WriteLine("\n\nВсе досье:");
            for (int i = 0; i < fullName.Length; i++)
            {
                Console.WriteLine(string.Concat(new string[]
                {
                        (i + 1).ToString(), "\t", fullName[i], "\t - ", post[i]
                }));
            }
            Console.WriteLine();
        }
        private static void DeleteDossier(ref string[] fullName, ref string[] post)
        {
            Console.Write("\nВведите номер досье для удаления: ");
            string s = Console.ReadLine();
            int num;
            bool isValid = int.TryParse(s, out num);
            if (isValid)
            {
                bool isLenght = num <= fullName.Length && num >= 1;
                if (isLenght)
                {
                    Program.DeleteArrayItem(ref fullName, num);
                    Program.DeleteArrayItem(ref post, num);
                    Console.WriteLine("Досье удалено успешно.");
                }
                else
                    Console.WriteLine("Досье с таким номером не существует");
            }
            else
                Console.WriteLine("Вы ввели неправильное значение");
        }
        private static void DeleteArrayItem(ref string[] decreasingArray, int itemDelete)
        {
            string[] array = new string[decreasingArray.Length - 1];
            int num = 0;
            for (int i = 0; i < decreasingArray.Length; i++)
            {
                bool flag = i + 1 != itemDelete;
                if (flag)
                    array[i + num] = decreasingArray[i];
                else
                    num = -1;
            }
            decreasingArray = array;
        }
        private static void SearchLastName(string[] fullName, string[] post)
        {
            int num = 0;
            bool isLenght = fullName.Length != 0;
            if (isLenght)
            {
                Console.Write("\nВведите фамилию для поиска: ");
                string text = Console.ReadLine();
                Console.WriteLine();
                for (int i = 0; i < fullName.Length; i++)
                {
                    bool isSurname = fullName[i].StartsWith(text + " ");
                    if (isSurname)
                    {
                        num++;
                        Console.WriteLine(string.Concat(new string[]
                        {
                            num.ToString(), "\t", fullName[i], "\t - ", post[i]
                        }));
                    }
                }
                bool flag3 = num > 0;
                if (flag3)
                    Console.WriteLine($"Количество сотрудников с фамилией {text} - {num}");
                else
                    Console.WriteLine("Сотрудников с фамилией " + text + " нет");
            }
            else
                Console.WriteLine("Отсутствуют какие-либо досье");
            Console.WriteLine("\nНажмите любую клавишу.");
            Console.ReadKey();
            Console.Clear();
        }

        static void drawMenu()
        {
            Console.WriteLine("Меню программы:" +
                    "\n1) Добавить досье.  " +
                    "\n2) Вывести все досье." +
                    "\n3) Удалить досье. " +
                    "\n4) Поиск по фамилии. " +
                    "\n5) Выход" +
                    "\nВыберите пункт меню: ");
        }
    }
}
