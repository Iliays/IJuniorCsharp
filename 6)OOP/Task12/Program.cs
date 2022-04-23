using System;
using System.Collections.Generic;

/*
 * Пользователь запускает приложение и перед ним находится меню, 
 * в котором он может выбрать, к какому вольеру подойти. 
 * При приближении к вольеру, пользователю выводится информация о том, что это за вольер,
 * сколько животных там обитает, их пол и какой звук издает животное.
 * Вольеров в зоопарке может быть много, в решении нужно создать минимум 4 вольера.
 */

namespace Task12
{
	class Program
	{
		static void Main(string[] args)
		{
			Zoo zoo = new Zoo();
			zoo.Work();
		}
	}

	class Zoo
	{
		private List<Aviary> _aviary = new List<Aviary>();

		private void FillingData()
		{
			_aviary.Add(new Aviary(new Animal("Львы", "М", "Гррр"), 2));
			_aviary.Add(new Aviary(new Animal("Коровы", "Ж", "Мууу"), 5));
			_aviary.Add(new Aviary(new Animal("Медведь", "М", "Уааа"), 1));
			_aviary.Add(new Aviary(new Animal("Панды", "М", "Ууу"), 3));
		}

		private bool IsNumber(string inputUser)
		{
			return int.TryParse(inputUser, out int number);
		}

		public void Work()
		{
			FillingData();

			bool isWorking = true;

			while (isWorking)
			{
				Console.WriteLine("Для выхода из программы напишите <Выйти>");
				for (int i = 0; i < _aviary.Count; i++)
				{
					Console.WriteLine($"{i + 1})Вольер - {_aviary[i].GetAnimalName()}");
				}

				Console.Write("Выберите вольер: ");
				string userInput = Console.ReadLine();

				if (userInput.ToLower() == "выйти")
				{
					isWorking = false;
				}
				else if(IsNumber(userInput))
				{
					_aviary[Convert.ToInt32(userInput) - 1].ShowInfo();
					Console.ReadKey();
				}
				else
				{
					Console.WriteLine("Вы ввели несуществующую команду");
				}

				Console.Clear();
			}
		}
	}

	class Aviary
	{
		private Animal _animal;
		private int _countOfAnimal;

		public Aviary(Animal animal, int count)
		{
			_animal = animal;
			_countOfAnimal = count;
		}

		public string GetAnimalName()
		{
			return _animal.Name;
		}

		public void ShowInfo()
		{
			_animal.ShowInfo();
			Console.WriteLine($"В вальере всего {_countOfAnimal} особей.");
		}
	}

	class Animal
	{
		public string Name { get; private set; }
		private string _gender;
		private string _sound;

		public Animal(string name, string gender, string sound)
		{
			Name = name;
			_gender = gender;
			_sound = sound;
		}

		public void ShowInfo()
		{
			Console.WriteLine($"В данном вальере обитают: {Name}, пол - {_gender}, издает звук - {_sound}");
		}
	}
}
