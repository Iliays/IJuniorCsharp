using System;
using System.Collections.Generic;

namespace Task2
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * У вас есть множество целых чисел. Каждое целое число - это сумма покупки.
			 * Вам нужно обслуживать клиентов до тех пор, пока очередь не станет пуста.
			 * После каждого обслуженного клиента деньги нужно добавлять на наш счёт и выводить его в консоль.
			 * После обслуживания каждого клиента программа ожидает нажатия любой клавиши, 
			 * после чего затирает консоль и по новой выводит всю информацию, только уже со следующим клиентом
			 */

			Queue<int> clients = new Queue<int>();
			int myAccount = 0;

			clients.Enqueue(100);
			clients.Enqueue(120);
			clients.Enqueue(140);
			clients.Enqueue(160);
			clients.Enqueue(200);

			while (clients.Count > 0)
			{
				Console.Clear();
				myAccount += clients.Dequeue();
				Console.WriteLine($"Счет: {myAccount}");
				Console.ReadKey();
			}
		}
	}
}
