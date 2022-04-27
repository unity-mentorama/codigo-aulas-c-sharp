using UnityEngine;

namespace Modulo3
{
	public class Functions : MonoBehaviour
	{
		void Start()
		{
			int a = 3;
			int b = 2;
			int c = 5;
			int sum = a + b + c;

			sum = Sum(a, b, c);

			Debug.Log(InBetween(3, 4, 5));


			float m = CalculateGrade(3, 4);

			if (m > 5)
			{
				Debug.Log("Aprovado");
			}
			else
			{
				Debug.Log("Reprovado");
			}
		}

		int Sum(int a, int b, int c)
		{
			return a + b + c;
		}

		void PrintHi()
		{
			Debug.Log("Hi!");
		}

		void PrintVariable(int value)
		{
			Debug.Log($"Variable: {value}");
		}

		bool IsGreaterThan(int a, int b)
		{
			if (a > b)
			{
				Debug.Log($"{a} is greated than {b}");
			}
			else
			{
				Debug.Log($"{a} is not greated than {b}");
			}

			return a > b;
		}

		float CalculateGrade(float n1, float n2)
		{
			return (n1 + n2) / 2f;
		}

		int GetGreatest(int a, int b)
		{
			//if (IsGreaterThan(a, b))
			if (a > b)
			{
				return a;
			}
			else
			{
				return b;
			}
		}

		bool InBetween(int value, int min, int max)
		{
			if (IsGreaterThan(value, min) && IsGreaterThan(max, value))
			//if ((value > min) && (value < max))
			{
				return true;
			}

			return false;

			//return (value < min) && (value > max);
		}
	}
}