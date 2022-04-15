using System;
using System.Collections.Generic;
using System.Linq;

/*
 * В нашей великой стране Арстоцка произошла амнистия!
 * Всех людей, заключенных за преступление "Антиправительственное", 
 * следует исключить из списка заключенных.
 * Есть список заключенных, каждый заключенный состоит из полей: ФИО, преступление.
 * Вывести список до амнистии и после.
 */

namespace Task2
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Prisoner> prisoners = new List<Prisoner> { new Prisoner("Кошкаров Александр", "Антиправительственное"),
				new Prisoner("Козлов Виктор", "Убийство"),
				new Prisoner("Архипов Константин", "Грабеж"),
				new Prisoner("Иванов Иван", "Грабеж"),
				new Prisoner("Смирнов Марк", "Взлом"),
				new Prisoner("Попов Игорь", "Антиправительственное"),
				new Prisoner("Васильев Генадий", "Антиправительственное"),
				new Prisoner("Петров Евгений", "Убийство"),
				new Prisoner("Соколов Георгий", "Взлом"),
				new Prisoner("Михайлов Артем", "Антиправительственное")};

			Console.WriteLine("Список преступников до амнистии\n");

			ShowList(prisoners);

			Console.WriteLine("\n\nСписок преступников после амнистии\n");

			var listPrisonersAfterAmnesty = prisoners.Where(prisoner => prisoner.Crime != "Антиправительственное").ToList();

			ShowList(listPrisonersAfterAmnesty);
		}

		static void ShowList(List<Prisoner> prisoners)
		{
			foreach (var prisoner in prisoners)
			{
				Console.WriteLine($"ФИО: {prisoner.FullName}, преступление - {prisoner.Crime}");
			}
		}
	}

	class Prisoner
	{
		public string FullName { get; private set; }
		public string Crime { get; private set; }

		public Prisoner(string fullName, string crime)
		{
			FullName = fullName;
			Crime = crime;
		}
	}
}
