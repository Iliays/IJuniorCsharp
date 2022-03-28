using System;

namespace Task6
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Дан массив чисел (минимум 10 чисел). 
			 * Надо вывести в консоль числа отсортированы, от меньшего до большего.
			 * Нельзя использовать Array.Sort. 
			 * Можно найти подходящий алгоритм сортировки и использовать его для задачи.
			 */

			int[] intArray = new int[10];
			Random random = new Random();
			int minimumRandomNumber = 1;
			int maximumRandomNumber = 10;
			int minimumElementIndex;

			Console.WriteLine("Неотсортированный массив");
			for (int i = 0; i < intArray.Length; i++)
			{
				intArray[i] = random.Next(minimumRandomNumber, maximumRandomNumber);
				Console.Write(intArray[i] + " ");
			}

			// Сортировка выбором
			for (int i = 0; i < intArray.Length; i++)
			{
				minimumElementIndex = i;
				for (int j = i; j < intArray.Length; j++)
				{
					if (intArray[j] < intArray[minimumElementIndex])
					{
						minimumElementIndex = j;
					}
				}
				int temporary = intArray[i];
				intArray[i] = intArray[minimumElementIndex];
				intArray[minimumElementIndex] = temporary;
			}

			Console.WriteLine("\nОтсортированный массив");
			for (int i = 0; i < intArray.Length; i++)
			{
				Console.Write(intArray[i] + " ");
			}
			Console.WriteLine();
		}
	}
}
