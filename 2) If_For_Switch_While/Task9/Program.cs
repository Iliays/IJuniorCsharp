using System;

namespace Task9
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Дано N (1 ≤ N ≤ 27). Найти количество трехзначных натуральных чисел, 
			 * которые кратны N. Операции деления (/, %) не использовать.
			 */

			int minimumNumber = 1;
			int maximumNumber = 27;
			int naturalNumbersSum = 0;
			int minimumThreeDegitNumber = 100;
			int maximumThreeDigitNumber = 1000;

			Console.WriteLine($"Введите число в данном диапозоне {minimumNumber} <= N <= {maximumNumber}");
			int userInput = Convert.ToInt32(Console.ReadLine());
			int numberToCompare = userInput;

			while (numberToCompare < maximumThreeDigitNumber)
			{
				for (int i = 0; i < maximumThreeDigitNumber; i++)
				{
					if (i > minimumThreeDegitNumber && i < maximumThreeDigitNumber)
					{
						if (i == numberToCompare)
						{
							naturalNumbersSum++;
						}
					}
				}
				numberToCompare += userInput;
			}

			Console.WriteLine(naturalNumbersSum);
		}
	}
}
