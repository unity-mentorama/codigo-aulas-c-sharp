using UnityEngine;

public class WhileLoop : MonoBehaviour
{
	[SerializeField]
	int _input;

	// Start is called before the first frame update
	void Start()
	{
		// Estrutura do while
		//while (true)
		//{
		//	//
		//}

		int i = 0;
		while (i < 10)
		{
			Debug.Log(i);
			i++;
		}


		//// Voltar para slides e explicar estrutura do do-while
		//do
		//{
		//	//
		//}
		//while (true);

		i = 0;
		do
		{
			Debug.Log(i);
			i++;
		}
		while (i < 10);

		Debug.Log(DoWhileFactorial2(_input));
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

	// number = 1 -> erro
	int DoWhileFactorial(int number)
	{
		int result = number;

		do
		{
			number--;
			result *= number;
		}
		while (number > 1);

		return result;
	}

	// Corrigir fazendo crescente
	int DoWhileFactorial2(int number)
	{
		int result = 1;
		int iterator = 0;

		do
		{
			iterator++;
			result *= iterator;
		}
		while (iterator < number);

		return result;
	}
}
