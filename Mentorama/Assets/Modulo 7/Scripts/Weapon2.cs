using UnityEngine;

namespace Modulo7
{
	class Weapon2
	{
		public int a;
		private int b;
		protected int c;
		internal int d;

		protected internal int x;
		private protected int y;

		private readonly int e;
		private const float pi = 3.1415f; // Mathf.PI;
		public const string rank = "Rank A";

		//public const string[] ranks; não é permitido
		public readonly string[] ranks = new string[] { "C", "B", "A", "S" };

		public int Damage
		{
			get
			{
				return _damage;
			}

			set
			{
				_damage = value;

				if (_damage > 5)
				{
					_rank = Weapon.GetRank(_damage);
				}
			}
		}

		int AutoProperty { get; set; }

		public int AutoProperty2 { get; private set; } = 3;

		public int Property3
		{
			get => _damage;
			set => _damage = value;
		}

		int _damage;
		char _rank;

		public int Attack(int enemyArmor)
		{
			Debug.Log("Attack");

			return _damage - enemyArmor;
		}

		public Weapon2(int damage, char rank)
		{
			_damage = damage;
			_rank = rank;
		}
	}
}