using System;
using System.Collections.Generic;

/*
 * Существует продавец, он имеет у себя список товаров, и при нужде, может вам его показать, 
 * также продавец может продать вам товар. После продажи товар переходит к вам, и вы можете также посмотреть свои вещи.
 * Возможные классы – игрок, продавец, товар.
 * Вы можете сделать так, как вы видите это.
 */

namespace Task06
{
	class Program
	{
		static void Main(string[] args)
		{
			Seller seller = new Seller();
			seller.Work();
		}
	}

	class Seller
	{
		private List<Product> _productList = new List<Product>();
		private Player _player = new Player(100);
		private int _inputIndex;
		private int _money = 100;

		private void AddProducts()
		{
			_productList.Add(new Product("Potion HP", 10));
			_productList.Add(new Product("Potion MP", 10));
			_productList.Add(new Product("Sword", 120));
			_productList.Add(new Product("Shield", 100));
		}

		private void ShowProducts()
		{
			for (int i = 0; i < _productList.Count; i++)
			{
				_productList[i].ShowProductInfo();
			}

			Console.ReadKey();
		}

		private void SaleProduct()
		{
			Console.WriteLine("Введите номер товара для покупки:");
			_inputIndex = Convert.ToInt32(Console.ReadLine());

			if(_player.Check(_productList[_inputIndex - 1]))
			{
				_money += _productList[_inputIndex - 1].ProductPrice;
				_player.Purchase(_productList[_inputIndex - 1]);
				_productList.RemoveAt(_inputIndex - 1);
			}
			else
			{
				Console.WriteLine("Недостаточно денег");
			}

			Console.ReadKey();
		}

		public void Work()
		{
			AddProducts();
			bool isWorking = true;

			while (isWorking)
			{
				Console.WriteLine("Деньги торговца: " + _money);
				Console.WriteLine("1) показать все товары\n" +
					"2) купить товар\n" +
					"3) посмотреть инвентарь игрока\n" +
					"4) выйти");
				string userInput = Console.ReadLine();

				switch (userInput)
				{
					case "1":
						ShowProducts();
						break;
					case "2":
						SaleProduct();
						break;
					case "3":
						_player.ShowProductsInventory();
						break;
					case "4":
						isWorking = false;
						break;
				}

				Console.Clear();
			}
		}
	}

	class Player
	{
		private int _money;
		private List<Product> _inventory = new List<Product>();

		public Player(int money)
		{
			_money = money;
		}

		public bool Check(Product product)
		{
			if (_money >= product.ProductPrice)
				return true;
			else
				return false;
		}

		public void Purchase(Product product)
		{
			_money -= product.ProductPrice;
			_inventory.Add(product);
		}

		public void ShowProductsInventory()
		{
			for (int i = 0; i < _inventory.Count; i++)
			{
				_inventory[i].ShowProductInfo();
			}

			Console.WriteLine("Деньги игрока: " + _money);
			Console.ReadKey();
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

		public void ShowProductInfo()
		{
			Console.WriteLine($"{_productName} - {ProductPrice}");
		}
	}
}
