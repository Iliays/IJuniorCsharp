using System;
using System.Collections.Generic;
using System.Linq;

/*
 * У вас есть список больных(минимум 10 записей)
 * Класс больного состоит из полей: ФИО, возраст, заболевание.
 * Требуется написать программу больницы, в которой перед пользователем будет меню со следующими пунктами:
 * 1)Отсортировать всех больных по фио
 * 2)Отсортировать всех больных по возрасту
 * 3)Вывести больных с определенным заболеванием
 * (название заболевания вводится пользователем с клавиатуры)
 */

namespace Task3
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Patient> patients = new List<Patient> { new Patient("Кошкаров Александр", 25, "Камни в почках"), 
				new Patient("Козлов Виктор", 20, "Гастрит"),
				new Patient("Архипов Константин", 30, "Гастрит"),
				new Patient("Иванов Иван", 40, "Гепатоз"),
				new Patient("Смирнов Марк", 21, "ВИЧ"),
				new Patient("Попов Игорь", 44, "Гастрит"),
				new Patient("Васильев Генадий", 34, "Меторхоз"),
				new Patient("Петров Евгений", 37, "Камни в почках"),
				new Patient("Соколов Георгий", 33, "Гепатоз"),
				new Patient("Михайлов Артем", 35, "ВИЧ")};

			bool isWorking = true;

			while (isWorking)
			{
				ShowList(patients);
				Console.WriteLine("1)Отсортировать всех больных по фио\n" +
					"2)Отсортировать всех больных по возрасту\n" +
					"3)Вывести больных с определенным заболеванием\n" +
					"4)Выход");
				string userInput = Console.ReadLine();

				switch (userInput)
				{
					case "1":
						SortByFullName(patients);
						break;
					case "2":
						SortByAge(patients);
						break;
					case "3":
						ShowPatientsWithDisease(patients);
						break;
					case "4":
						isWorking = false;
						break;
				}

				Console.Clear();
			}
		}

		static void ShowList(List<Patient> patients)
		{
			foreach (var patient in patients)
			{
				Console.WriteLine($"ФИО: {patient.FullName}, возраст {patient.Age}, болезнь - {patient.Disease}");
			}
		}

		static void SortByFullName(List<Patient> patients)
		{
			var sortingPatientsByFullName = patients.OrderBy(patient => patient.FullName);

			foreach (var patient in sortingPatientsByFullName)
			{
				Console.WriteLine($"ФИО: {patient.FullName}");
			}

			Console.ReadKey();
		}

		static void SortByAge(List<Patient> patients)
		{
			var sortingPatientsByAge = patients.OrderBy(patient => patient.Age);

			foreach (var patient in sortingPatientsByAge)
			{
				Console.WriteLine($"ФИО: {patient.FullName}, возраст - {patient.Age}");
			}

			Console.ReadKey();
		}

		static void ShowPatientsWithDisease(List<Patient> patients)
		{
			Console.Write("введите название болезни: ");
			string inputDisease = Console.ReadLine();
			var patientsWithDisease = patients.Where(patient => patient.Disease.ToLower() == inputDisease.ToLower());

			if (patientsWithDisease.Count() == 0)
			{
				Console.WriteLine("Пациентов с таким заболеванием не найдено");
			}
			else
			{
				foreach (var patient in patientsWithDisease)
				{
					Console.WriteLine($"ФИО: {patient.FullName}, болезнь - {patient.Disease}");
				}
			}

			Console.ReadKey();
		}
	}

	class Patient
	{
		public string FullName { get; private set; }
		public int Age { get; private set; }
		public string Disease { get; private set; }

		public Patient(string fullName, int age, string disease)
		{
			FullName = fullName;
			Age = age;
			Disease = disease;
		}
	}
}
