using UnityEngine;

namespace Modulo2
{
	public class IfElse : MonoBehaviour
	{
		void Start()
		{
			if (true)
			{
				Debug.Log("verdade");
			}
			else
			{
				//Debug.Log("falso");
			}

			int a = 1;
			int b = 2;
			int c = 3;
			int d = 4;

			if ((a == b) && (c < d))
			{
				Debug.Log("true");
			}
			else
			{
				Debug.Log("false");
			}

			if (a < 5)
			{
				//
			}
			else if (a < 10)
			{
				//
			}
			else
			{
				//
			}

			//if (a = 5)
		}
	}
}