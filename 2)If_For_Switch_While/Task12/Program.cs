using System;

namespace Task12
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Легенда: Вы – теневой маг(можете быть вообще хоть кем) и у вас в арсенале есть 
			 * несколько заклинаний, которые вы можете использовать против Босса. 
			 * Вы должны уничтожить босса и только после этого будет вам покой.
			 * Формально: перед вами босс, у которого есть определенное кол-во жизней и 
			 * определенный ответный урон. 
			 * У вас есть 4 заклинания для нанесения урона боссу. 
			 * Программа завершается только после смерти босса или смерти пользователя.
			 * Пример заклинаний
			 * Рашамон – призывает теневого духа для нанесения атаки (Отнимает 100 хп игроку)
			 * Хуганзакура (Может быть выполнен только после призыва теневого духа), наносит 100 ед. урона
			 * Межпространственный разлом – позволяет скрыться в разломе и восстановить 250 хп. 
			 * Урон босса по вам не проходит
			 * Заклинания должны иметь схожий характер и быть достаточно сложными, 
			 * они должны иметь какие-то условия выполнения (пример - Хуганзакура). 
			 * Босс должен иметь возможность убить пользователя.
			 */

			float bossHealth = 400;
			float heroHealth = 100;
			float heroHealthMaximum = heroHealth;
			string userInputSelector;
			int bossReverseDamageInPercent = 20;
			bool secondGearActivated = false;
			int damageFromSecondGearToHeroInPercent = 20;
			float skillSpeedGunDamage = 50;
			float skillGatlingDamage = 100;
			int skillHealInPercent = 20;
			int skillHealCountUse = 2;
			int oneHundredPercent = 100;

			while (bossHealth > 0 && heroHealth > 0)
			{
				Console.WriteLine($"Здоровье босса: {bossHealth}\nВаше здоровье: {heroHealth}");

				Console.WriteLine($"Выберите заклинание:\n1 - Второй гир - увеличивает вашу скорость (Отнимает {damageFromSecondGearToHeroInPercent}% хп игроку)\n" +
					$"2 - Скоростной пистолет - быстрая и сильная атака рукой (Может быть выполнено только во время второго гира), наносит {skillSpeedGunDamage} урона\n" +
					$"3 - Гатлинг - серия быстрых ударов, наносит {skillGatlingDamage} урона\n" +
					$"4 - Съесть мясо - восстанавливает здоровье на {skillHealInPercent}% от максимального (Использолвать можно только {skillHealCountUse} раза)");
				userInputSelector = Console.ReadLine();

				switch (userInputSelector)
				{
					case "1":
						secondGearActivated = true;
						heroHealth -= heroHealth / oneHundredPercent * damageFromSecondGearToHeroInPercent;
						break;
					case "2":
						if (secondGearActivated)
						{
							bossHealth -= skillSpeedGunDamage;
							heroHealth -= skillSpeedGunDamage / oneHundredPercent * bossReverseDamageInPercent;
						}
						break;
					case "3":
						bossHealth -= skillGatlingDamage;
						heroHealth -= skillGatlingDamage / oneHundredPercent * bossReverseDamageInPercent;
						break;
					case "4":
						if (heroHealthMaximum > heroHealth && skillHealCountUse > 0)
						{
							heroHealth += heroHealthMaximum / oneHundredPercent * skillHealInPercent;
							skillHealCountUse--;
						}
						else
						{
							Console.WriteLine("Вы съели всё мясо, больше нельзя востановить здоровье.");
						}
						break;
				}
			}

			if (heroHealth > 0)
			{
				Console.WriteLine("Вы победили босса подземелья, поздравляю!!!");
			}
			else if (heroHealth <= 0 && bossHealth <= 0)
			{
				Console.WriteLine("Ничья, вы останетесь неизвестным никому героем!");
			}
			else
			{
				Console.WriteLine("К сожелению вы проиграли и теперь миру конец)");
			}
		}
	}
}
