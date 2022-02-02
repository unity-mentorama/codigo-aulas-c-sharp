using UnityEngine;

public class ForLoop : MonoBehaviour
{
	[SerializeField]
	int _input;

	void Start()
	{
		//for ( /*init*/ ; /*condition*/ ; /*step*/ )
		//{
		//	//
		//}

		for (int i = 0; i < 10; i++)
		{
			if (i % 2 == 0)
			{
				continue;
			}

			Debug.Log(i);
		}

		int a;

		for (a = 2; a > 0; a--)
		{

		}

		//Debug.Log(Factorial(_input));
		//Debug.Log(FactorialCrescente(_input));

		//FizzBuzz();
		//FizzBuzz2();
	}


	int Factorial(int number)
	{
		int result = number;

		for (int i = number - 1; i > 1; i--)
		{
			result *= i;
		}

		return result;
	}

	int FactorialCrescente(int number)
	{
		int result = number;

		for (int i = 2; i < number; i++)
		{
			result *= i;
		}

		return result;
	}

	void FizzBuzz()
	{
		for (int i = 1; i <= 100; i++)
		{
			if (i % 3 == 0 && i % 5 == 0)
			{
				Debug.Log("FizzBuzz");
			}
			else if (i % 3 == 0)
			{
				Debug.Log("Fizz");
			}
			else if (i % 5 == 0)
			{
				Debug.Log("Buzz");
			}
			else
			{
				Debug.Log(i);
			}
		}
	}

	void FizzBuzz2()
	{
		for (int i = 1; i <= 100; i++)
		{
			string output = "";
			if (i % 3 == 0)
			{
				output += "Fizz";
			}
			if (i % 5 == 0)
			{
				output += "Buzz";
			}
			if (output.Length == 0)
			{
				output = i.ToString();
			}
			Debug.Log(output);

		}
	}
}
