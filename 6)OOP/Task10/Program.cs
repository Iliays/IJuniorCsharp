using System;
using System.Collections.Generic;

/*
 * Есть 2 взвода. 1 взвод страны один, 2 взвод страны два.
 * Каждый взвод внутри имеет солдат.
 * Нужно написать программу, которая будет моделировать бой этих взводов.
 * Каждый боец - это уникальная единица, он может иметь уникальные 
 * способности или же уникальные характеристики, такие как повышенная сила.
 * Побеждает та страна, во взводе которой остались выжившие бойцы.
 * Не важно, какой будет бой, рукопашный, стрелковый.
 */

namespace Task10
{
	class Program
	{
		static void Main(string[] args)
		{
			Battlefield battlefield = new Battlefield();
			battlefield.Battle();
		}
	}

	class Battlefield
	{
		private Random _random = new Random();
		private Platoon _platoonFirstCountry;
		private Platoon _platoonSecondCountry;
		private Soldier _firstSoldier;
		private Soldier _secondSoldier;

		public void Battle()
		{
			FillData();

			while (_platoonFirstCountry.GetCountSoldiers() > 0 && _platoonSecondCountry.GetCountSoldiers() > 0)
			{
				_firstSoldier = _platoonFirstCountry.GetSoldier();
				_secondSoldier = _platoonSecondCountry.GetSoldier();
				_platoonFirstCountry.ShowSoldiers();
				_platoonSecondCountry.ShowSoldiers();
				_firstSoldier.TakeDamage(_secondSoldier.Damage, $"Боец взвода страны {_platoonFirstCountry.CountryName}: ");
				_secondSoldier.TakeDamage(_firstSoldier.Damage, $"Боец взвода страны {_platoonSecondCountry.CountryName}: ");
				_firstSoldier.ChanceUseSkill();
				_secondSoldier.ChanceUseSkill();
				RemoveSoldier();
				Console.ReadKey();
				Console.Clear();
			}

			ShowBattleResult();
		}

		private void FillData()
		{
			_platoonFirstCountry = new Platoon((CreateNewPlatoon(10, new List<Soldier>())), "Black");
			_platoonSecondCountry = new Platoon((CreateNewPlatoon(10, new List<Soldier>())), "White");
		}

		private List<Soldier> CreateNewPlatoon(int countSoldiers, List<Soldier> soldiers)
		{
			for (int i = 0; i < countSoldiers; i++)
			{
				soldiers.Add(CreateNewSoldier());
			}

			return soldiers;
		}

		private Soldier CreateNewSoldier()
		{
			int minimumNumberClassSoldier = 0;
			int maximumNumberClassSoldier = 3;
			int newSoldier = _random.Next(minimumNumberClassSoldier, maximumNumberClassSoldier);

			if (newSoldier == 1)
			{
				return new Archer("Лучник", 100, 50, 10);
			}
			else if (newSoldier == 2)
			{
				return new Swordsman("Мечник", 100, 45, 15);
			}
			else
			{
				return new Wizard("Волшебник", 100, 40, 10);
			}
		}

		private void RemoveSoldier()
		{
			if (_firstSoldier.Health <= 0)
			{
				_platoonFirstCountry.RemoveSoldier(_firstSoldier);
			}
			if (_secondSoldier.Health <= 0)
			{
				_platoonSecondCountry.RemoveSoldier(_secondSoldier);
			}
		}

		private void ShowBattleResult()
		{
			if (_platoonFirstCountry.GetCountSoldiers() == 0 && _platoonSecondCountry.GetCountSoldiers() == 0)
			{
				Console.WriteLine("Ничья, оба взвода погибли.");
			}
			else if (_platoonFirstCountry.GetCountSoldiers() > 0)
			{
				Console.WriteLine($"Взвод страны {_platoonFirstCountry.CountryName} победил!");
			}
			else if (_platoonSecondCountry.GetCountSoldiers() > 0)
			{
				Console.WriteLine($"Взвод страны {_platoonSecondCountry.CountryName} победил!");
			}

			_platoonFirstCountry.ShowSoldiers();
			_platoonSecondCountry.ShowSoldiers();
			Console.ReadKey();
		}
	}

	class Platoon
	{
		private List<Soldier> _soldiers = new List<Soldier>();
		private Random _random = new Random();

		public string CountryName { get; private set; }
		
		public Platoon(List<Soldier> soldiers, string countryName)
		{
			_soldiers = soldiers;
			CountryName = countryName;
		}

		public void ShowSoldiers()
		{
			Console.WriteLine($"Взвод страны {CountryName}:");

			foreach (var solider in _soldiers)
			{
				Console.WriteLine($"{solider.Name}. Здоровье: {solider.Health}. Урон: {solider.Damage}.");
			}
		}

		public void RemoveSoldier(Soldier soldier)
		{
			_soldiers.Remove(soldier);
		}

		public Soldier GetSoldier()
		{
			return _soldiers[_random.Next(0, _soldiers.Count)];
		}

		public int GetCountSoldiers()
		{
			return _soldiers.Count;
		}
	}

	class Soldier
	{
		public string Name { get; protected set; }
		public int Health { get; protected set; }
		public int Damage { get; protected set; }
		public int SkillUseChance { get; protected set; }

		public Soldier(string name, int health, int damage, int skillUseChance)
		{
			Name = name;
			Health = health;
			Damage = damage;
			SkillUseChance = skillUseChance;
		}

		public void TakeDamage(int damage, string message)
		{
			Health -= damage;
			Console.WriteLine($"{message} {Name} получил {damage} урона");
		}

		public void ChanceUseSkill()
		{
			Random random = new Random();
			int maximumNumber = 100;
			int chanceUsingSkill = random.Next(maximumNumber);

			if (chanceUsingSkill < SkillUseChance)
			{
				UseSkill();
			}
		}

		protected virtual void UseSkill() { }
	}

	class Archer : Soldier
	{
		private int _damageIncrease = 20;

		public Archer(string name, int health, int damage, int skillUseChance) : base(name, health, damage, skillUseChance) { }

		protected override void UseSkill()
		{
			Console.WriteLine($"{Name} берет ядовитые стрелы.");
			Damage += _damageIncrease;
		}
	}

	class Swordsman : Soldier
	{
		private int _damageIncrease = 10;

		public Swordsman(string name, int health, int damage, int skillUseChance) : base(name, health, damage, skillUseChance) { }

		protected override void UseSkill()
		{
			Console.WriteLine($"{Name} берет второй меч в руки.");
			Damage += _damageIncrease;
		}

	}

	class Wizard : Soldier
	{
		private int _damageIncrease = 15;

		public Wizard(string name, int health, int damage, int skillUseChance) : base(name, health, damage, skillUseChance) { }

		protected override void UseSkill()
		{
			Console.WriteLine($"{Name} начинает использовать атаки по области.");
			Damage += _damageIncrease;
		}
	}
}
