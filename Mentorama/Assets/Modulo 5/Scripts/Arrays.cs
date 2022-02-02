using UnityEngine;

public class Arrays : MonoBehaviour
{
	[SerializeField]
	string[] Names = new string[] { "Lex", "Jorge", "Lucas", "Laura", "Jones", "Camila" };

	void Start()
	{
		// Forma básica e inicialização
		int[] intArray = new int[5];
		int[] initializedIntArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

		// Arrays multidimensionais
		int[,] intMatrix = new int[3, 3];
		int[,] initializedIntMatrix = new int[,] { { 1, 2, 3 }, { 1, 2, 3 } };

		// Tamanho do array
		int lengh = intArray.Length;

		// Acesso aos elementos
		intArray[0] = 1;
		intArray[intArray.Length - 1] = 3;
		intMatrix[0, 0] = 1;

		PrintList(initializedIntArray);
		Debug.Log("============");
		Shuffle(initializedIntArray);
		PrintList(initializedIntArray);
	}

	// Arrays combinam bem com o for
	void PrintList(int[] list)
	{
		for (int i = 0; i < list.Length; i++)
		{
			Debug.Log(list[i]);
		}
	}

	int FindGreatest(int[] values)
	{
		int greatestValue = int.MinValue;

		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] > greatestValue)
			{
				greatestValue = values[i];
			}
		}

		return greatestValue;
	}

	void Shuffle(int[] numberArray)
	{
		for (int i = 0; i < numberArray.Length - 2; i++)
		{
			int shuffleIndex = Random.Range(i, numberArray.Length);

			if (shuffleIndex == i) continue;

			Swap(numberArray, i, shuffleIndex);
		}

		// Shuffle indo de trás pra frente

		for (int i = numberArray.Length - 1; i > 0; i--)
		{
			int shuffleIndex = Random.Range(0, i + 1);

			if (shuffleIndex == i) continue;

			Swap(numberArray, i, shuffleIndex);
		}
	}

	void Swap(int[] numberArray, int index1, int index2)
	{
		int aux = numberArray[index1];
		numberArray[index1] = numberArray[index2];
		numberArray[index2] = aux;
	}
}
