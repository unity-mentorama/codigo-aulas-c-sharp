using UnityEngine;

public class Program : MonoBehaviour
{
	Weapon _weapon;

	void Start()
	{
		Weapon newWeapon = new Weapon(10, 'C');
		_weapon = newWeapon;

		Weapon.Sharpen(newWeapon);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_weapon = null;
			//System.GC.Collect();
		}
	}
}
