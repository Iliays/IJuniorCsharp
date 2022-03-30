using System;

namespace Task3
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Нужно написать программу (используя циклы, обязательно пояснить выбор вашего цикла), 
			 * чтобы она выводила следующую последовательность 5 12 19 26 33 40 47 54 61 68 75 82 89 96.
			 * Нужны переменные для обозначения чисел в условии цикла.
			 */

			int increaseNumber = 7, maxNumber = 96;

			for (int number = 5; number <= maxNumber; number += increaseNumber)
			{
				Console.WriteLine(number);
			}

			/*
			 * Выбрал цикл for, так как имеется четкая граница числа(96) и шаг(7).
			 */
		}
	}
}
