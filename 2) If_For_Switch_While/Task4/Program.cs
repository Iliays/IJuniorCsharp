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

			Random number = new Random();
			int randomNumber = number.Next(0, 100);
			int sumPositiveNumbers = 0;

			for (int i = 1; i <= randomNumber; i++)
			{
				if (i % 3 == 0 || i % 5 == 0)
				{
					sumPositiveNumbers += i;
					Console.WriteLine(i);
				}
			}

			Console.WriteLine("Случайное число " + randomNumber);
			Console.WriteLine("Сумма чисел кратных 3 или 5 = " + sumPositiveNumbers);
		}
	}
}
