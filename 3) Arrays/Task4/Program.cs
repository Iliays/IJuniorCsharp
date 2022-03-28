using System;

namespace Task4
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Пользователь вводит числа, и программа их запоминает.
			 * Как только пользователь введёт команду sum, программа выведет сумму всех веденных чисел.
			 * Выход из программы должен происходить только в том случае, если пользователь введет команду exit.
			 * Если введено не sum и не exit, значит это число и его надо добавить в массив.
			 * Программа должна работать на основе расширения массива.
			 * Внимание, нельзя использовать List<T> и Array.Resize
			 */

			bool isExit = false;
			string userInput;
			int[] intArray = new int[0];

			while (isExit == false)
			{
				Console.Write("Введите число или команду:");
				userInput = Console.ReadLine();
				
				if (userInput == "exit")
				{
					isExit = true;
				}
				else if(userInput == "sum") 
				{
					int sumOfArray = 0;
					for (int i = 0; i < intArray.Length; i++)
					{
						sumOfArray += intArray[i];
					}
					Console.WriteLine("Сумма чисел в массиве = " + sumOfArray);
				}
				else
				{
					int[] temperaryArray = new int[intArray.Length + 1];
					for (int i = 0; i < intArray.Length; i++)
					{
						temperaryArray[i] = intArray[i];
					}
					temperaryArray[temperaryArray.Length - 1] = Convert.ToInt32(userInput);
					intArray = temperaryArray;
				}
			}
		}
	}
}
