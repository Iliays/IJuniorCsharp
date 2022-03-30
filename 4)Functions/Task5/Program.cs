using System;

namespace Task5
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Реализуйте функцию Shuffle, которая перемешивает элементы массива в случайном порядке.
			 */
			int[] intArray = new[] { 1, 22, 3, 4, 5};

			Console.WriteLine(string.Join(" ", intArray));

			Shuffle(intArray);

			Console.WriteLine(string.Join(" ", intArray));
		}

		static void Shuffle(int[] array)
		{
			Random random = new Random();

			for (int i = 0; i < array.Length; i++)
			{
				int randomNumber = random.Next(0, array.Length);
				int temp = array[randomNumber];
				array[randomNumber] = array[i];
				array[i] = temp;
			}
		}
	}
}
