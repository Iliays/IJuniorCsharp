using System;
using System.Collections.Generic;

/*
 * Написать программу администрирования супермаркетом.
 * В супермаркете есть очередь клиентов.
 * У каждого клиента в корзине есть товары, также у клиентов есть деньги.
 * Клиент, когда подходит на кассу, получает итоговую сумму покупки и старается её оплатить.
 * Если оплатить клиент не может, то он рандомный товар из корзины выкидывает до тех пор, 
 * пока его денег не хватит для оплаты.
 * Клиентов можно делать ограниченное число на старте программы.
 */

namespace Task09
{
	class Program
	{
		static void Main(string[] args)
		{
			Supermarket supermarket = new Supermarket();
			supermarket.Work();
		}
	}

	class Supermarket
	{
		private Queue<Client> _clientsQueue = new Queue<Client>();

		private void FillingData()
		{
			_clientsQueue.Enqueue(new Client(100, new List<Product>() { new Product("Хлеб", 20), new Product("Молоко", 40), new Product("Колбаса", 40) }));
			_clientsQueue.Enqueue(new Client(100, new List<Product>() { new Product("Вино", 70), new Product("Молоко", 40), new Product("Колбаса", 40) }));
			_clientsQueue.Enqueue(new Client(100, new List<Product>() { new Product("Хлеб", 20), new Product("Сок", 50), new Product("Колбаса", 40) }));
		}

		private void ServiceClients()
		{
			_clientsQueue.Peek().ShowProductsInBasket();

			while (_clientsQueue.Peek().CheckEnoughMoney() != true)
			{
				_clientsQueue.Peek().RemoveFromBasket();
				_clientsQueue.Peek().ShowProductsInBasket();
			}

			if (_clientsQueue.Dequeue().CheckEnoughMoney())
			{
				Console.WriteLine("Клиент оплатил и ушел\n\n");
			}
		}

		public void Work()
		{
			FillingData();

			while (_clientsQueue.Count > 0)
			{
				ServiceClients();
			}
		}
	}

	class Client
	{
		private int _money;
		private List<Product> _basket = new List<Product>();

		public Client(int money, List<Product> list)
		{
			_money = money;
			_basket = list;
		}

		public bool CheckEnoughMoney()
		{
			int totalPrice = 0;

			for (int i = 0; i < _basket.Count; i++)
			{
				totalPrice += _basket[i].ProductPrice;
			}

			if (_money >= totalPrice)
				return true;
			else
				return false;
		}

		public void RemoveFromBasket()
		{
			Random random = new Random();
			int randomNumber = random.Next(0, _basket.Count);

			_basket.RemoveAt(randomNumber);
		}

		public void ShowProductsInBasket()
		{
			foreach (var product in _basket)
			{
				product.ShowInfo();
			}

			Console.WriteLine("\n");
		}
	}

	class Product
	{
		private string _productName;
		public int ProductPrice { get; private set; }

		public Product(string name, int price)
		{
			_productName = name;
			ProductPrice = price;
		}

		public void ShowInfo()
		{
			Console.WriteLine($"Название продукта: {_productName}, цена - {ProductPrice}");
		}
	}
}
