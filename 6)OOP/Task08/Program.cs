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

			while (_firstWarrior == null || _secondWarrior == null)
			{
				if (_firstWarrior == null)
				{
					Console.WriteLine("Выбор первого бойца");
					_firstWarrior = ChooseWarrior(_firstWarrior);
				}
				if (_secondWarrior == null)
				{
					Console.WriteLine("Выбор второго бойца");
					_secondWarrior = ChooseWarrior(_secondWarrior);
				}

				Console.Clear();
			}

			while (_firstWarrior.Health > 0 && _secondWarrior.Health > 0)
			{
				_firstWarrior.ShowStats();
				_secondWarrior.ShowStats();
				_firstWarrior.TakeDamage(_secondWarrior.Damage);
				_secondWarrior.TakeDamage(_firstWarrior.Damage);
				_firstWarrior.ChanceUseSkill();
				_secondWarrior.ChanceUseSkill();

				Console.ReadKey();
				Console.WriteLine();
			}

			ShowBattleResult();
		}

		private void FillData()
		{
			_warriors.Add(new Knight("Knight", 60, 10, 10, 20));
			_warriors.Add(new Barbarian("Barbarian", 70, 15, 5, 15));
			_warriors.Add(new DarkKnight("DarkKnight", 50, 15, 10, 10));
			_warriors.Add(new Paladin("Paladin", 80, 25, 10, 15));
			_warriors.Add(new Assasin("Assasin", 40, 15, 5, 20));
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

		private Warrior ChooseWarrior(Warrior warrior)
		{
			ShowWarriors();
			Console.Write("Введите индекс бойца: ");
			bool isNumber = int.TryParse(Console.ReadLine(), out int inputIndex);

			if (isNumber == false)
			{
				Console.WriteLine("Ошибка! Вы ввели некорректные данные.");
				return null;
			}
			else if (inputIndex > 0 && inputIndex - 1 < _warriors.Count)
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
		}
	}

	class Warrior
	{
		public string Name { get; protected set; }
		public float Health { get; protected set; }
		public int Damage { get; protected set; }
		public int Armor { get; protected set; }
		public int SkillUseChance { get; protected set; }

		public Warrior(string name, int health, int damage, int armor, int skillUseChance)
		{
			Name = name;
			Health = health;
			Damage = damage;
			Armor = armor;
			SkillUseChance = skillUseChance;
		}
		
		public void TakeDamage(int damage)
		{
			float totalDamage = 0;
			float absorbedDamage = 20;

			if (Armor == 0)
			{
				Health -= damage;
			}
			else
			{
				totalDamage = damage / absorbedDamage * Armor;
				Health -= totalDamage;
			}

			Console.WriteLine($"{Name} получил - {totalDamage} урона");
		}

		public void ShowStats()
		{
			Console.WriteLine($"Имя бойца - {Name}.\nХарактеристики: {Health} здоровья, {Damage} урона, {Armor} защиты.");
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

	class Knight : Warrior
	{
		private int _healthIncrese = 40;

		public Knight(string name, int health, int damage, int armor, int skillUseChance) : base(name, health, damage, armor, skillUseChance) { }

		protected override void UseSkill()
		{
			Console.WriteLine($"{Name} ипользовал молитву. Здоровье увелечено");
			Health += _healthIncrese;
		}
	}

	class Barbarian : Warrior
	{
		private int _damageIncrease = 15;

		public Barbarian(string name, int health, int damage, int armor, int skillUseChance) : base(name, health, damage, armor, skillUseChance) { }

		protected override void UseSkill()
		{
			Console.WriteLine($"{Name} ипользовал боевой клич. Урон увелечен.");
			Damage += _damageIncrease;
		}
	}

	class DarkKnight : Warrior
	{
		private int _damageIncrease = 15;
		private int _armorIncrease = 10;

		public DarkKnight(string name, int health, int damage, int armor, int skillUseChance) : base(name, health, damage, armor, skillUseChance) { }

		protected override void UseSkill()
		{
			Console.WriteLine($"{Name} ипользовал силу тьмы. Урон и броня увеличины.");
			Armor += _armorIncrease;
			Damage += _damageIncrease;
		}
	}

	class Paladin : Warrior
	{
		private int _healthIncrese = 80;
		private int _armorIncrease = 10;

		public Paladin(string name, int health, int damage, int armor, int skillUseChance) : base(name, health, damage, armor, skillUseChance) { }

		protected override void UseSkill()
		{
			Console.WriteLine($"{Name} ипользовал силу света. Здоровье и броня увеличины.");
			Health += _healthIncrese;
			Armor += _armorIncrease;
		}
	}

	class Assasin : Warrior
	{
		private int _damageIncrease = 20;

		public Assasin(string name, int health, int damage, int armor, int skillUseChance) : base(name, health, damage, armor, skillUseChance) { }

		protected override void UseSkill()
		{
			Console.WriteLine($"{Name} ипользовал яд на кинжалы. Урон увеличился.");
			Damage += _damageIncrease;
		}
	}
}
