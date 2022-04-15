using System;
using System.Collections.Generic;
using System.Linq;

/*
 * У нас есть список всех преступников.
 * В преступнике есть поля: ФИО, заключен ли он под стражу, рост, вес, национальность.
 * Вашей программой будут пользоваться детективы.
 * У детектива запрашиваются данные (рост, вес, национальность), 
 * и детективу выводятся все преступники, которые подходят под эти параметры, 
 * но уже заключенные под стражу выводиться не должны.
 */

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Criminal> criminals = new List<Criminal> { new Criminal("Кошкаров Александр", 180, 90, "Русский", false),
				new Criminal("Козлов Виктор", 185, 80, "Украинец", false),
				new Criminal("Архипов Константин", 177, 70, "Белорус", true),
				new Criminal("Иванов Иван", 185, 80, "Украинец", false),
				new Criminal("Кощанов Болат", 190, 70, "Казах", false),
				new Criminal("Попов Игорь", 180, 90, "Русский", false),
				new Criminal("Васильев Генадий", 170, 80, "Белорус", true),
				new Criminal("Петров Евгений", 185, 100, "Украинец", false),
				new Criminal("Умералиев Ренат", 188, 90, "Казах", true),
				new Criminal("Михайлов Артем", 177, 70, "Белорус", false)};

			Console.WriteLine("Список всех преступников\n");

			ShowList(criminals);

			Console.Write("Введите рост: ");
			int inputHeight = Convert.ToInt32(Console.ReadLine());
			Console.Write("Введите вес: ");
			int inputWeight = Convert.ToInt32(Console.ReadLine());
			Console.Write("Введите национальность: ");
			string inputNationality = Console.ReadLine();

			var fitCriminals = criminals.Where(criminal => criminal.IsArrested == false)
				.Where(criminal => criminal.Nationality.ToLower() == inputNationality.ToLower()
				&& criminal.Height == inputHeight && criminal.Weight == inputWeight).ToList();

			ShowList(fitCriminals);
		}

		static void ShowList(List<Criminal> criminals)
		{
			foreach (var criminal in criminals)
			{
				if (criminal.IsArrested)
					Console.WriteLine($"ФИО: {criminal.FullName}, рост - {criminal.Height}, вес - {criminal.Weight}, националость - {criminal.Nationality}, статус - арестован");
				else
					Console.WriteLine($"ФИО: {criminal.FullName}, рост - {criminal.Height}, вес - {criminal.Weight}, националость - {criminal.Nationality}, статус - на свободе");
			}
		}
	}

	class Criminal
	{
		public string FullName { get; private set; }
		public int Height { get; private set; }
		public int Weight { get; private set; }
		public string Nationality { get; private set; }
		public bool IsArrested { get; private set; }

		public Criminal(string fullName, int height, int weight, string nationality, bool isArrested)
		{
			FullName = fullName;
			Height = height;
			Weight = weight;
			Nationality = nationality;
			IsArrested = isArrested;
		}
	}
}
