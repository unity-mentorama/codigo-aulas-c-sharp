using UnityEngine;

public class Recursive : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		int fact = RecursiveFactorial(4);
		Debug.Log(fact);

		RecursiveCall(0);
	}

	void RecursiveCall(int count)
	{
		Debug.Log($"Count: {++count}");
		RecursiveCall(count);
	}

	int RecursiveFactorial(int number)
	{
		if (number == 0)
		{
			return 1;
		}

		int nMinus1Factorial = RecursiveFactorial(number - 1);

		return number * nMinus1Factorial;
	}
}
