using UnityEngine;

namespace Modulo2
{
	public class CodingStandards : MonoBehaviour
	{
		int camelCase;
		int PascalCase;
		int snake_case;
		//int kebab-case;

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
}