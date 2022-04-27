using UnityEngine;

namespace Modulo4
{
	public class BreakContinue : MonoBehaviour
	{
		void Start()
		{
			Break();
			Continue();
		}

		void Break()
		{
			for (int i = 0; i < 10;)// i++)
			{
				Debug.Log($"Before 'break': {i}");
				break;
				//Debug.Log($"After 'break': {i}");
			}
		}

		void Continue()
		{
			for (int i = 0; i < 10; i++)
			{
				Debug.Log($"Before 'continue': {i}");
				continue;
				//Debug.Log($"After 'continue': {i}");
			}
		}

		// Exemplo pr�tico break
		int FindFirstDivisibleNumber(int number)
		{
			int result = 2;
			while (result <= number)
			{
				if (number % result == 0)
				{
					break; // Pode colocar return aqui tmb
				}
				result++;
			}
			return result;
		}

		// Exemplo pr�tico continue (n�o precisa)
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
					break; // Return funcionaria tamb�m
				}

				result++;
			}
			return result;
		}

		// Exemplo pr�tico for + continue
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
}