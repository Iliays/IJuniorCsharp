using System;

namespace Task3
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Дан одномерный массив целых чисел из 30 элементов.
			 * Найдите все локальные максимумы и вывести их. 
			 * (Элемент является локальным максимумом, если он не имеет соседей, больших, чем он сам)
			 * Крайние элементы являются локальными максимумами если не имеют соседа большего, чем они сами.
			 * Программа должна работать с массивом любого размера.
			 * Массив всех локальных максимумов не нужен.
			 */

			int[] intArray = new int[30];
			Random random = new Random();
			int minimumRandomNumber = 1;
			int maximumRandomNumber = 50;

			for (int i = 0; i < intArray.Length; i++)
			{
				intArray[i] = random.Next(minimumRandomNumber, maximumRandomNumber);
				Console.Write(intArray[i] + " ");
			}

			Console.WriteLine();

			if (intArray[0] > intArray[1])
			{
				Console.WriteLine("Локальный максимум: " + intArray[0]);
			}

			for (int i = 1; i < intArray.Length - 1; i++)
			{
				if (intArray[i] > intArray[i + 1] && intArray[i] > intArray[i - 1])
				{
					Console.WriteLine("Локальный максимум: " + intArray[i]);
				}
			}

			if (intArray[intArray.Length - 1] > intArray[intArray.Length - 2])
			{
				Console.WriteLine("Локальный максимум: " + intArray[intArray.Length - 1]);
			}
		}
	}
}
