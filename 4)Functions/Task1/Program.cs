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
			string userInputSurname = "";
			string userInputPost = "";
			int indexToDelete = 0;
			string needToEnterSurname = "фамилию";
			string needToEnterPost = "должность";

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
						surnamesArray = AddElementToArray(userInputSurname, surnamesArray, needToEnterSurname);
						postArray = AddElementToArray(userInputPost, postArray, needToEnterPost);
						break;
					case "2":
						WriteAllCases(surnamesArray, postArray);
						break;
					case "3":
						surnamesArray = DeleteByIndexToArray(indexToDelete, surnamesArray, needToEnterSurname);
						postArray = DeleteByIndexToArray(indexToDelete, postArray, needToEnterPost);
						break;
					case "4":
						SearchBySurname(userInputSurname, surnamesArray, postArray);
						break;
					case "5":
						isExit = true;
						break;
				}

				Console.Clear();
			}
		}

		static string[] AddElementToArray(string userInput, string[] array, string needToEnter)
		{
			Console.Write($"Введите {needToEnter}: ");
			userInput = Console.ReadLine();

			string[] temporaryArray = new string[array.Length + 1];

			for (int i = 0; i < array.Length; i++)
			{
				temporaryArray[i] = array[i];
			}

			temporaryArray[temporaryArray.Length - 1] = userInput;
			array = temporaryArray;
			return array;
		}

		static void WriteAllCases(string[] surnamesArray, string[] postArray)
		{
			int normalizeIndex = 0;

			for (int i = 0; i < surnamesArray.Length; i++)
			{
				normalizeIndex++;
				Console.WriteLine($"{normalizeIndex}) {surnamesArray[i]} - {postArray[i]}");
			}

			Console.ReadKey();
		}

		static void SearchBySurname(string surname, string[] surnamesArray, string[] postArray)
		{
			Console.Write("Введите фамалию: ");
			surname = Console.ReadLine();

			bool isFind = false;

			for (int i = 0; i < surnamesArray.Length; i++)
			{
				if (surname.ToLower() == surnamesArray[i].ToLower())
				{
					isFind = true;
					Console.WriteLine($"Найден  человек: {surnamesArray[i]} - {postArray[i]}");
				}
			}

			if (isFind == false)
			{
				Console.WriteLine("Не найдено!");
			}

			Console.ReadKey();
		}

		static string[] DeleteByIndexToArray(int index, string[] array, string needToEnter)
		{
			Console.Write($"Введите номер досье для удаления {needToEnter}: ");
			index = Convert.ToInt32(Console.ReadLine());

			if (index > array.Length)
			{
				Console.WriteLine("Такого досье не существует");
				Console.ReadKey();
			}
			else
			{
				string[] temporaryArray = new string[array.Length - 1];
				int indexNormolize = index - 1;

				for (int i = 0; i < array.Length; i++)
				{
					if (i < indexNormolize)
					{
						temporaryArray[i] = array[i];
					}
					else if (i > indexNormolize)
					{
						temporaryArray[i - 1] = array[i];
					}
				}

				array = temporaryArray;
			}

			return array;
		}
	}
}