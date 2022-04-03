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
			string[] secondArray = { "Apple", "IBM", "Samsung", "Samsung", "Huawei" };
			List<string> unionList = new List<string>();

			unionList.AddRange(firstArray);
			unionList.AddRange(secondArray);

			for (int i = 0; i < unionList.Count; i++)
			{
				var currentElement = unionList[i];

				for (int j = 0; j < unionList.Count; j++)
				{
					if (currentElement == unionList[j] && i != j)
					{
						unionList.RemoveAt(j);
					}
				}
			}

			for (int i = 0; i < unionList.Count; i++)
			{
				Console.WriteLine(unionList[i]);
			}
		}
	}
}
