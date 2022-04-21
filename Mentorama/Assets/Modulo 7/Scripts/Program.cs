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

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_weapon = null;
			//System.GC.Collect();
		}
	}
}

public abstract class ClassA
{
	public void Method1() { }

	public abstract void Method2();
}

public class ClassB : ClassA
{
	public override void Method2()
	{
		Debug.Log("Method2");
	}
}