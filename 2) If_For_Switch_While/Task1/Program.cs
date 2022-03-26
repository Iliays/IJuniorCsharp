using System;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			/* 
			 * При помощи циклов вы можете повторять один и тот же код множество раз.
			 * Напишите простейшую программу, которая выводит указанное(установленное) пользователем 
			 * сообщение заданное количество раз.Количество повторов также должен ввести пользователь.
			 */

			string userInput;
			int countMessageOutput;

			Console.Write("Введите сообщение:");
			userInput = Console.ReadLine();
			Console.Write("Сколько раз повторить:");
			countMessageOutput = Convert.ToInt32(Console.ReadLine());

			for (int i = 0; i < countMessageOutput; i++)
			{
				Console.WriteLine(userInput);
			}
		}
	}
}
