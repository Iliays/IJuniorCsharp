using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Существует класс солдата. В нём есть поля: имя, вооружение, звание, срок службы(в месяцах).
 * Написать запрос, при помощи которого получить набор данных состоящий из имени и звания.
 * Вывести все полученные данные в консоль.
 * (Не менее 5 записей)
 */

namespace Task6
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Soldier> soldiers = new List<Soldier> { new Soldier("Александр","AK-47","Майор",10), 
				new Soldier("Василий", "M4A4", "Капитан", 10), 
				new Soldier("Виктор","AK-74","Сержант",10),
				new Soldier("Константин","Glock","Лейтенант",10),
				new Soldier("Михаил","FiveSeven","Старший лейтенант",10)};

			var soldiersNameAndRank = soldiers.Select(soldier => new { soldier.Name, soldier.Rank});

			foreach (var soldier in soldiersNameAndRank)
			{
				Console.WriteLine($"Имя: {soldier.Name}, звание: {soldier.Rank}");
			}
		}
	}
	 
	class Soldier
	{
		public string Name { get; private set; }
		public string Armament { get; private set; }
		public string Rank { get; private set; }
		public int PeriodOfServiceInMonth { get; private set; }

		public Soldier(string name, string armament, string rank, int periodOfService)
		{
			Name = name;
			Armament = armament;
			Rank = rank;
			PeriodOfServiceInMonth = periodOfService;
		}
	}
}
