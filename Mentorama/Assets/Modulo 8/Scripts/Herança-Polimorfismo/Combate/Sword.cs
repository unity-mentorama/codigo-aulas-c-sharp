using UnityEngine;

namespace Modulo8
{
	public class Sword : Weapon
	{
		public Sword() : base("Sword", 8) { }

		public Sword(int damage) : base("Sword", damage) { }

		public override int Swing()
		{
			Debug.Log("Slash! Slash!");
			return Damage;
		}
	}
}