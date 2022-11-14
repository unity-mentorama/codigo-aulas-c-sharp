using System;
using UnityEngine;

namespace Modulo17.Flyweight.Example2
{
	// ConcreteFlyweight
	public class Archer : ISoldierFlyweight
	{
		public WeaponType Weapon => WeaponType.Bow;
		public SoldierStats Stats { get; private set; }

		public Archer()
		{
			Stats = new SoldierStats()
			{
				Attack = 15,
				Defense = 4,
				MaxHealth = 20,
				Dexterity = 20,
				Level = 1
			};
		}

		public void LevelUp()
		{
			Stats.Level++;
			Stats.Attack += Stats.Level;
			Stats.Dexterity = (int)Math.Round(1.25f * Stats.Dexterity);
			Stats.MaxHealth += Stats.Level;
			Stats.Defense++;
		}

		public Color GetColor(int hitPoints)
		{
			if (hitPoints <= Stats.MaxHealth / 2)
			{
				return Color.red;
			}
			else
			{
				return Color.green;
			}
		}
	}

	// ConcreteFlyweight
	public class Knight : ISoldierFlyweight
	{
		public WeaponType Weapon => WeaponType.Sword;
		public SoldierStats Stats { get; private set; }

		public Knight()
		{
			Stats = new SoldierStats()
			{
				Attack = 25,
				Defense = 20,
				MaxHealth = 30,
				Dexterity = 5,
				Level = 1
			};
		}

		public void LevelUp()
		{
			Stats.Level++;
			Stats.Attack += (int)Math.Round(1.25f * Stats.Attack);
			Stats.Dexterity += Stats.Level / 2;
			Stats.MaxHealth += Stats.Level;
			Stats.Defense++;
		}

		public Color GetColor(int hitPoints)
		{
			if (hitPoints <= Stats.MaxHealth / 2)
			{
				return Color.magenta;
			}
			else
			{
				return Color.gray;
			}
		}
	}

	// ConcreteFlyweight
	public class Calvary : ISoldierFlyweight
	{
		public WeaponType Weapon => WeaponType.Lance;
		public SoldierStats Stats { get; private set; }

		public Calvary()
		{
			Stats = new SoldierStats()
			{
				Attack = 30,
				Defense = 20,
				MaxHealth = 25,
				Dexterity = 10,
				Level = 1
			};
		}

		public void LevelUp()
		{
			Stats.Level++;
			Stats.Attack += Stats.Level / 2;
			Stats.Dexterity += Stats.Level / 2;
			Stats.MaxHealth += Stats.Level / 2;
			Stats.Defense++;
		}

		public Color GetColor(int hitPoints)
		{
			if (hitPoints <= Stats.MaxHealth / 2)
			{
				return Color.yellow;
			}
			else
			{
				return Color.black;
			}
		}
	}
}
