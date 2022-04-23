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

		public void Work()
		{
			FillData();

			bool isWorking = true;

			while (isWorking)
			{
				Console.WriteLine("Для выхода из программы напишите <Выйти>");

				for (int i = 0; i < _aviary.Count; i++)
				{
					Console.Write($"\n{i + 1})Вольер: ");
					_aviary[i].GetAnimalName();
				}

				Console.Write("\nВыберите вольер: ");
				string userInput = Console.ReadLine();

				if (userInput.ToLower() == "выйти")
				{
					isWorking = false;
				}
				else if (IsNumber(userInput))
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

		private void FillData()
		{
			_aviary.Add(new Aviary(new List<Animal>() { new Animal("Лев", "М", "Гррр"), new Animal("Львица", "Ж", "Гррр") }));
			_aviary.Add(new Aviary(new List<Animal>() { new Animal("Корова", "Ж", "Мууу"), new Animal("Корова", "Ж", "Мууу"), new Animal("Корова", "Ж", "Мууу") }));
			_aviary.Add(new Aviary(new List<Animal>() { new Animal("Медведь", "М", "Уааа"), new Animal("Медведь", "М", "Уааа") }));
			_aviary.Add(new Aviary(new List<Animal>() { new Animal("Панда", "М", "Ууу"), new Animal("Панда", "Ж", "Ууу") }));
		}

		private bool IsNumber(string inputUser)
		{
			return int.TryParse(inputUser, out int number);
		}
	}

	class Aviary
	{
		private List<Animal> _animals = new List<Animal>();

		public Aviary(List<Animal> animal)
		{
			_animals = animal;
		}

		public void GetAnimalName()
		{
			for (int i = 0; i < _animals.Count; i++)
			{
				Console.Write(_animals[i].Name + " ");
			}
		}

		public void ShowInfo()
		{
			for (int i = 0; i < _animals.Count; i++)
			{
				_animals[i].ShowInfo();
			}
			Console.WriteLine($"В вальере всего {_animals.Count} особей.");
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
			Console.WriteLine($"В данном вальере обитает: {Name}, пол - {_gender}, издает звук - {_sound}");
		}
	}
}
