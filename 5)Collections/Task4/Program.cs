using System;
using System.Collections.Generic;

namespace Task4
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * В функциях вы выполняли задание "Кадровый учёт"
			 * Используя одну из изученных коллекций, вы смогли бы сильно себе 
			 * упростить код выполненной программы, ведь у нас данные, это ФИО и позиция.
			 * Поиск в данном задании не нужен.
			 * 1) добавить досье
			 * 2) вывести все досье (в одну строку через “-” фио и должность)
			 * 3) удалить досье
			 * 4) выход
			 */

			Dictionary<string, string> dictionaryFullNameAndPost = new Dictionary<string, string>();
			bool isExit = false;

			dictionaryFullNameAndPost.Add("Пушкин Александр Сергеевич", "Писатель");
			dictionaryFullNameAndPost.Add("Есенин Сергей Александрович", "Поэт");
			dictionaryFullNameAndPost.Add("Леонардо Ди Каприо", "Актер");

			while (isExit == false)
			{
				Console.WriteLine("1) добавить досье\n" +
					"2) вывести все досье\n" +
					"3) удалить досье\n" +
					"4) выход");
				string userInput = Console.ReadLine();

				Console.Clear();

				switch (userInput)
				{
					case "1":
						AddElementToDictionary(ref dictionaryFullNameAndPost);
						break;
					case "2":
						WriteAllCases(dictionaryFullNameAndPost);
						break;
					case "3":
						RemoveElementToDictionary(ref dictionaryFullNameAndPost);
						break;
					case "4":
						isExit = true;
						break;
				}

				Console.Clear();
			}
		}

		static void AddElementToDictionary(ref Dictionary<string, string> dictionary)
		{
			Console.Write("Введите ФИО: ");
			string inputFullName = Console.ReadLine();
			Console.Write("Введите должность: ");
			string inputPost = Console.ReadLine();
			dictionary.Add(inputFullName, inputPost);
		}

		static void WriteAllCases(Dictionary<string, string> dictionary)
		{
			foreach (var item in dictionary)
			{
				Console.WriteLine($"{item.Key} - {item.Value}");
			}

			Console.ReadKey();
		}

		static void RemoveElementToDictionary(ref Dictionary<string, string> dictionary)
		{
			Console.Write("Введите ФИО: ");
			string inputFullName = Console.ReadLine();
			dictionary.Remove(inputFullName);
		}
	}
}
