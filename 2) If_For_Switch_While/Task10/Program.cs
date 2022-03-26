using System;

namespace Task10
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Найдите минимальную степень двойки, превосходящую заданное число.
			 * К примеру, для числа 4 будет 2 в степени 3, то есть 8. 4<8.
			 * Для числа 29 будет 2 в степени 5, то есть 32. 29<32.
			 * В консоль вывести число (лучше получить от Random), степень и само число 2 в найденной степени.
			 */

			Random number = new Random();
			int minimumRandomNumber = 1;
			int maximumRandomNumber = 100;
			int randomNumber = number.Next(minimumRandomNumber, maximumRandomNumber);
			int degree = 2;
			int numberToDegree = 2;
			int degreeLevel = 1;

			while (randomNumber > numberToDegree)
			{
				numberToDegree *= degree;
				degreeLevel++;
			}

			Console.WriteLine($"Число {randomNumber}\nДвойка в {degreeLevel} степени = {numberToDegree}");
		}
	}
}
