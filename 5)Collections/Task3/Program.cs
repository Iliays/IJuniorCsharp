using System;
using System.Collections.Generic;

namespace Task3
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * В массивах вы выполняли задание "Динамический массив"
			 * Используя всё изученное, напишите улучшенную версию динамического массива(не обязательно брать своё старое решение)
			 * Задание нужно, чтобы вы освоились с List и прощупали его преимущество.
			 * Проверка на ввод числа обязательна.
			 * Пользователь вводит числа, и программа их запоминает.
			 * Как только пользователь введёт команду sum, программа выведет сумму всех веденных чисел.
			 * Выход из программы должен происходить только в том случае, если пользователь введет команду exit.
			 */

			bool isExit = false;
			string userInput;
			List<int> intList = new List<int>();

			while (isExit == false)
			{
				Console.Write("Введите число или команду:");
				userInput = Console.ReadLine();

				if (userInput == "exit")
				{
					isExit = true;
				}
				else if (userInput == "sum")
				{
					int sumOfArray = 0;
					for (int i = 0; i < intList.Count; i++)
					{
						sumOfArray += intList[i];
					}
					Console.WriteLine("Сумма чисел в массиве = " + sumOfArray);
				}
				else if (int.TryParse(userInput, out int number) == true)
				{
					intList.Add(number);
				}
			}
		}
	}
}
