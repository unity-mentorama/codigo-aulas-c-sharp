using TMPro;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
	private Character _player1;
	private Character _player2;

	public TextMeshProUGUI Text;

	void Start()
	{
		FinalWeapon sword = new FinalWeapon("Sword", 8);
		_player1 = new Character("Lex", 100, sword);

		FinalWeapon dagger = new FinalWeapon("Dagger", 5);
		_player2 = new Character("Ana", 90, dagger);
	}

	// Update is called once per frame
	void Update()
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
			_player1.EquipWeapon(new FinalWeapon("Weapon", Random.Range(5, 10)));
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
			_player2.EquipWeapon(new FinalWeapon("Weapon", Random.Range(5, 10)));
		}
	}
}
