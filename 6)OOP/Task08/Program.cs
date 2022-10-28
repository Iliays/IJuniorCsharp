using System;
using System.Collections.Generic;

/*
 * Создать 5 бойцов, пользователь выбирает 2 бойцов и они сражаются друг с другом до смерти. 
 * У каждого бойца могут быть свои статы.
 * Каждый игрок должен иметь особую способность для атаки, которая свойственна только его классу!
 * Если можно выбрать одинаковых бойцов, то это не должна быть одна и та же ссылка на одного бойца, 
 * чтобы он не атаковал сам себя.
 */

namespace Task08
{
	class Program
	{
		static void Main(string[] args)
		{
			Arena arena = new Arena();
			arena.Battle();
		}
	}

	class Arena
	{
		private List<Warrior> _warriors = new List<Warrior>();
		private Warrior _firstWarrior;
		private Warrior _secondWarrior;

		public void Battle()
		{
			FillData();
			SelectWarriors();
			Fight();
			ShowBattleResult();
		}

		private void Fight()
		{
			while (_firstWarrior.Health > 0 && _secondWarrior.Health > 0)
			{
				_firstWarrior.ShowStats();
				_secondWarrior.ShowStats();
				_firstWarrior.Attack(_secondWarrior);
				_secondWarrior.Attack(_firstWarrior);

				Console.ReadKey();
				Console.WriteLine();
			}
		}

		private void FillData()
		{
			_warriors.Add(new Knight("Knight", 100, 15, 10));
			_warriors.Add(new Barbarian("Barbarian", 90, 20, 5));
			_warriors.Add(new DarkKnight("DarkKnight", 100, 20, 10));
			_warriors.Add(new Paladin("Paladin", 100, 25, 10));
			_warriors.Add(new Assasin("Assasin", 70, 15, 5));
		}

		private void ShowWarriors()
		{
			Console.WriteLine("Список гладиаторов");

			for (int i = 0; i < _warriors.Count; i++)
			{
				Console.Write(i + 1 + ") ");
				_warriors[i].ShowStats();
			}
		}

		private void SelectWarriors()
		{
			while (_firstWarrior == null || _secondWarrior == null)
			{
				if (_firstWarrior == null)
				{
					Console.WriteLine("Выбор первого бойца");
					_firstWarrior = ChooseWarrior();
				}
				if (_secondWarrior == null)
				{
					Console.WriteLine("Выбор второго бойца");
					_secondWarrior = ChooseWarrior();
				}

				Console.Clear();
			}
		}

		private Warrior ChooseWarrior()
		{
			ShowWarriors();
			Warrior warrior;
			Console.Write("Введите индекс бойца: ");
			bool isNumber = int.TryParse(Console.ReadLine(), out int inputIndex);

			if (isNumber)
			{
				if (inputIndex > 0 && inputIndex - 1 < _warriors.Count)
				{
					warrior = _warriors[inputIndex - 1];
					_warriors.Remove(warrior);
					Console.WriteLine("Боец успешно выбран.");
					return warrior;
				}
				else
				{
					Console.WriteLine("Боец с таким индексом не существует.");
					return null;
				}
			}
			else
			{
				Console.WriteLine("Ошибка! Вы ввели некорректные данные.");
				return null;
			}
		}

		private void ShowBattleResult()
		{
			if (_firstWarrior.Health <= 0 && _secondWarrior.Health <= 0)
			{
				Console.WriteLine("Ничья, оба бойца мертвы.");
			}
			else if (_firstWarrior.Health <= 0)
			{
				Console.WriteLine($"Победил боец - {_secondWarrior.Name}!");
			}
			else if (_secondWarrior.Health <= 0)
			{
				Console.WriteLine($"Победил боец - {_firstWarrior.Name}!");
			}

			_firstWarrior.ShowStats();
			_secondWarrior.ShowStats();
		}
	}

	class Warrior
	{
		public string Name { get; protected set; }
		public float Health { get; protected set; }
		public int Damage { get; protected set; }
		public int Armor { get; protected set; }

		private Random _random = new Random();

		public Warrior(string name, int health, int damage, int armor)
		{
			Name = name;
			Health = health;
			Damage = damage;
			Armor = armor;
		}

		public void ShowStats()
		{
			Console.WriteLine($"Имя бойца - {Name}.\nХарактеристики: {Health} здоровья, {Damage} урона, {Armor} защиты.");
		}

		public virtual void TakeDamage(int damage)
		{
			float totalDamage;
			float absorbedDamage = 20;
			int hundredPercent = 100;

			if (Armor == 0)
			{
				Health -= damage - (damage / hundredPercent * absorbedDamage);
				Console.WriteLine($"{Name} получил - {damage} урона");
			}
			else
			{
				totalDamage = damage - ((damage / hundredPercent * absorbedDamage) + Armor);

				if (totalDamage < 0)
				{
					Console.WriteLine($"{Name} получил - 0 урона");
				}
				else
				{
					Health -= totalDamage;
					Console.WriteLine($"{Name} получил - {totalDamage} урона");
				}
			}
		}

		public virtual void Attack(Warrior warriorEnemy)
		{
			int maximumNumber = 100;
			int chanceCriticalDamage = _random.Next(maximumNumber);
			int chanceCrit = 20;
			int critDamage = 10;
			int totalDamage;

			if (chanceCriticalDamage <= chanceCrit)
			{
				totalDamage = Damage + critDamage;
				warriorEnemy.TakeDamage(totalDamage);
			}
			else
			{
				warriorEnemy.TakeDamage(Damage);
			}
		}
	}

	class Knight : Warrior
	{
		private int _healthIncrese = 30;
		private Random _random = new Random();

		public Knight(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

		public override void TakeDamage(int damage)
		{
			int maximumNumber = 100;
			int chanceUseBlock = _random.Next(maximumNumber);
			int chanceBlock = 20;

			if (chanceUseBlock <= chanceBlock)
			{
				Console.WriteLine($"{Name} заблокировал весь урон щитом.");
			}
			else
			{
				base.TakeDamage(damage);
			}
		}

		public override void Attack(Warrior warriorEnemy)
		{
			int maximumNumber = 100;
			int chanceUseSkill = _random.Next(maximumNumber);
			int chanceSkill = 15;

			if(chanceUseSkill <= chanceSkill)
			{
				Console.WriteLine($"{Name} ипользовал молитву. Здоровье увелечено");
				Health += _healthIncrese;
			}
			else
			{
				base.Attack(warriorEnemy);
			}
		}
	}

	class Barbarian : Warrior
	{
		private int _damageIncrease = 15;
		private Random _random = new Random();

		public Barbarian(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

		public override void TakeDamage(int damage)
		{
			int maximumNumber = 100;
			int chanceDodgeAttack = _random.Next(maximumNumber);
			int chanceDodge = 15;

			if (chanceDodgeAttack <= chanceDodge)
			{
				Console.WriteLine($"{Name} уклонился от атаки.");
			}
			else
			{
				base.TakeDamage(damage);
			}
		}

		public override void Attack(Warrior warriorEnemy)
		{
			int maximumNumber = 100;
			int chanceUseSkill = _random.Next(maximumNumber);
			int chanceSkill = 15;

			if (chanceUseSkill <= chanceSkill)
			{
				Console.WriteLine($"{Name} ипользовал боевой клич. Урон увелечен и резво наносит две атаки.");
				Damage += _damageIncrease;
				warriorEnemy.TakeDamage(Damage);
				warriorEnemy.TakeDamage(Damage);
			}
			else
			{
				base.Attack(warriorEnemy);
			}
		}
	}

	class DarkKnight : Warrior
	{
		private int _damageIncrease = 30;
		private int _armorIncrease = 5;
		private int _healthDecrease = 10;
		private Random _random = new Random();

		public DarkKnight(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

		public override void TakeDamage(int damage)
		{
			int maximumNumber = 100;
			int chanceUseBlock = _random.Next(maximumNumber);
			int chanceBlock = 20;

			if (chanceUseBlock <= chanceBlock)
			{
				Console.WriteLine($"{Name} заблокировал весь урон щитом.");
			}
			else
			{
				base.TakeDamage(damage);
			}
		}

		public override void Attack(Warrior warriorEnemy)
		{
			int maximumNumber = 100;
			int chanceUseSkill = _random.Next(maximumNumber);
			int chanceSkill = 15;

			if (chanceUseSkill <= chanceSkill)
			{
				Armor += _armorIncrease;
				Damage += _damageIncrease;
				Health -= _healthDecrease;
				Console.WriteLine($"{Name} ипользовал силу тьмы. Урон и броня увеличины. Но теряет 10 единиц жизни.");
			}
			else
			{
				base.Attack(warriorEnemy);
			}
		}
	}

	class Paladin : Warrior
	{
		private Random _random = new Random();

		public Paladin(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

		public override void TakeDamage(int damage)
		{
			int maximumNumber = 100;
			int chanceUseBlock = _random.Next(maximumNumber);
			int chanceBlock = 30;

			if (chanceUseBlock <= chanceBlock)
			{
				Console.WriteLine($"{Name} заблокировал весь урон щитом.");
			}
			else
			{
				base.TakeDamage(damage);
			}
		}

		public override void Attack(Warrior warriorEnemy)
		{
			int maximumNumber = 100;
			int chanceUseSkill = _random.Next(maximumNumber);
			int chanceSkill = 15;
			int lightPowerDamageMultiply = 3;

			if (chanceUseSkill <= chanceSkill)
			{
				Console.WriteLine($"{Name} ипользовал силу света. Наносит урон в трехкратном размере.");
				warriorEnemy.TakeDamage(Damage * lightPowerDamageMultiply);
			}
			else
			{
				base.Attack(warriorEnemy);
			}
		}
	}

	class Assasin : Warrior
	{
		private int _damageIncrease = 20;
		private Random _random = new Random();

		public Assasin(string name, int health, int damage, int armor) : base(name, health, damage, armor) { }

		public override void TakeDamage(int damage)
		{
			int maximumNumber = 100;
			int chanceDodgeAttack = _random.Next(maximumNumber);
			int chanceDodge = 30;

			if (chanceDodgeAttack <= chanceDodge)
			{
				Console.WriteLine($"{Name} уклонился от атаки.");
			}
			else
			{
				base.TakeDamage(damage);
			}
		}

		public override void Attack(Warrior warriorEnemy)
		{
			int maximumNumber = 100;
			int chanceUseSkill = _random.Next(maximumNumber);
			int chanceSkill = 15;
			int spineDamageMultiply = 2;

			if (chanceUseSkill <= chanceSkill)
			{
				Damage += _damageIncrease;
				Console.WriteLine($"{Name} ипользовал яд на кинжалы. Урон увеличился. И моментально наносит удар в спину врага.");
				warriorEnemy.TakeDamage(Damage * spineDamageMultiply);
			}
			else
			{
				base.Attack(warriorEnemy);
			}
		}
	}
}
