using System;
using System.Collections.Generic;

/*
 * Создать хранилище книг.
 * Каждая книга имеет название, автора и год выпуска (можно добавить еще параметры). 
 * В хранилище можно добавить книгу, убрать книгу, показать все книги и показать книги по 
 * указанному параметру (по названию, по автору, по году выпуска).
 */

namespace Task05
{
	class Program
	{
		static void Main(string[] args)
		{
			Library library = new Library();
			library.Work();
		}
	}
}

class Library
{
	private List<Book> _books = new List<Book>();
	private string _inputBookName;
	private string _inputAuthorOfBook;
	private int _inputYearOfRelease;

	private void StartDataForTest()
	{
		_books.Add(new Book("Евегений Онегин", "Пушкин" , 1833));
		_books.Add(new Book("Мертвые души", "Гоголь", 1842));
		_books.Add(new Book("Над пропастью во ржи", "Сэлинджер", 1951));
		_books.Add(new Book("Мартинн Иден", "Лондон", 1909));
	}

	private void AddNewBook()
	{
		Console.WriteLine("Введите название книги:");
		_inputBookName = Console.ReadLine();
		Console.WriteLine("Введите автора книги:");
		_inputAuthorOfBook = Console.ReadLine();
		Console.WriteLine("Введите год выпуска книги:");
		_inputYearOfRelease = Convert.ToInt32(Console.ReadLine());

		_books.Add(new Book(_inputBookName, _inputAuthorOfBook, _inputYearOfRelease));
	}

	private void RemoveBook()
	{
		Console.WriteLine("Введите название книги:");
		_inputBookName = Console.ReadLine();

		for (int i = 0; i < _books.Count; i++)
		{
			if (_books[i].NameOfBook == _inputBookName)
				_books.RemoveAt(i);
		}
	}

	private void ShowAllBooks()
	{
		for (int i = 0; i < _books.Count; i++)
		{
			_books[i].ShowBookInfo();
		}

		Console.ReadKey();
	}

	private void SearchByNameOfBook()
	{
		Console.WriteLine("Введите название книги:");
		_inputBookName = Console.ReadLine();

		for (int i = 0; i < _books.Count; i++)
		{
			if (_books[i].NameOfBook.ToLower() == _inputBookName.ToLower())
			{
				_books[i].ShowBookInfo();
			}
		}

		Console.ReadKey();
	}

	private void SearchByAuthorOfBook()
	{
		Console.WriteLine("Введите автора книги:");
		_inputAuthorOfBook = Console.ReadLine();

		for (int i = 0; i < _books.Count; i++)
		{
			if (_books[i].AuthorOfBook.ToLower() == _inputAuthorOfBook.ToLower())
			{
				_books[i].ShowBookInfo();
			}
		}

		Console.ReadKey();
	}

	private void SearchYearOfRealese()
	{
		Console.WriteLine("Введите год выпуска книги:");
		_inputYearOfRelease = Convert.ToInt32(Console.ReadLine());

		for (int i = 0; i < _books.Count; i++)
		{
			if (_books[i].YearOfRelease == _inputYearOfRelease)
			{
				_books[i].ShowBookInfo();
			}
		}

		Console.ReadKey();
	}

	public void Work()
	{
		StartDataForTest();

		bool isWorking = true;

		while (isWorking)
		{
			Console.WriteLine("1) добавить книгу\n" +
				"2) убрать книгу\n" +
				"3) показать все книги\n" +
				"4) показать книгу по назвнию\n" +
				"5) показать книгу по автору\n" +
				"6) показать книгу по году выпуска\n" +
				"7) завершить работу");
			string userInput = Console.ReadLine();

			switch (userInput)
			{
				case "1":
					AddNewBook();
					break;
				case "2":
					RemoveBook();
					break;
				case "3":
					ShowAllBooks();
					break;
				case "4":
					SearchByNameOfBook();
					break;
				case "5":
					SearchByAuthorOfBook();
					break;
				case "6":
					SearchYearOfRealese();
					break;
				case "7":
					isWorking = false;
					break;
			}

			Console.Clear();
		}
	}
}

class Book
{
	public string NameOfBook { get; private set; }
	public string AuthorOfBook { get; private set; }
	public int YearOfRelease { get; private set; }

	public Book(string bookName, string bookAuthor, int bookYearRelease)
	{
		NameOfBook = bookName;
		AuthorOfBook = bookAuthor;
		YearOfRelease = bookYearRelease;
	}

	public void ShowBookInfo()
	{
		Console.WriteLine($"{NameOfBook} - {AuthorOfBook}({YearOfRelease}года.)");
	}
}
