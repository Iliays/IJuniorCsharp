using System;

/*
 * Создать класс игрока, с полями, содержащими информацию об игроке и методом, который выводит информацию на экран.
 * В классе обязательно должен быть конструктор
 */

namespace Task01
{
	class Program
	{
		static void Main(string[] args)
		{
			Player player1 = new Player("Killer", 100, 30);
			player1.ShowInfo();
		}
	}

	class Player
	{
		private string _name;
		private int _health;
		private int _mana;

		public Player(string name, int health, int mana)
		{
			_name = name;
			_health = health;
			_mana = mana;
		}

		public void ShowInfo()
		{
			Console.WriteLine($"Игрок по имени: {_name}\nХП: {_health} Мана: {_mana}");
		}
	}
}
