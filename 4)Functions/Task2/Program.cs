using System;

namespace Task2
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Разработайте функцию, которая рисует некий бар (Healthbar, Manabar) в определённой позиции. 
			 * Она также принимает некий закрашенный процент.
			 * При 40% бар выглядит так:
			 * [####______]
			 */

			int maxHealth = 10;
			int health = 5;
			char healthSymbol = '$';
			ConsoleColor healthColor = ConsoleColor.Red;
			int healthPosition = 0;
			int maxStamina = 10;
			int stamina = 10;
			char staminaSymbol = '#';
			ConsoleColor staminaColor = ConsoleColor.Yellow;
			int staminaPosition = 1;

			DrawBar(health, maxHealth, healthSymbol, healthColor, healthPosition);
			DrawBar(stamina, maxStamina, staminaSymbol, staminaColor, staminaPosition);
		}

		static void DrawBar(int value, int maxValue, char symbol, ConsoleColor color, int positionX)
		{
			ConsoleColor defaultColor = Console.BackgroundColor;
			string bar = "";

			for (int i = 0; i < value; i++)
			{
				bar += symbol;
			}

			Console.SetCursorPosition(0, positionX);
			Console.Write('[');
			Console.BackgroundColor = color;
			Console.Write(bar);
			Console.BackgroundColor = defaultColor;

			bar = "";

			for (int i = value; i < maxValue; i++)
			{
				bar += '_';
			}

			Console.Write(bar + ']');
		}
	}
}
