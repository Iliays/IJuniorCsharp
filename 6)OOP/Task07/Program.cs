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
		private List<Train> _trains = new List<Train>();
		private Random _random = new Random();

		public void Work()
		{
			bool isWorking = true;

			while (isWorking)
			{
				ShowInfo();
				Direction direction = CreateDirection();
				int passengerCount = SellTickets();
				CreateTrain(passengerCount, direction);
				Console.ReadKey();
				Console.Clear();
			}
		}

		private Direction CreateDirection()
		{
			string pointFrom;
			string pointWhere;
			Console.WriteLine("!!!Выбор пункта отбытия и прибытия!!!");
			pointFrom = GetText("Введите пункт отбытия: ");
			pointWhere = GetText("Введите пункт прибытия: ");
			Console.WriteLine("----------------------------------------------------------------------------------------------------");
			Console.WriteLine("!!!Направление создано!!!");
			Console.WriteLine($"Пункт отбытия - {pointFrom}. Пункт прибытия - {pointWhere}");

			return new Direction(pointFrom, pointWhere);
		}

		private string GetText(string message)
		{
			string inputUser;

			do
			{
				Console.Write(message);
				inputUser = Console.ReadLine();
			}
			while (IsText(inputUser) == false);

			return inputUser;
		}

		private bool IsText(string inputText)
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

		private void CreateTrain(int passengerCount, Direction direction)
		{
			int minimumRailwayCar = 5;
			int maximumRailwayCar = 20;
			int minimumCapacity = 10;
			int maximumCapacity = 30;
			int wagonCount = 0;
			int wagonCapacity = 0;

			Console.WriteLine("----------------------------------------------------------------------------------------------------");
			Console.WriteLine("Продажа билетов");
			Console.WriteLine($"{passengerCount} - человек купило билеты.");
			Console.WriteLine("----------------------------------------------------------------------------------------------------");
			Console.WriteLine("!!!Создание поезда!!!");

			do
			{
				Console.WriteLine($"Необходимо {passengerCount} мест. Сейчас {wagonCount * wagonCapacity}");
				wagonCount = GetNumber("Введите количество вагонов: ", maximumRailwayCar, minimumRailwayCar);
				wagonCapacity = GetNumber("Введите количество мест в вагоне: ", maximumCapacity, minimumCapacity);
			}
			while (wagonCount * wagonCapacity < passengerCount);

			Console.WriteLine("!!!Поезд создан!!!");
			Console.WriteLine($"Количество вагонов - {wagonCount}. Количество мест в вагонах - {wagonCapacity}");
			Console.WriteLine($"Итого {wagonCount * wagonCapacity} мест");

			_trains.Add(new Train(wagonCount, wagonCapacity, direction));
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
			int minimumCountPassager = 40;
			int maximumCountPassager = 140;

			return _random.Next(minimumCountPassager, maximumCountPassager);
		}

		private void ShowInfo()
		{
			for (int i = 0; i < _trains.Count; i++)
			{
				Console.WriteLine("----------------------------------------------------------------------------------------------------");
				Console.WriteLine($"Пункт отбытия - {_trains[i].Direction.PointFrom}. Пункт прибытия - {_trains[i].Direction.PointWhere}");
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
		public int WagonCount { get; private set; }
		public int WagonСapacity { get; private set; }
		public Direction Direction { get; private set; }

		public Train(int wagonCount, int wagonCapacity, Direction direction)
		{
			WagonCount = wagonCount;
			WagonСapacity = wagonCapacity;
			Direction = direction;
		}
	}
}
