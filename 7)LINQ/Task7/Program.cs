using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Есть 2 списка в солдатами.
 * Всех бойцов из отряда 1, у которых фамилия начинается на букву Б, требуется перевести в отряд 2.
 */

namespace Task7
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> firstSquad = new List<string> { "Баранов", "Быков", "Архипов", "Цой", "Бекмамбетов" };
			List<string> secondSquad = new List<string> { "Кошкаров", "Кощанов", "Кривых", "Чубенко" };

			var secondSquadResult = firstSquad.Where(soldier => soldier.ToUpper().StartsWith("Б")).Union(secondSquad);

			foreach (var soldier in secondSquadResult)
			{
				Console.WriteLine(soldier);
			}

			firstSquad = firstSquad.Where(soldier => soldier.ToUpper().StartsWith("Б") == false).ToList();
		}
	}
}
