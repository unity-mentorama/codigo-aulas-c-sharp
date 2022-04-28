using UnityEngine;

namespace Modulo13
{
	public class Sword : Weapon, ISharpenable
	{
		public Sword() : base("Sword", 8) { }

		public Sword(int damage) : base("Sword", damage) { }

		void ISharpenable.Sharpen()
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

		public override int Swing()
		{
			Debug.Log("Slash! Slash!");
			return Damage;
		}
	}
}