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
			Store store = new Store();
			store.Work();
		}
	}

	class Store
	{
		private Seller _seller = new Seller(100);
		private Player _player = new Player(100);

		private int GetNumber(string message)
		{
			int number;
			string inputUser;

			do
			{
				Console.Write(message);
				inputUser = Console.ReadLine();
			}
			while (int.TryParse(inputUser, out number) == false);

			return number;
		}

		public void SaleProduct()
		{
			int _inputIndex = GetNumber("Введите номер товара для покупки:") - 1;

			if (_player.CheckEnoughMoney(_seller.GetProductByIndex(_inputIndex)))
			{
				_player.Purchase(_seller.GetProductByIndex(_inputIndex));
				_seller.Sale(_seller.GetProductByIndex(_inputIndex));
			}
			else
			{
				Console.WriteLine("Недостаточно денег");
			}

			Console.ReadKey();
		}

		public void Work()
		{
			_seller.AddProducts();
			bool isWorking = true;

			while (isWorking)
			{

				Console.WriteLine("1) показать все товары\n" +
					"2) купить товар\n" +
					"3) посмотреть инвентарь игрока\n" +
					"4) выйти");
				string userInput = Console.ReadLine();

				switch (userInput)
				{
					case "1":
						_seller.ShowProducts();
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

	class Seller
	{
		private List<Product> _productList = new List<Product>();
		private int _money;

		public Seller(int money)
		{
			_money = money;
		}

		public void AddProducts()
		{
			_productList.Add(new Product("Potion HP", 10));
			_productList.Add(new Product("Potion MP", 10));
			_productList.Add(new Product("Sword", 120));
			_productList.Add(new Product("Shield", 100));
		}

		public Product GetProductByIndex(int index)
		{
			return _productList[index];
		}

		public void Sale(Product product)
		{
			_money += product.ProductPrice;
			_productList.Remove(product);
		}

		public void ShowProducts()
		{
			for (int i = 0; i < _productList.Count; i++)
			{
				_productList[i].ShowProductInfo();
			}

			Console.WriteLine("\nДеньги торговца: " + _money);

			Console.ReadKey();
		}
	}

	class Player
	{
		private List<Product> _inventory = new List<Product>();
		private int _money;

		public Player(int money)
		{
			_money = money;
		}

		public bool CheckEnoughMoney(Product product)
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
