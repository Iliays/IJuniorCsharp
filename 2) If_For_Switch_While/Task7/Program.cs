using System;

namespace Task7
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Вывести имя в прямоугольник из символа, который введет сам пользователь.
			 * Вы запрашиваете имя, после запрашиваете символ, а после отрисовываете в 
			 * консоль его имя в прямоугольнике из его символов.
			 * Пример:
			 * Alexey
			 * %
			 * %%%%%%
			 * %Alexey%
			 * %%%%%%
			 * Примечание:
			 * Длину строки можно всегда узнать через свойство Length
			 * string someString = “Hello”;
			 * Console.WriteLine(someString.Length); //5
			 */

			Console.Write("Введите имя:");
			string userInputName = Console.ReadLine();
			Console.Write("Введите символ:");
			char userInputSymbol = Convert.ToChar(Console.ReadLine());
			string lengthSymbols = "";

			for (int i = 0; i < userInputName.Length; i++)
			{
				lengthSymbols += userInputSymbol;
			}

			Console.WriteLine($"{lengthSymbols}\n{userInputSymbol}{userInputName}{userInputSymbol}\n{lengthSymbols}");
		}
	}
}
