using System.Collections.Generic;

namespace Modulo17.Flyweight.Example2
{
	// FlyweightFactory
	static class SoldierFlyweightFactory
	{
		private static readonly Dictionary<WeaponType, ISoldierFlyweight> _soldiers = new Dictionary<WeaponType, ISoldierFlyweight>();

		public static ISoldierFlyweight Soldier(WeaponType weaponType)
		{
			if (!_soldiers.ContainsKey(weaponType))
			{
				switch (weaponType)
				{
					case WeaponType.Sword:
						_soldiers.Add(weaponType, new Knight());
						break;
					case WeaponType.Bow:
						_soldiers.Add(weaponType, new Archer());
						break;
					case WeaponType.Lance:
					default:
						_soldiers.Add(weaponType, new Calvary());
						break;
				}
			}

			return _soldiers[weaponType];
		}
	}
}
