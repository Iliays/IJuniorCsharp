using System;
using System.Collections.Generic;
using System.Linq;

/*
 * У нас есть список всех игроков(минимум 10). 
 * У каждого игрока есть поля: имя, уровень, сила. 
 * Требуется написать запрос для определения топ 3 игроков по уровню и 
 * топ 3 игроков по силе, после чего вывести каждый топ.
 * 2 запроса получится.
 */

namespace Task4
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Player> players = new List<Player> { new Player("Killer", 10, 20), new Player("IaMcaT", 5, 10), 
				new Player("Destro", 20, 50), new Player("BigBob", 25, 120), new Player("Queen", 4, 13), 
				new Player("King", 30, 100), new Player("BigBoss", 100, 500), new Player("Knight", 2, 6),
				new Player("DarkDark", 90, 430), new Player("Kristi", 1, 1)};

			var topThreeByLevel = players.OrderByDescending(player => player.Level).Take(3).ToList();
			var topThreeByPower = players.OrderByDescending(player => player.Power).Take(3).ToList();

			Console.WriteLine("Все игроки\n");

			ShowList(players);

			Console.WriteLine("\n\nТоп 3 по уровню\n");

			ShowList(topThreeByLevel);

			Console.WriteLine("\n\nТоп 3 по силе\n");

			ShowList(topThreeByPower);
		}

		static void ShowList(List<Player> players)
		{
			foreach (var player in players)
			{
				Console.WriteLine($"{player.Name} - level {player.Level}, power = {player.Power}");
			}
		}
	}

	class Player
	{
		public string Name { get; private set; }
		public int Level { get; private set; }
		public int Power { get; private set; }

		public Player(string name, int level, int power)
		{
			Name = name;
			Level = level;
			Power = power;
		}
	}
}
