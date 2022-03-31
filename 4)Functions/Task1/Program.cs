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

			while (isExit == false)
			{
				Console.WriteLine("1) добавить досье\n" +
					"2) вывести все досье\n" +
					"3) удалить досье\n" +
					"4) поиск по фамилии\n" +
					"5) выход");
				string userInput = Console.ReadLine();

				Console.Clear();

				switch (userInput)
				{
					case "1":
						AddElementToArray(ref surnamesArray, ref postArray);
						break;
					case "2":
						WriteAllCases(surnamesArray, postArray);
						break;
					case "3":
						DeleteByIndexToArray(ref surnamesArray, ref postArray);
						break;
					case "4":
						SearchBySurname(surnamesArray, postArray);
						break;
					case "5":
						isExit = true;
						break;
				}

				Console.Clear();
			}
		}

		static void AddElementToArray(ref string[] arraySurname, ref string[] arrayPost)
		{
			Console.Write("Введите фамилию: ");
			string userInputSurname = Console.ReadLine();
			Console.Write("Введите должность: ");
			string userInputPost = Console.ReadLine();

			string[] temporaryArraySurname = new string[arraySurname.Length + 1];
			string[] temporaryArrayPost = new string[arraySurname.Length + 1];

			for (int i = 0; i < arraySurname.Length; i++)
			{
				temporaryArraySurname[i] = arraySurname[i];
				temporaryArrayPost[i] = arrayPost[i];
			}

			temporaryArraySurname[temporaryArraySurname.Length - 1] = userInputSurname;
			arraySurname = temporaryArraySurname;
			temporaryArrayPost[temporaryArrayPost.Length - 1] = userInputPost;
			arrayPost = temporaryArrayPost;
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

		static void SearchBySurname(string[] surnamesArray, string[] postArray)
		{
			Console.Write("Введите фамалию: ");
			string surname = Console.ReadLine();

			bool isFind = false;

			for (int i = 0; i < surnamesArray.Length; i++)
			{
				if (surname.ToLower() == surnamesArray[i].ToLower())
				{
					isFind = true;
					Console.WriteLine($"Найден человек: {surnamesArray[i]} - {postArray[i]}");
				}
			}

			if (isFind == false)
			{
				Console.WriteLine("Не найдено!");
			}

			Console.ReadKey();
		}

		static void DeleteByIndexToArray(ref string[] arraySurname, ref string[] arrayPost)
		{
			Console.Write($"Введите номер досье для удаления: ");
			int index = Convert.ToInt32(Console.ReadLine());

			if (index > arraySurname.Length && index > arrayPost.Length)
			{
				Console.WriteLine("Такого досье не существует");
				Console.ReadKey();
			}
			else
			{
				string[] temporaryArraySurname = new string[arraySurname.Length - 1];
				string[] temporaryArrayPost = new string[arraySurname.Length - 1];
				int indexNormolize = index - 1;

				for (int i = 0; i < arraySurname.Length; i++)
				{
					if (i < indexNormolize)
					{
						temporaryArraySurname[i] = arraySurname[i];
						temporaryArrayPost[i] = arrayPost[i];
					}
					else if (i > indexNormolize)
					{
						temporaryArraySurname[i - 1] = arraySurname[i];
						temporaryArrayPost[i - 1] = arrayPost[i];
					}
				}

				arraySurname = temporaryArraySurname;
				arrayPost = temporaryArrayPost;
			}
		}
	}
}