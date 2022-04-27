using UnityEngine;

namespace Modulo7
{
	class Weapon
	{
		int _damage;
		char _rank;

		public

		int Attack(int enemyArmor)
		{
			Debug.Log("Attack");

			return _damage - enemyArmor;
		}

		public Weapon(int damage, char rank)
		{
			_damage = damage;
			_rank = rank;
		}

		~Weapon()
		{
			Debug.Log("Destrutor");
		}

		public static void Sharpen(Weapon weapon)
		{
			weapon._damage++;

			Debug.Log("You sharpened the weapon.");
		}

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