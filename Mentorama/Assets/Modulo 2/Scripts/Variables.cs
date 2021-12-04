using UnityEngine;

public class Variables : MonoBehaviour
{
	void Start()
	{
		//int a;
		int b;
		int c;//, d, e;
			  //int a1, a2, a3;
			  //int a_1, _a2, a3_;
			  //int A, B, C;
			  //int 1a;
			  //int a1, a1;

		b = 0;
		c = -1;

		// Internal Types
		// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types
		//bool boolVariable;          // 1 byte	// false, true (0, 1)

		//boolVariable = true;

		// https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
		//int intVariable;            // 4 bytes	// -2 bi to 2 bi
		//long longVariable;          // 8 bytes	// -9 qi to 9 qi

		// https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types
		//float floatVariable;        // 4 bytes	// 7 significant digits

		//floatVariable = 0.5f;
		//floatVariable = .5f;
		//floatVariable = -.5f;

		//char charVariable;          // 2 bytes	// U+0000 a U+FFFF
		//string stringVariable;      // ????		// Up to 2 bi bytes

		//charVariable = 'a';
		//charVariable = 'ª';
		//charVariable = '\n';
		//charVariable = '\t';

		//stringVariable = "Hello World!";
		//stringVariable = "Hello\nWorld!";

		int
		r = 2;
		r = 1 + 2;
		r = b + c;
		r = b * c;
		r = b / c;
		r = b % c;
		r = -b;
		r = +b;
		r = -(-b);
		r = -r;
		r++;
		++r;
		r--;
		--r;

		int i = 3;
		Debug.Log(i);   // output: 3
		Debug.Log(i++); // output: 3
		Debug.Log(i);   // output: 4

		float f = 1.5f;
		Debug.Log(f);   // output: 1.5
		Debug.Log(++f); // output: 2.5
		Debug.Log(f);   // output: 2.5


		r += b;
		r -= b;
		r *= b;
		r /= b;
		r %= b;

		r = 2 + 2 * 2; // 6
		r = (2 + 2) * 2; // 8
		r = 20 / 10 / 2; // 1
		r = 20 / (10 / 2); // 4

		string hello = "Hello";
		string world = "World";
		string final = hello + " " + world;

		Debug.Log(final);

		//string output = 3f;
		string output = "" + 3f;
		output = 3f + 5 + "oi";
		output = "oi" + 3f + 5 + "oi";
	}
}
