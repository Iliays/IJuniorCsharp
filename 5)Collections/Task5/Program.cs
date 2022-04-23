using System;
using System.Collections.Generic;

namespace Task5
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Есть два массива строк. Надо их объединить в одну коллекцию, 
			 * исключив повторения, не используя Linq. Пример: {1, 2, 1} + {3, 2} => {1, 2, 3}
			 */

			string[] firstArray = { "Microsoft", "Google", "Apple", "Microsoft" };
			string[] secondArray = { "Microsoft", "Google", "Huawei", "Google", "Apple", "Microsoft", "IBM" };
			List<string> unionList = new List<string>();

			AddInList(unionList, firstArray);
			AddInList(unionList, secondArray);

			for (int i = 0; i < unionList.Count; i++)
			{
				Console.WriteLine(unionList[i]);
			}
		}

		static void AddInList(List<string> unionList, string[] list)
		{
			for (int i = 0; i < list.Length; i++)
			{
				if (unionList.Contains(list[i]) == false)
				{
					unionList.Add(list[i]);
				}
			}
		}
	}
}
