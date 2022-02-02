using UnityEngine;

public class Character
{
	public string Name { get; private set; }
	public int Life { get; private set; }
	public FinalWeapon Weapon { get; private set; }

	public bool IsAlive { get => Life > 0; }

	//public Character(string name, int life)
	//{
	//	Name = name;
	//	Life = life;
	//}

	public Character(string name, int life, FinalWeapon weapon = null)
	{
		Name = name;
		Life = life;
		Weapon = weapon;
	}

	public void Attack(Character other)
	{
		if (!CheckAlive()) return;

		if (!other.IsAlive)
		{
			Debug.Log($"{other.Name} is already dead.");
			return;
		}

		if (Weapon == null) // Trocar
		{
			Debug.Log($"{Name} doesn't have a weapon.");
		}
		else
		{
			Debug.Log($"{Name} attacked {other.Name} with their {Weapon.Name}.");
			other.DealDamage(Weapon.Damage);
		}
	}

	public void SharpenWeapon()
	{
		if (!CheckAlive()) return;

		if (!HasWeapon()) return;

		//Debug.Log($"{Name} shappened their {Weapon.Name}.");
		Debug.Log($"{Name} shappened their {Weapon.Name}.");
		Weapon.Sharpen();
	}

	public void EquipWeapon(FinalWeapon weapon)
	{
		if (!CheckAlive()) return;

		if (Weapon != null)
		{
			Debug.Log($"{Name} already has a weapon equipped.");
		}
		else
		{
			Weapon = weapon;
			Debug.Log($"{Name} equipped a {Weapon.Name} (Dmg: {Weapon.Damage} - Rank: {Weapon.Rank}).");
		}
	}

	public void UnequipWeapon()
	{
		if (!CheckAlive()) return;

		if (Weapon == null) // Trocar
		{
			Debug.Log($"{Name} has no weapons equipped.");
		}
		else
		{
			Debug.Log($"{Name} has unequiped their {Weapon.Name}");
			Weapon = null;
		}
	}

	public void DealDamage(int ammount)
	{
		Life -= ammount;

		Debug.Log($"{Name} took {ammount} damage.\n" +
			$"{Name}'s current Life: {Life}");

		if (Life <= 0)
		{
			Debug.Log($"{Name} has died.");
		}
	}

	private bool CheckAlive()
	{
		if (!IsAlive)
		{
			Debug.Log($"{Name} is no more.");
		}

		return IsAlive;
	}

	private bool HasWeapon()
	{
		if (Weapon == null)
		{
			Debug.Log($"{Name} doesn't have a weapon.");
		}

		return Weapon != null;
	}
}
