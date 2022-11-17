using System;
using System.Collections.Generic;

/*
 * У вас есть автосервис, в который приезжают люди, чтобы починить свои автомобили.
 * У вашего автосервиса есть баланс денег и склад деталей.
 * Когда приезжает автомобиль, у него сразу ясна его поломка, и эта поломка 
 * отображается у вас в консоли вместе с ценой за починку(цена за починку складывается из цены детали + цена за работу).
 * Поломка всегда чинится заменой детали, но количество деталей ограничено тем, что находится на вашем складе деталей.
 * Если у вас нет нужной детали на складе, то вы можете отказать клиенту, и в этом случае вам придется выплатить штраф.
 * Если вы замените не ту деталь, то вам придется возместить ущерб клиенту.
 * За каждую удачную починку вы получаете выплату за ремонт, которая указана в чек-листе починки.
 * Класс Деталь не может содержать значение “количество”. 
 * Деталь всего одна, за количество отвечает тот, кто хранит детали. 
 * При необходимости можно создать дополнительный класс для конкретной детали и работе с количеством.
 */

namespace Task13
{
	class Program
	{
		static void Main(string[] args)
		{
			Autoservice autoservice = new Autoservice();
			autoservice.Work();
		}
	}

	class Autoservice
	{
		private int _moneyBalance = 1000;
		private int _penalty = 200;
		private int _costWork = 100;
		private List<Cell> _storage = new List<Cell>();
		private Queue<Car> _carQueue = new Queue<Car>();
		private List<string> _detailList = new List<string>();
		private Random _random = new Random();
		

		public void Work()
		{
			const string CommandServiceClient = "1";
			const string CommandStopWork = "2";
			bool isWorking = true;

			FillData();

			while (isWorking)
			{
				ShowStorage();
				Console.WriteLine($"\nБаланс автомастерской - {_moneyBalance}.");
				Console.WriteLine("1) Обслужить клиента" +
					"\n2) Завершить работу" +
					"\nДействие: ");
				string userInput = Console.ReadLine();

				if (userInput == CommandServiceClient)
					ServiceСar();
				else if (userInput == CommandStopWork)
					isWorking = false;
				else
					Console.WriteLine("Такой команды несуществует.");
			}
		}

		private void ServiceСar()
		{
			const string CommandRepairCar = "1";
			const string CommandDenyClient = "2";

			if (_carQueue.Count > 0)
			{
				Console.Clear();
				ShowBreakdown(_carQueue.Peek());
				Console.Write("Что вы будете делать. " +
					"\n1) Ремонтировать " +
					"\n2) Отказать клиенту " +
					"\nДействие: ");
				string userInput = Console.ReadLine();

				if (userInput == CommandRepairCar)
				{
					RepairCar(_carQueue.Dequeue());
				}
				else if (userInput == CommandDenyClient)
				{
					_carQueue.Dequeue();
					DenyService();
				}
				else
				{
					Console.WriteLine("Такой команды несуществует.");
				}

				Console.ReadKey();
				Console.Clear();
			}
			else
			{
				Console.WriteLine("Вы обслужили всех клиентов на сегодня!!!");
			}
		}

		private void FillData()
		{
			_storage.Add(new Cell(new Detail("Двигатель", 200), 2));
			_storage.Add(new Cell(new Detail("Фары", 100), 4));
			_storage.Add(new Cell(new Detail("Колесо", 50), 5));

			FillDetailList();

			_carQueue.Enqueue(new Car(GetRandomNameDetail()));
			_carQueue.Enqueue(new Car(GetRandomNameDetail()));
			_carQueue.Enqueue(new Car(GetRandomNameDetail()));
			_carQueue.Enqueue(new Car(GetRandomNameDetail()));
			_carQueue.Enqueue(new Car(GetRandomNameDetail()));
		}

		private string GetRandomNameDetail()
		{
			int minimumNumberDetail = 0;
			int number = _random.Next(minimumNumberDetail, _detailList.Count);
			return _detailList[number];
		}

		private List<string> FillDetailList()
		{
			foreach (var cell in _storage)
			{
				_detailList.Add(cell._detail.Name);
			}
			return _detailList;
		}

		private void ShowBreakdown(Car car)
		{
			Console.WriteLine($"У машины сломано - {car.BrokenDetail}.");
			Console.WriteLine($"\nСтоимость работы = {GetRepairPrice(car.BrokenDetail)}.");
		}

		private void ShowStorage()
		{
			Console.WriteLine("В наличии такие детали: ");

			for (int i = 0; i < _storage.Count; i++)
			{
				Console.Write($"{i + 1} ");
				_storage[i].ShowInfo();
			}
		}

		private int GetRepairPrice(string brokenDetail)
		{
			int repairPrice = 0;

			for (int i = 0; i < _storage.Count; i++)
			{
				if (_storage[i]._detail.Name == brokenDetail)
				{
					repairPrice += _storage[i]._detail.Cost + _costWork;
					return repairPrice;
				}
			}

			return repairPrice;
		}

		private void DenyService()
		{
			Console.WriteLine($"Вы отказали клиенту. С вас штраф - {_penalty} рублей.");
			_moneyBalance -= _penalty;
		}

		private void RepairCar(Car car)
		{
			ShowStorage();
			int userInput = GetExistDetailNumber("Какую деталь вы желаете установить: ");
			int repairPrice = GetRepairPrice(car.BrokenDetail);

			if (CanRepairCar(userInput))
			{
				_storage[userInput - 1].DecreaseCountDetail();
				if (userInput > 0 && userInput - 1 < _storage.Count && car.BrokenDetail == _storage[userInput - 1]._detail.Name)
				{
					Console.WriteLine($"Вы успешно починили автомобиль!\n И заработали {repairPrice} рублей.");
					_moneyBalance += repairPrice;
				}
				else
				{
					Console.WriteLine("Вы установили не ту деталь. Клиент не доволен вашей работой. " +
					 $"\nВы возместили ущерб клиенту в размере - {repairPrice} рублей.");
					_moneyBalance -= repairPrice;
				}
			}
			else
			{
				Console.WriteLine("Данная деталь закончилась и клиент не доволен вашей работой. " +
					"\nПокидает автосервис и вам приходится выплатить штраф.");
				DenyService();
			}
		}

		private bool CanRepairCar(int detailNumber)
		{
			if (_storage[detailNumber - 1].CanDecreaseCountDetail())
				return true;
			else
				return false;
		}

		private int GetExistDetailNumber(string message)
		{
			int number;
			string inputUser;
			int minNumber = 1;
			int maxNumber = _storage.Count + 1;

			do
			{
				Console.Write(message);
				inputUser = Console.ReadLine();
			}
			while (int.TryParse(inputUser, out number) == false || (number >= minNumber && number < maxNumber) == false);

			return number;
		}
	}

	class Car
	{
		public string BrokenDetail { get; private set; }

		public Car(string brokenDetail)
		{
			BrokenDetail = brokenDetail;
		}
	}

	class Cell
	{
		public Detail _detail { get; private set; }
		private int _countOfDetails;

		public Cell(Detail detail, int count)
		{
			_detail = detail;
			_countOfDetails = count;
		}

		public bool CanDecreaseCountDetail()
		{
			if (_countOfDetails > 0)
				return true;
			else
				return false;
		}

		public void DecreaseCountDetail()
		{
			_countOfDetails--;
		}

		public void ShowInfo()
		{
			Console.WriteLine($"Деталь - {_detail.Name}. Цена - {_detail.Cost}. Количество - {_countOfDetails}.");
		}
	}

	class Detail
	{
		public string Name { get; private set; }
		public int Cost { get; private set; }

		public Detail(string name, int cost)
		{
			Name = name;
			Cost = cost;
		}
	}
}
