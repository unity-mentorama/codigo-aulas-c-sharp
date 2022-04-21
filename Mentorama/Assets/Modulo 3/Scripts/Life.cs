using UnityEngine;

public class Life : MonoBehaviour
{
	[SerializeField]
	int life = 5;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			AddLife(1);
		}
	}

	void AddLife(int value)
	{
		life += value;
	}
}
