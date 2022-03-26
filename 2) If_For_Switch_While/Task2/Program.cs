using System;

namespace Task2
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Написать программу, которая будет выполняться до тех пор, пока не будет введено слово exit.
			 * Помните, в цикле должно быть условие, которое отвечает за то, когда цикл должен завершиться.
			 * Это нужно, чтобы любой разработчик взглянув на ваш код, понял четкие границы вашего цикла.
			 */

			string userInput;
			userInput = Console.ReadLine();

			while (userInput != "exit")
			{
				userInput = Console.ReadLine();
			}
		}
	}
}
