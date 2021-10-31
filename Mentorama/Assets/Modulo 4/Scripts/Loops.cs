using UnityEngine;

public class Loops : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		while (true)
		{
			break;
		}

		do
		{
			break;
		} while (true);

		for (; ; )
		{
			break;
		}

		PrintPrimeNumbersUntil(100000);
		//Debug.Log(Factorial(5));
	}

	int Factorial(int number)
	{
		int result = number;

		while (number > 1)
		{
			number--;
			result *= number;
		}

		return result;
	}

	void Break()
	{
		for (int i = 0; i < 10; i++)
		{
			Debug.Log($"Before 'break': {i}");
			break;
			Debug.Log($"After 'break': {i}");
		}
	}

	void Continue()
	{
		for (int i = 0; i < 10; i++)
		{
			Debug.Log($"Before 'continue': {i}");
			continue;
			Debug.Log($"After 'continue': {i}");
		}
	}

	int FindFirstDivisibleNumber(int number)
	{
		int result = 2;
		while (result <= number)
		{
			if (number % result == 0)
			{
				break;
			}
			result++;
		}
		return result;
	}

	int FindFirstOddDivisibleNumber(int number)
	{
		int result = 3;
		while (result <= number)
		{
			if (number % 2 == 0)
			{
				result++;
				continue;
			}

			if (number % result == 0)
			{
				break;
			}

			result++;
		}
		return result;
	}

	void PrintPrimeNumbersUntil(int number)
	{
		for (int i = 2; i <= number; i++)
		{
			bool isPrimeNumber = true;

			for (int n = i / 2; n >= 2; n--)
			{
				if (i % n == 0)
				{
					isPrimeNumber = false;
					continue;
				}
			}

			if (isPrimeNumber)
			{
				Debug.Log(i);
			}
		}
	}
}
