using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Timers;
using System.Threading;
using System.Threading.Tasks;

namespace ZAV_Task_05
{
	class Program
	{
		const int turns = 200;
		static int bar = -1;
		static bool gameRun = true;
		private static void Main(string[] args)
		{
			Console.CursorVisible = false;
			char[,] map = Program.ReadMap("level01", out int playerX, out int playerY);
			Program.SetConsole(100, 40);
			Program.DrawMap(map);
			int[] current_location = new int[2] { playerX, playerY };
			while (gameRun)
			{
				playerMove(current_location, map);
			}
		}

		private static void playerMove(int[] current_location, char[,] map)
		{
			Console.SetCursorPosition(35, 16);
			Console.Write("Ваше последнее действие");
			Console.SetCursorPosition(35, 17);
			char player_movement = Console.ReadKey().KeyChar;
			switch (player_movement)
			{
				case 'ц':
				case 'Ц':
				case 'W':
				case 'w':
					{

						if (map[current_location[0] - 1, current_location[1]] == ' ')
						{
							Bar();
							drawChar(current_location, map, ' ');
							current_location[0] -= 1;
							if (map[current_location[0] - 1, current_location[1]] == 'E')
								gameWin();
							drawChar(current_location, map, '■');
						}

						break;
					}
				case 'Ф':
				case 'ф':
				case 'A':
				case 'a':
					{
						if (map[current_location[0], current_location[1] - 1] == ' ')
						{
							Bar();
							drawChar(current_location, map, ' ');
							current_location[1] -= 1;
							if (map[current_location[0], current_location[1] - 1] == 'E')
								gameWin();
							drawChar(current_location, map, '■');
						}
						break;
					}
				case 'S':
				case 'ы':
				case 'Ы':
				case 's':
					{
						if (map[current_location[0] + 1, current_location[1]] == ' ')
						{
							Bar();
							drawChar(current_location, map, ' ');
							current_location[0] += 1;
							if (map[current_location[0] + 1, current_location[1]] == 'E')
								gameWin();
							drawChar(current_location, map, '■');
						}
						break;
					}
				case 'D':
				case 'в':
				case 'В':
				case 'd':
					{
						if (map[current_location[0], current_location[1] + 1] == ' ')
						{
							Bar();
							drawChar(current_location, map, ' ');
							current_location[1] += 1;
							if (map[current_location[0], current_location[1] + 1] == 'E')
								gameWin();
							drawChar(current_location, map, '■');
						}
						break;
					}
			}
		}
		private static void drawChar(int[] current_location, char[,] map, char symbol)
        {
			Console.SetCursorPosition(current_location[1], current_location[0]);
			Console.Write(symbol);
			map[current_location[0], current_location[1]] = symbol;
		}
		private static void gameWin()
		{
			gameRun = false;
			System.Console.Clear();
			Console.WriteLine("Вы прошли лабиринт! Вы выиграли!");
			Console.ReadLine();
		}

		private static char[,] ReadMap(string mapName, out int playerX, out int playerY)
		{
		playerX = 0;
		playerY = 0;
		// Читаем файл, узнаем сколько в нём строк
		string[] strMap = File.ReadAllLines("maps/" + mapName + ".txt");

		char[,] chrMap = new char[strMap.Length, strMap[0].Length];
		for (int i = 0; i < chrMap.GetLength(0); i++)
		{
			for (int j = 0; j < chrMap.GetLength(1); j++)
			{
				chrMap[i, j] = strMap[i][j];
				bool flag = chrMap[i, j] == '■';
				if (flag)
				{
					playerX = i;
					playerY = j;
				}
			}
		}
			return chrMap;
		}
		private static void SetConsole(int length, int height)
		{
			Console.SetWindowSize(length, height);
			Console.SetCursorPosition(35, 0);
			Console.WriteLine("Игра лабиринт");
			Console.SetCursorPosition(35, 1);
			Console.WriteLine();
			Console.SetCursorPosition(35, 2);
			Console.WriteLine("Цель игры: Выити из лабиринта.");
			Console.SetCursorPosition(35, 4);
			Console.WriteLine("Легенда:");
			Console.SetCursorPosition(35, 5);
			Console.WriteLine("1) Знаками ═, ╬, ╣, ╗ и т.д. - обозначены стены");
			Console.SetCursorPosition(35, 6);
			Console.WriteLine("2) Знаком ■ обозначено текущее местоположение игрока");
			Console.SetCursorPosition(35, 7);
			Console.WriteLine("3) знаком E обозначен выход.");
			Console.SetCursorPosition(35, 8);
			Console.WriteLine("Движение осуществляется буквами w,a,s,d.");
			Console.SetCursorPosition(35, 9);
			Console.WriteLine();
			Console.SetCursorPosition(35, 10);
			Console.WriteLine($"На прохождение лабиринта вам дано {turns} ходов");
			Console.SetCursorPosition(35, 11);
			Console.WriteLine();
			Console.SetCursorPosition(35, 12);
			//Console.WriteLine("H - подсказка по прохождению");
			Console.SetCursorPosition(35, 14);
			//Console.WriteLine("ESC - выход из игры");
			Console.SetCursorPosition(0, 0);
		}

		private static void DrawMap(char[,] map)
		{
			for (int i = 0; i < map.GetLength(0); i++)
			{
				for (int j = 0; j < map.GetLength(1); j++)
				{
					Console.Write(map[i, j]);
				}
				Console.WriteLine();
			}
		}

		private static void Bar()
		{
			bar++;
			int temp = 0;
			Console.SetCursorPosition(35, 19);
			Console.Write($"{bar} / {turns} ходов...");
			Console.SetCursorPosition(35, 20);
			Console.Write("[");
			for (int i = 0; i <= turns; i++) 
				if (i % 10 == 0)
				{
					temp++;
					Console.SetCursorPosition(35 + temp, 20);
					Console.Write(i <= bar ? '#' : '_');
				}
			Console.Write("]");

			if (bar >= turns)
			{
				Console.Clear();
				gameRun = false;
				Console.WriteLine("Вы проиграли у вас кончились ходы");
				Console.ReadLine();
			}

		}
	}
}