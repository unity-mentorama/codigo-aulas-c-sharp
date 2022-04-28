using UnityEngine;

namespace Modulo13
{
	public class Dagger : Weapon, ISharpenable
	{
		public float CritChance { get; private set; }

		public Dagger(float critChance) : base("Dagger", 6)
		{
			CritChance = critChance;
		}

		void ISharpenable.Sharpen()
		{
			Damage++;
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
			Debug.Log("Pierce! Pierce!");

			var finalDamage = Damage;

			if (Random.Range(0f, 1f) < CritChance)
			{
				Debug.Log("Critical hit!");
				finalDamage *= 2;
			}

			return finalDamage;
		}
	}
}