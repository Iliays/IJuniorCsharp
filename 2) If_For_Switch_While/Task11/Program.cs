using System;

namespace Task11
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Дана строка из символов '(' и ')'. 
			 * Определить, является ли она корректным скобочным выражением. 
			 * Определить максимальную глубину вложенности скобок.
			 * Пример “(()(()))” - строка корректная и максимум глубины равняется 3.
			 * Пример не верных строк: "(()", "())", ")(", "(()))(()"
			 * Для перебора строки по символам можно использовать цикл foreach, к примеру будет так foreach (var symbol in text)
			 */

			string inputUser = Console.ReadLine();
			int bracketCounter = 0;
			int depth = 0;

			for (int i = 0; i < inputUser.Length; i++)
			{
				if (inputUser[i] == '(')
				{
					bracketCounter++;
				}
				else
				{
					if (i != inputUser.Length - 1 && inputUser[i] != '(')
					{
						depth++;
					}
					bracketCounter--;
				}
			}

			if (bracketCounter == 0)
			{
				Console.WriteLine($"{inputUser} - строка корректная и максимум глубины равняется {depth}");
			}
			else
				Console.WriteLine($"{inputUser} - строка является некорректной");
		}
	}
}
