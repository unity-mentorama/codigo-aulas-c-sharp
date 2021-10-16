using UnityEngine;

public class CodingStandards : MonoBehaviour
{
	int camelCase;
	int PascalCase;
	int snake_case;
	//int kebab-case;

	// Start is called before the first frame update
	void Start()
	{
		int a = 0;

		if (a == 0)
		{
			a++;
			Debug.Log(a);
		}
		else
		{
			a--;
			Debug.Log(a);
		}

		Debug.Log(a);

		if (a == 0) a++;

		if (a == 0)
			a++;
		Debug.Log(a);
	}
}
