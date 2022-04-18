using System;
using System.Collections.Generic;

/*
 * Есть аквариум, в котором плавают рыбы. 
 * В этом аквариуме может быть максимум определенное кол-во рыб. 
 * Рыб можно добавить в аквариум или рыб можно достать из аквариума. 
 * (программу делать в цикле для того, чтобы рыбы могли “жить”)
 * Все рыбы отображаются списком, у рыб также есть возраст. 
 * За 1 итерацию рыбы стареют на определенное кол-во жизней и могут умереть. 
 * Рыб также вывести в консоль, чтобы можно было мониторить показатели.
 */

namespace Task11
{
	class Program
	{
		static void Main(string[] args)
		{
			Aquarium aquarium = new Aquarium();
			aquarium.Work();
		}
	}

	class Aquarium
	{
		private List<Fish> _fishes = new List<Fish>();
		private int _maxFishesInAquarium = 7;
		private string _inputName;
		private int _inputLifeTime;

		private void StartDataForTest()
		{
			_fishes.Add(new Fish("Gubby", 5));
			_fishes.Add(new Fish("Kit", 10));
			_fishes.Add(new Fish("Sword", 12));
			_fishes.Add(new Fish("Shield", 4));
			_fishes.Add(new Fish("Frubb", 7));
			_fishes.Add(new Fish("Seled", 5));
		}

		private void AddFish()
		{
			if (_maxFishesInAquarium > _fishes.Count)
			{
				Console.WriteLine("Введите имя рыбы: ");
				_inputName = Console.ReadLine();
				Console.WriteLine("введите время жизни: ");
				_inputLifeTime = Convert.ToInt32(Console.ReadLine());

				_fishes.Add(new Fish(_inputName, _inputLifeTime));
			}
			else
			{
				Console.WriteLine("Нет места для еще одной рыбы");
				Console.ReadKey();
			}
		}

		private void ShowAllFishesInfo()
		{
			for (int i = 0; i < _fishes.Count; i++)
			{
				_fishes[i].ShowFishInfo();
			}
		}

		private void DecreaseFishLife()
		{
			for (int i = 0; i < _fishes.Count; i++)
			{
				_fishes[i].DecreaseLife();

				if (_fishes[i].LifeTime == 0)
					_fishes.RemoveAt(i);
			}
		}

		public void Work()
		{
			StartDataForTest();

			int currentFishesInAqurium = _fishes.Count;

			while (currentFishesInAqurium > 0)
			{
				ShowAllFishesInfo();

				Console.WriteLine("1) добавить рыбу\n" +
				"2) просто смотреть");
				string userInput = Console.ReadLine();

				switch (userInput)
				{
					case "1":
						AddFish();
						break;
					case "2":
						ShowAllFishesInfo();
						break;
				}

				DecreaseFishLife();
				Console.Clear();
			}
		}
	}

	class Fish
	{
		private string _fishName;
		public int LifeTime { get; private set; }

		public Fish(string name, int life)
		{
			_fishName = name;
			LifeTime = life;
		}

		public void ShowFishInfo()
		{
			Console.WriteLine($"Рыба - {_fishName}. Срок жизни {LifeTime}");
		}

		public void DecreaseLife()
		{
			LifeTime--;
		}
	}
}
