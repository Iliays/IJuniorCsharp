using System;

namespace Task3
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Написать функцию, которая запрашивает число у пользователя 
			 * (с помощью метода Console.ReadLine() ) и пытается сконвертировать 
			 * его в тип int (с помощью int.TryParse())
			 * Если конвертация не удалась у пользователя запрашивается число повторно до тех пор, 
			 * пока не будет введено верно. После ввода, который удалось преобразовать в число, число возвращается.
			 * P.S Задача решается с помощью циклов
			 * P.S Также в TryParse используется модфикатор параметра out
			 */

			TryParseToInt();
		}

		static void TryParseToInt()
		{
			string userInput;
			bool isWorking = true;

			while (isWorking == true)
			{
				Console.Write("Введите: ");
				userInput = Console.ReadLine();
				bool isNumber = int.TryParse(userInput, out int number);

				if (isNumber == true)
				{
					isWorking = false;
					Console.WriteLine("Число: " + userInput);
				}
			}
		}
	}
}
