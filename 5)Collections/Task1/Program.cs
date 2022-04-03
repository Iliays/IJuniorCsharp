using System;
using System.Collections.Generic;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Создать программу, которая принимает от пользователя слово и выводит его значение. 
			 * Если такого слова нет, то следует вывести соответствующее сообщение.
			 */

			Dictionary<string, string> dictionaryNameMusicGroup = new Dictionary<string, string>();
			string userInput;

			dictionaryNameMusicGroup.Add("Itch", "Nothing But Thieves");
			dictionaryNameMusicGroup.Add("Centuries", "Fall Out Boy");
			dictionaryNameMusicGroup.Add("Creep", "Radiohead");
			dictionaryNameMusicGroup.Add("Killer Queen", "Queen");

			userInput = Console.ReadLine();

			if (dictionaryNameMusicGroup.ContainsKey(userInput))
			{
				Console.WriteLine(dictionaryNameMusicGroup[userInput]);
			}
			else
			{
				Console.WriteLine("Песня не найдена");
			}
		}
	}
}
