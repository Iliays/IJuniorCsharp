﻿using System;

namespace Task4
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Сделать игровую карту с помощью двумерного массива. 
			 * Сделать функцию рисования карты. 
			 * Помимо этого, дать пользователю возможность перемещаться по карте и 
			 * взаимодействовать с элементами (например пользователь не может пройти сквозь стену)
			 * Все элементы являются обычными символами
			 */

			Console.CursorVisible = false;

			char[,] map = 
			{ 
				{ '*', '*','*','*','*','*','*','*','*','*','*'},
				{ '*', ' ','*',' ',' ',' ',' ',' ',' ',' ','*'},
				{ '*', ' ','*',' ','*','*','*',' ','*','*','*'},
				{ '*', ' ','*',' ','*',' ','*',' ',' ',' ','*'},
				{ '*', ' ',' ',' ','*',' ','*',' ',' ',' ','*'},
				{ '*', ' ','*','*','*',' ','*',' ','*','*','*'},
				{ '*', ' ','*',' ',' ',' ',' ',' ',' ',' ','*'},
				{ '*', '*','*','*','*','*','*','*','*','*','*'}
			};
			int playerX = 1;
			int playerY = 1;
			int playerDirectionX = 0;
			int playerDirectionY = 0;
			bool isPlaying = true;

			DrawMap(map);

			Move(ref playerX, ref playerY, playerDirectionX, playerDirectionY);

			while (isPlaying)
			{
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey(true);

					MoveDirection(key, ref playerDirectionX, ref playerDirectionY);

					if (map[playerX + playerDirectionX, playerY + playerDirectionY] != '*')
					{
						Move(ref playerX, ref playerY, playerDirectionX, playerDirectionY);
					}
				}
			}
		}

		static void DrawMap(char[,] map)
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

		static void Move(ref int playerX, ref int playerY, int playerDirectionX, int playerDirectionY)
		{
			Console.SetCursorPosition(playerY, playerX);
			Console.Write(" ");

			playerX += playerDirectionX;
			playerY += playerDirectionY;

			Console.SetCursorPosition(playerY, playerX);
			Console.Write('$');
		}

		static void MoveDirection(ConsoleKeyInfo key, ref int playerDirectionX, ref int playerDirectionY)
		{
			switch (key.Key)
			{
				case ConsoleKey.UpArrow:
					playerDirectionX = -1; playerDirectionY = 0;
					break;
				case ConsoleKey.DownArrow:
					playerDirectionX = 1; playerDirectionY = 0;
					break;
				case ConsoleKey.LeftArrow:
					playerDirectionX = 0; playerDirectionY = -1;
					break;
				case ConsoleKey.RightArrow:
					playerDirectionX = 0; playerDirectionY = 1;
					break;
			}
		}
	}
}