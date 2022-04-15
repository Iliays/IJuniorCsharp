using System;

/*
 * Создать класс игрока, у которого есть поля с его положением в x,y.
 * Создать класс отрисовщик, с методом, который отрисует игрока.
 * Попрактиковаться в работе со свойствами.
 */

namespace Task02
{
	class Program
	{
		static void Main(string[] args)
		{
			Player player1 = new Player(5, 10);
			Renderer renderer = new Renderer();
			renderer.DrawPlayer(player1.XPlayerPosition, player1.YPlayerPosition);
		}
	}

	class Player
	{
		public int XPlayerPosition { get; private set; }
		public int YPlayerPosition { get; private set; }

		public Player(int x, int y)
		{
			XPlayerPosition = x;
			YPlayerPosition = y;
		}
	}

	class Renderer
	{
		public void DrawPlayer(int x, int y, char symbol = '$')
		{
			Console.SetCursorPosition(x, y);
			Console.Write(symbol);
		}
	}
}
