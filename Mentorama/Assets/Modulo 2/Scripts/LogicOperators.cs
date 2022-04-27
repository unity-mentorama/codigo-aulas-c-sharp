using UnityEngine;

namespace Modulo2
{
	public class LogicOperators : MonoBehaviour
	{
		void Start()
		{
			bool test = !true;
			test = true & true;
			test = true | true;
			test = true ^ true;
			test = true && true;
			test = true || true;

			test &= false;
			test |= true;
			test ^= false;

			// !
			// &
			// ^
			// |
			// &&
			// ||


			test = true | true & false;
			test = (true | true) & false;

			test = 1 == 2;
			test = 1 != 2;

			string s1 = "hello!";
			string s2 = "HeLLo!";
			test = s1 == s2.ToLower();

			test = 1 < 2;
			test = 1 > 2;
			test = 1 <= 2;
			test = 1 >= 2;
		}
	}
}