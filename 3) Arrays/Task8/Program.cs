using System;

namespace Task8
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Дан массив чисел. Нужно его сдвинуть циклически на указанное пользователем 
			 * значение позиций влево, не используя других массивов. 
			 * Пример для сдвига один раз: {1, 2, 3, 4} => {2, 3, 4, 1}
			 */

			int[] intArray = new int[5];
			Random random = new Random();
			int minimumRandomNumber = 1;
			int maximumRandomNumber = 10;
			int temporaryElement;

			for (int i = 0; i < intArray.Length; i++)
			{
				intArray[i] = random.Next(minimumRandomNumber, maximumRandomNumber);
				Console.Write(intArray[i] + " ");
			}

			Console.Write("\nНа сколько позиций влево сдвинуть:");
			int inputUser = Convert.ToInt32(Console.ReadLine());

			for (int i = 0; i < inputUser; ++i)
			{
				temporaryElement = intArray[0];
				for (int j = 0; j < intArray.Length - 1; j++)
				{
					intArray[j] = intArray[j + 1];
				}
				intArray[intArray.Length - 1] = temporaryElement;
			}

			for (int i = 0; i < intArray.Length; i++)
			{
				Console.Write(intArray[i] + " ");
			}
		}
	}
}
