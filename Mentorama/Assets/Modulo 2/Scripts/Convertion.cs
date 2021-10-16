using System;
using System.Globalization;
using UnityEngine;

public class Convertion : MonoBehaviour
{
	void Start()
	{
		float r = 3 / 2;

		Debug.Log(r);

		char c = (char)65;

		Debug.Log(c);

		int i = Convert.ToInt32(r);

		sbyte signedByte = -2;
		byte unsignedByte = (byte)signedByte;

		Debug.Log(unsignedByte);

		//bool myBool = (bool)1;
		bool myBool = Convert.ToBoolean(0f);

		Debug.Log(myBool);

		//int a = 5 / 0;
		int z = 0;
		//int e = 5 / z;

		int a = int.MaxValue;
		int b = 3;

		Debug.Log(a + b);  // output: -2147483646
		Debug.Log(unchecked(a + b));  // output: -2147483646

		//Debug.Log(checked(a + b));  // error

		float f = 1.0f / 0.0f;
		Debug.Log(f);                    // output: Infinity
		Debug.Log(float.IsInfinity(f)); // output: True

		Debug.Log(double.MaxValue + double.MaxValue); // output: Infinity

		double g = 0.0 / 0.0;
		Debug.Log(g);                // output: NaN
		Debug.Log(double.IsNaN(g));  // output: True

		float h = .55f;
		float j = .2f;
		Debug.Log(h % j);

		//float h = .41f;
		//float j = .2f;
		//Debug.Log($"asd {h % j}");

		double d = 0.1;
		double e = 3 * d;
		Debug.Log(e == 0.3);   // output: False
		Debug.Log(e - 0.3);    // output: 5.55111512312578E-17

		// Stringy

		//string output = 3f;
		int intOutput = Convert.ToInt32("1");
		Debug.Log(intOutput);

		intOutput = int.Parse("1");
		Debug.Log(intOutput);
		// TryParse

		float floatOutput = Convert.ToSingle("133,03");
		Debug.Log(floatOutput);

		floatOutput = float.Parse("130.03", CultureInfo.InvariantCulture);
		Debug.Log(floatOutput);

		//string output = 3f;
		string output = "" + 3f;

		float originalFloat = 5.5f;
		output = originalFloat.ToString();
		output = "oi" + 3f + 5 + "oi";

		Debug.Log("Saída: " + originalFloat + ".");
		Debug.Log($"Saída: {originalFloat}.");

		Debug.Log($"Saída: {originalFloat:#.00}.");
	}
}
