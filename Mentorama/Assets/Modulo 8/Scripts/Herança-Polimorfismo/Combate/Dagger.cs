using UnityEngine;

namespace Modulo8
{
	public class Dagger : Weapon
	{
		public float CritChance { get; private set; }

		public Dagger(float critChance) : base("Dagger", 6)
		{
			CritChance = critChance;
		}

		public override void Sharpen()
		{
			Damage++;
			base.Sharpen();
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