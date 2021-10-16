using UnityEngine;

public class Life : MonoBehaviour
{
	[SerializeField]
	int life = 5;

	// Update is called once per frame
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
