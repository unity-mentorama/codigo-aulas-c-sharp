using UnityEngine;

public class FinalWeapon
{
	public string Name { get; private set; }
	public char Rank { get; private set; }
	public int Damage { get; private set; }

	public FinalWeapon(string name, int damage)
	{
		Name = name;
		Damage = damage;
		Rank = Weapon.GetRank(damage);
	}

	public void Sharpen()
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
}
