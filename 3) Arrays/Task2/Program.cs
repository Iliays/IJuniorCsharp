using System;

namespace Task2
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Найти наибольший элемент матрицы A(10,10) и записать ноль в те ячейки, где он находятся. 
			 * Вывести наибольший элемент, исходную и полученную матрицу.
			 * Массив под измененную версию не нужен.
			 */

			int[,] intArray = new int[10, 10];
			Random random = new Random();
			int minimumRandomNumber = 1;
			int maximumRandomNumber = 50;
			int maximumArrayElement = int.MinValue;
			int indexLineMaximumElement = 0;
			int indexColumnMaximumElement = 0;

			Console.WriteLine("Исходная матрица\n");

			for (int i = 0; i < intArray.GetLength(0); i++)
			{
				for (int j = 0; j < intArray.GetLength(1); j++)
				{
					intArray[i, j] = random.Next(minimumRandomNumber, maximumRandomNumber);
					Console.Write(intArray[i, j] + " ");

					if (maximumArrayElement < intArray[i, j])
					{
						maximumArrayElement = intArray[i, j];
						indexLineMaximumElement = i;
						indexColumnMaximumElement = j;
					}
				}
				Console.WriteLine();
			}

			intArray[indexLineMaximumElement, indexColumnMaximumElement] = 0;

			Console.WriteLine("\n\nМаксимальное число - " + maximumArrayElement);
			Console.WriteLine($"Строка - {indexLineMaximumElement + 1}\nСтолбец {indexColumnMaximumElement + 1}");
			Console.WriteLine("\nПолученная матрица\n");

			for (int i = 0; i < intArray.GetLength(0); i++)
			{
				for (int j = 0; j < intArray.GetLength(1); j++)
				{
					Console.Write(intArray[i, j] + " ");
				}
				Console.WriteLine();
			}
		}
	}
}
