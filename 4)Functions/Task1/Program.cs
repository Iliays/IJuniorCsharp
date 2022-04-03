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

			string[] fullNameArray = { "Пушкин Александр Сергеевич", "Есенин Сергей Александрович" };
			string[] postArray = { "Писатель", "Поэт" };
			bool isExit = false;

			while (isExit == false)
			{
				Console.WriteLine("1) добавить досье\n" +
					"2) вывести все досье\n" +
					"3) удалить досье\n" +
					"4) поиск по ФИО\n" +
					"5) выход");
				string userInput = Console.ReadLine();

				Console.Clear();

				switch (userInput)
				{
					case "1":
						AddElementToArray(ref fullNameArray, ref postArray);
						break;
					case "2":
						WriteAllCases(fullNameArray, postArray);
						break;
					case "3":
						DeleteByIndexToArray(ref fullNameArray, ref postArray);
						break;
					case "4":
						SearchByFullName(fullNameArray, postArray);
						break;
					case "5":
						isExit = true;
						break;
				}

				Console.Clear();
			}
		}

		static void AddElementToArray(ref string[] fullNameArray, ref string[] postArray)
		{
			AddElementToArray(ref fullNameArray, "ФИО");
			AddElementToArray(ref postArray, "должность");
		}

		static void AddElementToArray(ref string[] array, string needToInput)
		{
			Console.Write($"Введите {needToInput}: ");
			string userInput = Console.ReadLine();

			string[] temporaryArray = new string[array.Length + 1];

			for (int i = 0; i < array.Length; i++)
			{
				temporaryArray[i] = array[i];
			}

			temporaryArray[temporaryArray.Length - 1] = userInput;
			array = temporaryArray;
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

		static void SearchByFullName(string[] fullNameArray, string[] postArray)
		{
			Console.Write("Введите фамилию: ");
			string surname = Console.ReadLine();

			bool isFind = false;

			for (int i = 0; i < fullNameArray.Length; i++)
			{
				string[] surnameArray = fullNameArray[i].Split(' ');
				if (surname.ToLower() == surnameArray[0].ToLower())
				{
					isFind = true;
					Console.WriteLine($"Найден человек: {fullNameArray[i]} - {postArray[i]}");
				}
			}

			if (isFind == false)
			{
				Console.WriteLine("Не найдено!");
			}

			Console.ReadKey();
		}

		static void DeleteByIndexToArray(ref string[] fullNameArray, ref string[] postArray)
		{
			Console.Write($"Введите номер досье для удаления: ");
			int index = Convert.ToInt32(Console.ReadLine());
			DeleteByIndexToArray(ref fullNameArray, index);
			DeleteByIndexToArray(ref postArray, index);
		}

		static void DeleteByIndexToArray(ref string[] array, int index)
		{
			if (index > array.Length || index <= 0)
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
		}
	}
}