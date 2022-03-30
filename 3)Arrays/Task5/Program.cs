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
			int temporaryCountRepeat = 0;
			int moreRepeatCount = 0;
			int numberRepeatNow;
			int numberMoreRepeat = 0;
			int temporaryNumberWas = 0; // для проверки что данное число уже было

			for (int i = 0; i < intArray.Length; i++)
			{
				intArray[i] = random.Next(minimumRandomNumber, maximumRandomNumber);
				Console.Write(intArray[i] + " ");
			}

			for (int i = 0; i < intArray.Length; i++)
			{
				numberRepeatNow = intArray[i];
				for (int j = i; j < intArray.Length; j++)
				{
					if (temporaryNumberWas == numberRepeatNow)
					{
						break;
					}
					if (intArray[j] == numberRepeatNow)
					{
						temporaryCountRepeat++;
					}
					else
					{
						break;
					}
				}
				temporaryNumberWas = numberRepeatNow;
				if (temporaryCountRepeat > moreRepeatCount)
				{
					moreRepeatCount = temporaryCountRepeat;
					numberMoreRepeat = numberRepeatNow;
				}
				temporaryCountRepeat = 0;
			}

			Console.WriteLine($"\nБольше всего подряд повторяется {numberMoreRepeat}, количество повторений {moreRepeatCount}");
		}
	}
}
