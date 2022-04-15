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
			renderer.DrawPlayer(player1.XPosition, player1.YPosition);
		}
	}

	class Player
	{
		public int XPosition { get; private set; }
		public int YPosition { get; private set; }

		public Player(int xPosition, int yPosition)
		{
			XPosition = xPosition;
			YPosition = yPosition;
		}
	}

	class Renderer
	{
		public void DrawPlayer(int xPosition, int yPosition, char symbol = '$')
		{
			Console.SetCursorPosition(xPosition, yPosition);
			Console.Write(symbol);
		}
	}
}
