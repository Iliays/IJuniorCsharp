using System;

namespace Task4
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * С помощью Random получить число number, которое не больше 100. 
			 * Найти сумму всех положительных чисел меньше number (включая число), 
			 * которые кратные 3 или 5. (К примеру, это числа 3, 5, 6, 9, 10, 12, 15 и т.д.)
			 */

			Random random = new Random();
			int minimumRandomNumber = 0;
			int maximumRandomNumber = 100;
			int randomNumber = random.Next(minimumRandomNumber, maximumRandomNumber);
			int sumPositiveNumbers = 0;
			int multiplicityOfThree = 3;
			int multiplicityOfFive = 5;

			for (int i = 1; i <= randomNumber; i++)
			{
				if (i % multiplicityOfThree == 0 || i % multiplicityOfFive == 0)
				{
					sumPositiveNumbers += i;
					Console.WriteLine(i);
				}
			}

			Console.WriteLine("Случайное число " + randomNumber);
			Console.WriteLine($"Сумма чисел кратных {multiplicityOfThree} или {multiplicityOfFive} = " + sumPositiveNumbers);
		}
	}
}
