using UnityEngine;

public class Sword : FinalWeapon
{
	public Sword() : base("Sword", 8) { }

	public Sword(int damage) : base("Sword", damage) { }

	public override int Swing()
	{
		Debug.Log("Slash! Slash!");
		return Damage;
	}
}