using System;

namespace Task5
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Написать конвертер валют (3 валюты).
			 * У пользователя есть баланс в каждой из представленных валют. 
			 * Он может попросить сконвертировать часть баланса с одной валюты в другую. 
			 * Тогда у него с баланса одной валюты снимется X и зачислится на баланс другой Y. 
			 * Курс конвертации должен быть просто прописан в программе.
			 * По имени переменной курса конвертации должно быть понятно из какой валюты в какую валюту конвертируется.
			 * Программа должна завершиться тогда, когда это решит пользователь.
			 */

			int rubleToDollar = 82, dollarToRuble = 80, euroToRuble = 90, rubleToEuro = 88, euroToDollar = 1, dollarToEuro = 2;
			float dollar = 10, ruble = 200, euro = 5;
			float countToTransferMoney;
			string functionSelector;
			bool isExit = true;

			Console.WriteLine("Добро пожаловать в обменник валюты!!!");

			while (isExit)
			{
				Console.WriteLine($"Ваш баланс {ruble} рублей, {dollar} долларов, {euro} евро.");
				Console.WriteLine("Выберите услугу:\n1 - перевод из евро в доллары\n2 - перевод из евро в рубли\n" +
					"3 - перевод из рублей в доллары\n4 - перевод из рублей в евро\n" +
					"5 - перевод из долларов в рубли\n6 - перевод из долларов в евро\n" +
					"0 - завершить транзакции");
				functionSelector = Console.ReadLine();
				switch (functionSelector)
				{
					case "0":
						isExit = false;
						break;
					case "1":
						Console.WriteLine("Обмен евро на доллары");
						Console.Write("Сколько хотите обменять:");
						countToTransferMoney = Convert.ToSingle(Console.ReadLine());
						if (euro >= countToTransferMoney)
						{
							euro -= countToTransferMoney;
							dollar += countToTransferMoney / euroToDollar;
						}
						else
						{
							Console.WriteLine("Недостаточно средств");
						}
						break;
					case "2":
						Console.WriteLine("Обмен евро на рубли");
						Console.Write("Сколько хотите обменять:");
						countToTransferMoney = Convert.ToSingle(Console.ReadLine());
						if (euro >= countToTransferMoney)
						{
							euro -= countToTransferMoney;
							ruble += countToTransferMoney * euroToRuble;
						}
						else
						{
							Console.WriteLine("Недостаточно средств");
						}
						break;
					case "3":
						Console.WriteLine("Обмен рублей на доллары");
						Console.Write("Сколько хотите обменять:");
						countToTransferMoney = Convert.ToSingle(Console.ReadLine());
						if (ruble >= countToTransferMoney)
						{
							ruble -= countToTransferMoney;
							dollar += countToTransferMoney / rubleToDollar;
						}
						else
						{
							Console.WriteLine("Недостаточно средств");
						}
						break;
					case "4":
						Console.WriteLine("Обмен рублей на евро");
						Console.Write("Сколько хотите обменять:");
						countToTransferMoney = Convert.ToSingle(Console.ReadLine());
						if (ruble >= countToTransferMoney)
						{
							ruble -= countToTransferMoney;
							euro += countToTransferMoney / rubleToEuro;
						}
						else
						{
							Console.WriteLine("Недостаточно средств");
						}
						break;
					case "5":
						Console.WriteLine("Обмен долларов на рубли");
						Console.Write("Сколько хотите обменять:");
						countToTransferMoney = Convert.ToSingle(Console.ReadLine());
						if (dollar >= countToTransferMoney)
						{
							dollar -= countToTransferMoney;
							ruble += countToTransferMoney * dollarToRuble;
						}
						else
						{
							Console.WriteLine("Недостаточно средств");
						}
						break;
					case "6":
						Console.WriteLine("Обмен долларов на евро");
						Console.Write("Сколько хотите обменять:");
						countToTransferMoney = Convert.ToSingle(Console.ReadLine());
						if (dollar >= countToTransferMoney)
						{
							dollar -= countToTransferMoney;
							euro += countToTransferMoney / dollarToEuro;
						}
						else
						{
							Console.WriteLine("Недостаточно средств");
						}
						break;
				}
			}

			Console.WriteLine($"Ваш баланс {ruble} рублей, {dollar} долларов, {euro} евро.");
		}
	}
}
