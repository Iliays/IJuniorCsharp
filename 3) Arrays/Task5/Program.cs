using System;

namespace Task5
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * В массиве чисел найдите самый длинный подмассив из одинаковых чисел.
			 * Дано 30 чисел. Вывести в консоль сам массив, число, которое само больше раз повторяется подряд и количество повторений.
			 */

			int[] intArray = new int[30];
			Random random = new Random();
			int minimumRandomNumber = 1;
			int maximumRandomNumber = 5;
			int temporaryCountRepeat = 1;
			int moreRepeatCount = 0;
			int numberMoreRepeat = 0;

			for (int i = 0; i < intArray.Length; i++)
			{
				intArray[i] = random.Next(minimumRandomNumber, maximumRandomNumber);
				Console.Write(intArray[i] + " ");
			}

			for (int i = 1; i < intArray.Length; i++)
			{
				if (intArray[i] == intArray[i - 1])
				{
					temporaryCountRepeat++;
				}
				else
				{
					temporaryCountRepeat = 1;
				}
				if (temporaryCountRepeat >= moreRepeatCount)
				{
					numberMoreRepeat = intArray[i];
					moreRepeatCount = temporaryCountRepeat;
				}
			}

			Console.WriteLine($"\nБольше всего подряд повторяется {numberMoreRepeat}, количество повторений {moreRepeatCount}");
		}
	}
}
