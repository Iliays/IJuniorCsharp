using System;
using System.Collections.Generic;

/*
 * У вас есть программа, которая помогает пользователю составить план поезда.
 * Есть 4 основных шага в создании плана:
 * -Создать направление - создает направление для поезда(к примеру Бийск - Барнаул)
 * -Продать билеты - вы получаете рандомное кол-во пассажиров, которые купили билеты на это направление
 * -Сформировать поезд - вы создаете поезд и добавляете ему столько вагонов
 * (вагоны могут быть разные по вместительности), сколько хватит для перевозки всех пассажиров.
 * -Отправить поезд - вы отправляете поезд, после чего можете снова создать направление.
 * В верхней части программы должна выводиться полная информация о текущем рейсе или его отсутствии.
 */

namespace Task07
{
	class Program
	{
		static void Main(string[] args)
		{
			Station station = new Station();
			station.Work();
		}
	}

	class Station
	{
		private List<Direction> _direction = new List<Direction>();
		private List<Train> _train = new List<Train>();
		private Random _random = new Random();

		public void Work()
		{
			bool isWorking = true;

			while (isWorking)
			{
				ShowInfo();
				CreateDirection();
				int passengerCount = SellTickets();
				CreateTrain(passengerCount);
				Console.ReadKey();
				Console.Clear();
			}
		}

		private void CreateDirection()
		{
			string pointFrom;
			string pointWhere;

			Console.WriteLine("!!!Выбор пункта отбытия и прибытия!!!");
			pointFrom = GetText("Введите пункт отбытия: ");
			pointWhere = GetText("Введите пункт прибытия: ");
			Console.WriteLine("----------------------------------------------------------------------------------------------------");
			Console.WriteLine("!!!Направление создано!!!");
			Console.WriteLine($"Пункт отбытия - {pointFrom}. Пункт прибытия - {pointWhere}");
			_direction.Add(new Direction(pointFrom, pointWhere));
		}

		private string GetText(string message)
		{
			string inputUser;

			do
			{
				Console.Write(message);
				inputUser = Console.ReadLine();
			}
			while (CheckInputText(inputUser) == false);

			return inputUser;
		}

		private bool CheckInputText(string inputText)
		{
			foreach (char symbol in inputText)
			{
				if (char.IsLetter(symbol) == false)
				{
					Console.WriteLine("Введены некорретные данный поторите попытку.");
					return false;
				}
			}

			return true;
		}

		private void CreateTrain(int passengerCount)
		{
			int minimumRailwayCar = 5;
			int maximumRailwayCar = 20;
			int minimumCapacity = 10;
			int maximumCapacity = 30;
			int trainCount = 0;
			int trainCapacity = 0;

			Console.WriteLine("----------------------------------------------------------------------------------------------------");
			Console.WriteLine("!!!Создание поезда!!!");

			do
			{
				Console.WriteLine($"Необходимо {passengerCount} мест. Сейчас {trainCount * trainCapacity}");
				trainCount = GetNumber("Введите количество вагонов: ", maximumRailwayCar, minimumRailwayCar);
				trainCapacity = GetNumber("Введите количество мест в вагоне: ", maximumCapacity, minimumCapacity);
			}
			while (trainCount * trainCapacity <= passengerCount);

			Console.WriteLine("!!!Поезд создан!!!");
			Console.WriteLine($"Количество вагонов - {trainCount}. Количество мест в вагонах - {trainCapacity}");
			Console.WriteLine($"Итого {trainCount * trainCapacity} мест");
			_train.Add(new Train(trainCount, trainCapacity));
		}

		private int GetNumber(string message, int maximum, int minimum)
		{
			int number;
			string inputUser;

			do
			{
				Console.WriteLine($"Минимальное число = {minimum}, максимальное число = {maximum}.");
				Console.Write(message);
				inputUser = Console.ReadLine();
			}
			while (int.TryParse(inputUser, out number) == false || (number >= minimum && number <= maximum) == false);

			Console.WriteLine();

			return number;
		}

		private int SellTickets()
		{
			Console.WriteLine("----------------------------------------------------------------------------------------------------");
			Console.WriteLine("Продажа билетов");
			int passengerCount = GetPassagerCount();
			Console.WriteLine($"{passengerCount} - человек купило билеты.");

			return passengerCount;
		}

		private int GetPassagerCount()
		{
			int minimumCountPassager = 40;
			int maximumCountPassager = 140;
			int countPassager = _random.Next(minimumCountPassager, maximumCountPassager);

			return countPassager;
		}

		private void ShowInfo()
		{
			for (int i = 0; i < _direction.Count; i++)
			{
				Console.WriteLine("----------------------------------------------------------------------------------------------------");
				Console.WriteLine($"Пункт отбытия - {_direction[i].PointFrom}. Пункт прибытия - {_direction[i].PointWhere}");
				Console.WriteLine("----------------------------------------------------------------------------------------------------");
			}
		}
	}

	class Direction
	{
		public string PointFrom { get; private set; }
		public string PointWhere { get; private set; }

		public Direction(string pointFrom, string pointWhere)
		{
			PointFrom = pointFrom;
			PointWhere = pointWhere;
		}
	}

	class Train
	{
		public int TrainCount { get; private set; }
		public int TrainСapacity { get; private set; }

		public Train(int trainCount, int trainCapacity)
		{
			TrainCount = trainCount;
			TrainСapacity = trainCapacity;
		}
	}
}
