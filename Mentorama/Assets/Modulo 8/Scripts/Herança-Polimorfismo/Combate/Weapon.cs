using UnityEngine;

namespace Modulo8
{
	public abstract class Weapon
	{
		public string Name { get; private set; }
		public char Rank { get; private set; }
		public int Damage { get; protected set; }

		public Weapon(string name, int damage)
		{
			Name = name;
			Damage = damage;
			Rank = Weapon.GetRank(damage);
		}

		public virtual void Sharpen()
		{
			Damage++;
			Debug.Log($"{Name} sharpened! Damage increased to {Damage}.");

			var newRank = Weapon.GetRank(Damage);
			if (newRank != Rank)
			{
				Rank = newRank;

				Debug.Log($"{Name}'s rank increased to {Rank}!");
			}
		}

		public abstract int Swing();

		public static char GetRank(int damage)
		{
			if (damage >= 10)
			{
				return 'S';
			}
			else if (damage >= 7)
			{
				return 'A';
			}
			else if (damage >= 4)
			{
				return 'B';
			}

			return 'C';
		}
	}
}