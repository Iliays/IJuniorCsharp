using System;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Будет 2 массива: 1) фио 2) должность.
			 * Описать функцию заполнения массивов досье, функцию форматированного вывода, 
			 * функцию поиска по фамилии и функцию удаления досье.
			 * Функция расширяет уже имеющийся массив на 1 и дописывает туда новое значение.
			 * Программа должна быть с меню, которое содержит пункты:
			 * 1) добавить досье
			 * 2) вывести все досье (в одну строку через “-” фио и должность с порядковым номером в начале)
			 * 3) удалить досье (Массивы уменьшаются на один элемент. 
			 * Нужны дополнительные проверки, чтобы не возникало ошибок)
			 * 4) поиск по фамилии
			 * 5) выход
			 */

			string[] surnamesArray = { "Меркури", "Боков", "Кощанов" };
			string[] postArray = { "Певец", "Грузчик", "Уборщик" };
			bool isExit = false;
			string userInput;
			string userInputSurname;
			string userInputPost;
			int indexToDelete;

			while (isExit == false)
			{
				Console.WriteLine("1) добавить досье\n" +
					"2) вывести все досье\n" +
					"3) удалить досье\n" +
					"4) поиск по фамилии\n" +
					"5) выход");
				userInput = Console.ReadLine();

				Console.Clear();

				switch (userInput)
				{
					case "1":
						Console.Write("Введите фамалию: ");
						userInputSurname = Console.ReadLine();
						surnamesArray = AddSurname(userInputSurname, surnamesArray);

						Console.Write("Введите должность: ");
						userInputPost = Console.ReadLine();
						postArray = AddPost(userInputPost, postArray);
						break;
					case "2":
						WriteAllCases(surnamesArray, postArray);
						Console.ReadKey();
						break;
					case "3":
						WriteAllCases(surnamesArray, postArray);

						Console.Write("Введите номер досье для удаления: ");
						indexToDelete = Convert.ToInt32(Console.ReadLine());

						surnamesArray = DeleteByIndexSurname(indexToDelete, surnamesArray);
						postArray = DeleteByIndexPost(indexToDelete, postArray);
						break;
					case "4":
						Console.Write("Введите фамалию: ");
						userInputSurname = Console.ReadLine();

						SearchBySurname(userInputSurname, surnamesArray, postArray);
						Console.ReadKey();
						break;
					case "5":
						isExit = true;
						break;
				}

				Console.Clear();
			}
		}

		static string[] AddSurname(string userInputSurname, string[] surnamesArray)
		{
			string[] temporaryArray = new string[surnamesArray.Length + 1];

			for (int i = 0; i < surnamesArray.Length; i++)
			{
				temporaryArray[i] = surnamesArray[i];
			}

			temporaryArray[temporaryArray.Length - 1] = userInputSurname;
			surnamesArray = temporaryArray;
			return surnamesArray;
		}

		static string[] AddPost(string userInputPost, string[] postArray)
		{
			string[] temporaryArray = new string[postArray.Length + 1];

			for (int i = 0; i < postArray.Length; i++)
			{
				temporaryArray[i] = postArray[i];
			}

			temporaryArray[temporaryArray.Length - 1] = userInputPost;
			postArray = temporaryArray;
			return postArray;
		}

		static void WriteAllCases(string[] surnamesArray, string[] postArray)
		{
			int normalizeIndex = 0;

			for (int i = 0; i < surnamesArray.Length; i++)
			{
				normalizeIndex++;
				Console.WriteLine($"{normalizeIndex}) {surnamesArray[i]} - {postArray[i]}");
			}
		}

		static void SearchBySurname(string surname, string[] surnamesArray, string[] postArray)
		{
			bool isFind = false;

			for (int i = 0; i < surnamesArray.Length; i++)
			{
				if (surname.ToLower() == surnamesArray[i].ToLower())
				{
					isFind = true;
					Console.WriteLine($"Найден  человек: {surnamesArray[i]} {postArray[i]}");
				}
			}

			if (isFind == false)
			{
				Console.WriteLine("Не найдено!");
			}
		}

		static string[] DeleteByIndexSurname(int index, string[] surnamesArray)
		{
			string[] temporaryArray = new string[surnamesArray.Length - 1];
			int indexNormolize = index - 1;

			for (int i = 0; i < surnamesArray.Length; i++)
			{
				if (i < indexNormolize)
				{
					temporaryArray[i] = surnamesArray[i];
				}
				else if (i > indexNormolize)
				{
					temporaryArray[i - 1] = surnamesArray[i];
				}
			}

			surnamesArray = temporaryArray;
			return surnamesArray;
		}

		static string[] DeleteByIndexPost(int index, string[] postArray)
		{
			string[] temporaryArray = new string[postArray.Length - 1];
			int indexNormolize = index - 1;

			for (int i = 0; i < postArray.Length; i++)
			{
				if (i < index)
				{
					temporaryArray[i] = postArray[i];
				}
				else if (i > index)
				{
					temporaryArray[i - 1] = postArray[i];
				}
			}

			postArray = temporaryArray;
			return postArray;
		}
	}
}