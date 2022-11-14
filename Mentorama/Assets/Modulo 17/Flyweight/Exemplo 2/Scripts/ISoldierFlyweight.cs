using UnityEngine;

namespace Modulo17.Flyweight.Example2
{
	public enum WeaponType
	{
		Sword,
		Bow,
		Lance
	}

	public class SoldierStats
	{
		public int Attack;
		public int Defense;
		public int MaxHealth;
		public int Dexterity;
		public int Level;
	}

	// Flyweight
	public interface ISoldierFlyweight
	{
		#region Intrinsic States

		public SoldierStats Stats { get; }
		public WeaponType Weapon { get; }

		public void LevelUp();

		#endregion

		#region Extrinsic State

		public Color GetColor(int hitPoints);

		#endregion
	}
}
