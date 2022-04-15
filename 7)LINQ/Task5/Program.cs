using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Есть набор тушенки. У тушенки есть название, год производства и срок годности.
 * Написать запрос для получения всех просроченных банок тушенки.
 * Чтобы не заморачиваться, можете думать, что считаем только года, без месяцев.
 */

namespace Task5
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Stew> stews = new List<Stew> { new Stew("Сила", 2000, 2), new Stew("Барко", 2010, 1),
				new Stew("Сила", 2020, 2), new Stew("Йошкар", 2002, 7), new Stew("Сила", 2020, 3),
				new Stew("Сила", 2010, 10), new Stew("Барко", 2021, 10), new Stew("Барко", 2014, 6),
				new Stew("Йошкар", 2015, 4), new Stew("Йошкар", 2009, 1)};

			Console.WriteLine("Вся продукция\n");

			ShowList(stews);

			var expiredStew = stews.Where(stew => stew.ProductionYear + stew.ExpirationDate > DateTime.Now.Year).ToList();

			Console.WriteLine("\n\nНе простроченные\n");

			ShowList(expiredStew);
		}

		static void ShowList(List<Stew> stews)
		{
			foreach (var stew in stews)
			{
				Console.WriteLine($"Название: {stew.Name}, год производства - {stew.ProductionYear}, срок годности - {stew.ExpirationDate}");
			}
		}
	}

	class Stew
	{
		public string Name { get; private set;}
		public int ProductionYear { get; private set; }
		public int ExpirationDate { get; private set; }

		public Stew(string name, int productionYear, int expirationDate)
		{
			Name = name;
			ProductionYear = productionYear;
			ExpirationDate = expirationDate;
		}
	}
}
