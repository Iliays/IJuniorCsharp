using System;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Дан двумерный массив.
			 * Вычислить сумму второй строки и произведение первого столбца.
			 * Вывести исходную матрицу и результаты вычислений.
			 */

			int[,] intArray = new int[3, 3];
			Random random = new Random();
			int minimumRandomNumber = 1;
			int maximumRandomNumber = 10;
			int sumLine = 0;
			int multiplyColumn = 1;
			int indexLineToSum = 1;
			int indexColumnToMultyply = 0;


			for (int i = 0; i < intArray.GetLength(0); i++)
			{
				for (int j = 0; j < intArray.GetLength(1); j++)
				{
					intArray[i, j] = random.Next(minimumRandomNumber, maximumRandomNumber);
					Console.Write(intArray[i, j] + " ");
				}
				Console.WriteLine();
			}

			for (int i = indexLineToSum; i < intArray.GetLength(0); i++)
			{
				for (int j = 0; j < intArray.GetLength(1); j++)
				{
					if (i == indexLineToSum)
					{
						sumLine += intArray[i, j];
					}
				}
			}

			for (int i = 0; i < intArray.GetLength(0); i++)
			{
				for (int j = indexColumnToMultyply; j < intArray.GetLength(1); j++)
				{
					if (j == indexColumnToMultyply)
					{
						multiplyColumn *= intArray[i, j];
					}
				}
			}

			Console.WriteLine($"Сумма чисел строки {indexLineToSum + 1} = {sumLine}");
			Console.WriteLine($"Произведение чисел столбца {indexColumnToMultyply + 1} = {multiplyColumn}");
		}
	}
}
