using UnityEngine;

namespace Modulo8
{
	public class PlayerCombat : MonoBehaviour
	{
		private Character _player1;
		private Character _player2;

		void Start()
		{
			Weapon sword = new Sword();
			_player1 = new Character("Lex", 100, sword);

			Weapon dagger = new Dagger(0.1f);
			_player2 = new Character("Ana", 90, dagger);
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				_player1.Attack(_player2);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				_player1.SharpenWeapon();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				_player1.UnequipWeapon();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				_player1.EquipWeapon(GetRandomWeapon());
			}

			if (Input.GetKeyDown(KeyCode.Q))
			{
				_player2.Attack(_player1);
			}
			else if (Input.GetKeyDown(KeyCode.W))
			{
				_player2.SharpenWeapon();
			}
			else if (Input.GetKeyDown(KeyCode.E))
			{
				_player2.UnequipWeapon();
			}
			else if (Input.GetKeyDown(KeyCode.R))
			{
				_player2.EquipWeapon(GetRandomWeapon());
			}
		}

		private Weapon GetRandomWeapon()
		{
			var randomWeapon = Random.Range(0, 2);

			switch (randomWeapon)
			{
				default:
				case 0:
					return new Sword();

				case 1:
					return new Dagger(0.1f);
			}
		}
	}
}