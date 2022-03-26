using System;

namespace Task6
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * При помощи всего, что вы изучили, создать приложение, которое может обрабатывать команды. 
			 * Т.е. вы создаете меню, ожидаете ввода нужной команды, после чего выполняете действие, 
			 * которое присвоено этой команде.
			 * Примеры команд (требуется 4-6 команд, придумать самим):
			 * SetName – установить имя;
			 * ChangeConsoleColor- изменить цвет консоли;
			 * SetPassword – установить пароль;
			 * WriteName – вывести имя (после ввода пароля);
			 * Esc – выход из программы.
			 * Программа не должна завершаться после ввода, пользователь сам должен выйти из программы при помощи команды.
			 */

			bool isExit = true;
			string userInputSelector;
			string name = "";

			while (isExit)
			{
				Console.WriteLine("Выберите команду:\n1 - SetName(ввод имени)\n2 - WriteName(вывести имя)\n" +
					"3 - ChangeConsoleTextColor(изменить цвет текста)\n4 - ChangeConsoleBackgroundColor(изменить цвет фона)\n" +
					"0 - Esc - выйти");
				userInputSelector = Console.ReadLine();

				switch (userInputSelector)
				{
					case "0":
						isExit = false;
						break;
					case "1":
						Console.Write("Введите имя:");
						name = Console.ReadLine();
						break;
					case "2":
						if(name == "")
						{
							Console.WriteLine("Вы не ввели имя, пожалуйста введите его с помощью команды SetName");
						}
						else
						{
							Console.WriteLine("Вас зовут " + name);
						}
						break;
					case "3":
						Console.ForegroundColor = ConsoleColor.Red;
						break;
					case "4":
						Console.BackgroundColor = ConsoleColor.Green;
						break;
				}
			}
		}
	}
}
