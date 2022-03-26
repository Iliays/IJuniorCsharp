using System;

namespace Task8
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Создайте переменную типа string, в которой хранится пароль 
			 * для доступа к тайному сообщению. Пользователь вводит пароль, 
			 * далее происходит проверка пароля на правильность, и если пароль неверный, 
			 * то попросите его ввести пароль ещё раз. Если пароль подошёл, выведите секретное сообщение.
			 * Если пользователь неверно ввел пароль 3 раза, программа завершается.
			 */

			int countUserTry = 3;
			string password = "111";
			string userInput;

			while (countUserTry-- > 0)
			{
				Console.WriteLine("Введите пароль:");
				userInput = Console.ReadLine();

				if (password == userInput)
				{
					Console.WriteLine("Секретеные данные...");
					break;
				}
			}
		}
	}
}
