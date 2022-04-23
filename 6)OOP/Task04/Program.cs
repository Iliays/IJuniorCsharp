using System;
using System.Collections.Generic;

/*
 * Есть колода с картами. Игрок достает карты, пока не решит, что ему хватит карт 
 * (может быть как выбор пользователя, так и количество сколько карт надо взять). 
 * После выводиться вся информация о вытянутых картах.
 * Возможные классы: Карта, Колода, Игрок.
 */

namespace Task04
{
	class Program
	{
		static void Main(string[] args)
		{
			Player player = new Player();
			player.Play();
		}
	}

	class Player
	{
		private List<Card> _cardsList = new List<Card>();
		private Deck deck = new Deck();

		public void Play()
		{
			deck.CollectionDeck();

			bool isPlaying = true;

			while (isPlaying)
			{
				Console.Write("1) взять карту\n" +
				"2) достаточно карт\n" +
				"Выберите действие: ");
				string userInput = Console.ReadLine();

				switch (userInput)
				{
					case "1":
						TakeCard();
						break;
					case "2":
						isPlaying = false;
						break;
				}

				Console.Clear();
			}

			ShowCards();
		}

		private void TakeCard()
		{
			if (deck.CheckDeckIsEmpty())
			{
				_cardsList.Add(deck.RemoveCard());
			}
			else
			{
				Console.WriteLine("Недостаточно карт");
				Console.ReadKey();
			}
		}

		private void ShowCards()
		{
			for (int i = 0; i < _cardsList.Count; i++)
			{
				_cardsList[i].ShowCardInfo();
			}

			Console.ReadKey();
		}
	}

	class Deck
	{
		private Queue<Card> _cardsQueue = new Queue<Card>();

		public void CollectionDeck()
		{
			_cardsQueue.Enqueue(new Card(SuitCard.Clubs, RankCard.Ace));
			_cardsQueue.Enqueue(new Card(SuitCard.Clubs, RankCard.King));
			_cardsQueue.Enqueue(new Card(SuitCard.Clubs, RankCard.Queen));
			_cardsQueue.Enqueue(new Card(SuitCard.Clubs, RankCard.Jack));
			_cardsQueue.Enqueue(new Card(SuitCard.Clubs, RankCard.Ten));
			_cardsQueue.Enqueue(new Card(SuitCard.Clubs, RankCard.Nine));
			_cardsQueue.Enqueue(new Card(SuitCard.Clubs, RankCard.Eight));
			_cardsQueue.Enqueue(new Card(SuitCard.Clubs, RankCard.Seven));
			_cardsQueue.Enqueue(new Card(SuitCard.Clubs, RankCard.Six));
			_cardsQueue.Enqueue(new Card(SuitCard.Clubs, RankCard.Five));
			_cardsQueue.Enqueue(new Card(SuitCard.Clubs, RankCard.Four));
			_cardsQueue.Enqueue(new Card(SuitCard.Clubs, RankCard.Three));
			_cardsQueue.Enqueue(new Card(SuitCard.Clubs, RankCard.Two));
			_cardsQueue.Enqueue(new Card(SuitCard.Diamonds, RankCard.Ace));
			_cardsQueue.Enqueue(new Card(SuitCard.Diamonds, RankCard.King));
			_cardsQueue.Enqueue(new Card(SuitCard.Diamonds, RankCard.Queen));
			_cardsQueue.Enqueue(new Card(SuitCard.Diamonds, RankCard.Jack));
			_cardsQueue.Enqueue(new Card(SuitCard.Diamonds, RankCard.Ten));
			_cardsQueue.Enqueue(new Card(SuitCard.Diamonds, RankCard.Nine));
			_cardsQueue.Enqueue(new Card(SuitCard.Diamonds, RankCard.Eight));
			_cardsQueue.Enqueue(new Card(SuitCard.Diamonds, RankCard.Seven));
			_cardsQueue.Enqueue(new Card(SuitCard.Diamonds, RankCard.Six));
			_cardsQueue.Enqueue(new Card(SuitCard.Diamonds, RankCard.Five));
			_cardsQueue.Enqueue(new Card(SuitCard.Diamonds, RankCard.Four));
			_cardsQueue.Enqueue(new Card(SuitCard.Diamonds, RankCard.Three));
			_cardsQueue.Enqueue(new Card(SuitCard.Diamonds, RankCard.Two));
			_cardsQueue.Enqueue(new Card(SuitCard.Hearts, RankCard.Ace));
			_cardsQueue.Enqueue(new Card(SuitCard.Hearts, RankCard.King));
			_cardsQueue.Enqueue(new Card(SuitCard.Hearts, RankCard.Queen));
			_cardsQueue.Enqueue(new Card(SuitCard.Hearts, RankCard.Jack));
			_cardsQueue.Enqueue(new Card(SuitCard.Hearts, RankCard.Ten));
			_cardsQueue.Enqueue(new Card(SuitCard.Hearts, RankCard.Nine));
			_cardsQueue.Enqueue(new Card(SuitCard.Hearts, RankCard.Eight));
			_cardsQueue.Enqueue(new Card(SuitCard.Hearts, RankCard.Seven));
			_cardsQueue.Enqueue(new Card(SuitCard.Hearts, RankCard.Six));
			_cardsQueue.Enqueue(new Card(SuitCard.Hearts, RankCard.Five));
			_cardsQueue.Enqueue(new Card(SuitCard.Hearts, RankCard.Four));
			_cardsQueue.Enqueue(new Card(SuitCard.Hearts, RankCard.Three));
			_cardsQueue.Enqueue(new Card(SuitCard.Hearts, RankCard.Two));
			_cardsQueue.Enqueue(new Card(SuitCard.Spades, RankCard.Ace));
			_cardsQueue.Enqueue(new Card(SuitCard.Spades, RankCard.King));
			_cardsQueue.Enqueue(new Card(SuitCard.Spades, RankCard.Queen));
			_cardsQueue.Enqueue(new Card(SuitCard.Spades, RankCard.Jack));
			_cardsQueue.Enqueue(new Card(SuitCard.Spades, RankCard.Ten));
			_cardsQueue.Enqueue(new Card(SuitCard.Spades, RankCard.Nine));
			_cardsQueue.Enqueue(new Card(SuitCard.Spades, RankCard.Eight));
			_cardsQueue.Enqueue(new Card(SuitCard.Spades, RankCard.Seven));
			_cardsQueue.Enqueue(new Card(SuitCard.Spades, RankCard.Six));
			_cardsQueue.Enqueue(new Card(SuitCard.Spades, RankCard.Five));
			_cardsQueue.Enqueue(new Card(SuitCard.Spades, RankCard.Four));
			_cardsQueue.Enqueue(new Card(SuitCard.Spades, RankCard.Three));
			_cardsQueue.Enqueue(new Card(SuitCard.Spades, RankCard.Two));
		}

		public bool CheckDeckIsEmpty()
		{
			if (_cardsQueue.Count > 0)
				return true;
			else
				return false;
		}

		public Card RemoveCard()
		{
			return _cardsQueue.Dequeue();
		}
	}

	class Card
	{
		private SuitCard _suitCard;
		private RankCard _rankCard;

		public Card(SuitCard suitCard, RankCard rankCard)
		{
			_suitCard = suitCard;
			_rankCard = rankCard;
		}

		public void ShowCardInfo()
		{
			Console.WriteLine($"Карта - {_rankCard} {_suitCard}");
		}
	}

	enum SuitCard
	{
		Spades,
		Clubs,
		Hearts,
		Diamonds
	}

	enum RankCard
	{
		Ace,
		Two,
		Three,
		Four,
		Five,
		Six,
		Seven,
		Eight,
		Nine,
		Ten,
		Jack,
		Queen,
		King
	}
}
