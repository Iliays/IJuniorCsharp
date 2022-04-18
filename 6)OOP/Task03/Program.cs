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
		private string _userInputNickname;
		private int _userInputLevel;
		private int _idPlayer;

		private void StartDataForTest()
		{
			_players.Add(new Player("Killer", 10));
			_players.Add(new Player("Destroyer", 15));
			_players.Add(new Player("LuckyGuy", 30));
			_players.Add(new Player("Bitter", 100, true));
		}

		private void CreateNewPlayer()
		{
			Console.Write("Введите ник: ");
			_userInputNickname = Console.ReadLine();
			Console.Write("Введите уровень: ");
			_userInputLevel = Convert.ToInt32(Console.ReadLine());

			_players.Add(new Player(_userInputNickname, _userInputLevel));
		}

		private void DeletePlayer()
		{
			Console.Write("Введите id: ");
			_idPlayer = Convert.ToInt32(Console.ReadLine());

			for (int i = 0; i < _players.Count; i++)
			{
				if (_players[i].PlayerId == _idPlayer)
					_players.RemoveAt(i);
			}
		}

		private void PlayerBan()
		{
			Console.Write("Введите id: ");
			_idPlayer = Convert.ToInt32(Console.ReadLine());

			for (int i = 0; i < _players.Count; i++)
			{
				if (_players[i].PlayerId == _idPlayer && _players[i].IsBaned == false)
					_players[i].ChangeIsBaned();
			}
		}

		private void PlayerUnban()
		{
			Console.Write("Введите id: ");
			_idPlayer = Convert.ToInt32(Console.ReadLine());

			for (int i = 0; i < _players.Count; i++)
			{
				if (_players[i].PlayerId == _idPlayer && _players[i].IsBaned == true)
					_players[i].ChangeIsBaned();
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
			StartDataForTest();

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
				Console.WriteLine($"{PlayerId} - {PlayerNickname}({PlayerLevel} уровень) игрок забанен");
			else
				Console.WriteLine($"{PlayerId} - {PlayerNickname}({PlayerLevel} уровень) игрок не забанен");
		}

		public void ChangeIsBaned()
		{
			if (IsBaned == false)
				IsBaned = true;
			else
				IsBaned = false;
		}
	}
}
