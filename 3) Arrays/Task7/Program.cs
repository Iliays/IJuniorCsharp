using System;

namespace Task7
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Дана строка с текстом, используя метод строки String.Split() получить массив слов, 
			 * которые разделены пробелом в тексте и вывести массив, каждое слово с новой строки.
			 */

			string text = "Вот значит как";
			string[] words = text.Split(new char[] { ' ' });

			foreach (var word in words)
			{
				Console.WriteLine(word);
			}
		}
	}
}
