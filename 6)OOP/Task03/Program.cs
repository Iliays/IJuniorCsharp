using System;
using System.Collections.Generic;

/*
 * Реализовать базу данных игроков и методы для работы с ней.
 * У игрока может быть уникальный номер, ник, уровень, флаг – забанен ли он(флаг - bool).
 * Реализовать возможность добавления игрока, бана игрока по уникальный номеру, 
 * разбана игрока по уникальный номеру и удаление игрока.
 * Создание самой БД не требуется, задание выполняется инструментами, 
 * которые вы уже изучили в рамках курса. 
 * Но нужен класс, который содержит игроков и её можно назвать "База данных".
 */

namespace Task03
{
	class Program
	{
		static void Main(string[] args)
		{
			DataBase dataBase = new DataBase();
			dataBase.Work();
		}
	}

	class DataBase
	{
		private List<Player> _players = new List<Player>();
		private int _idPlayer;

		private void FillingData()
		{
			_players.Add(new Player("Killer", 10));
			_players.Add(new Player("Destroyer", 15));
			_players.Add(new Player("LuckyGuy", 30));
			_players.Add(new Player("Bitter", 100, true));
		}

		private int TryParseToInt(string message)
		{
			int number;
			string inputUser;

			do
			{
				Console.Write(message);
				inputUser = Console.ReadLine();
			}
			while (int.TryParse(inputUser, out number) == false);

			return number;
		}

		private void CreateNewPlayer()
		{
			Console.Write("Введите ник: ");
			string userInputNickname = Console.ReadLine();
			int userInputLevel = TryParseToInt("Введите уровень: ");

			_players.Add(new Player(userInputNickname, userInputLevel));
		}

		private void DeletePlayer()
		{
			_idPlayer = TryParseToInt("Введите id: ");

			for (int i = 0; i < _players.Count; i++)
			{
				if (_players[i].PlayerId == _idPlayer)
					_players.RemoveAt(i);
			}
		}

		private void PlayerBan()
		{
			_idPlayer = TryParseToInt("Введите id: ");

			for (int i = 0; i < _players.Count; i++)
			{
				if (_players[i].PlayerId == _idPlayer && _players[i].IsBaned == false)
					_players[i].Ban();
			}
		}

		private void PlayerUnban()
		{
			_idPlayer = TryParseToInt("Введите id: ");

			for (int i = 0; i < _players.Count; i++)
			{
				if (_players[i].PlayerId == _idPlayer && _players[i].IsBaned == true)
					_players[i].Unban();
			}
		}

		private void ShowAllPlayers()
		{
			for (int i = 0; i < _players.Count; i++)
			{
				_players[i].ShowInfo();
			}
		}

		public void Work()
		{
			FillingData();

			bool isWorking = true;

			while (isWorking)
			{
				ShowAllPlayers();

				Console.WriteLine("1) добавить игрока\n" +
					"2) забанить игрока\n" +
					"3) разбанить игрока\n" +
					"4) удалить игрока\n" +
					"5) выйти");
				string userInput = Console.ReadLine();

				switch (userInput)
				{
					case "1":
						CreateNewPlayer();
						break;
					case "2":
						PlayerBan();
						break;
					case "3":
						PlayerUnban();
						break;
					case "4":
						DeletePlayer();
						break;
					case "5":
						isWorking = false;
						break;
				}

				Console.Clear();
			}
		}
	}

	class Player
	{
		public int PlayerId { get; private set; }
		public string PlayerNickname { get; private set; }
		public int PlayerLevel { get; private set; }
		public bool IsBaned { get; private set; }
		private static int _id;

		public Player(string nick, int level, bool isBaned = false)
		{
			_id++;
			PlayerId = _id;
			PlayerNickname = nick;
			PlayerLevel = level;
			IsBaned = isBaned;
		}

		public void ShowInfo()
		{
			if (IsBaned)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"{PlayerId} - {PlayerNickname}({PlayerLevel} уровень) игрок забанен");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine($"{PlayerId} - {PlayerNickname}({PlayerLevel} уровень) игрок не забанен");
			}
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		public void Ban()
		{
			IsBaned = true;
		}

		public void Unban()
		{
			IsBaned = false;
		}
	}
}
