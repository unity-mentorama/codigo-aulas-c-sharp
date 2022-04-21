using System.Collections.Generic;
using UnityEngine;

public class ForeachLoops : MonoBehaviour
{
	List<string> names = new List<string>(new string[] { "Lex", "Jorge", "Lucas", "Laura", "Jones", "Camila" });

	int[] values = new int[] { 4, 5, 6, 7, 8 };

	void Start()
	{
		PrintList(names);
		Debug.Log("============");
		RemoveNamesStartingWithLetter(names, 'L');
		PrintList(names); // ctrl + shift + space
		PrintList(values);
	}

	// Sobrecarga de métodos
	void PrintList(List<string> list)
	{
		foreach (string item in list)
		{
			Debug.Log(item);
		}
	}

	void PrintList(int[] array)
	{
		foreach (int item in array)
		{
			Debug.Log(item);
		}
	}

	// Explicando que não pode remover itens durante um foreach
	void RemoveNamesStartingWithLetter(List<string> list, char letter)
	{
		// Não funciona, não é permitido modificar

		foreach (string item in list)
		{
			if (item[0] == letter)
			{
				list.Add("Luara"); // Nem adicionar
				list.Remove(item); // Nem remover
			}
		}

		// Criando uma cópia da lista
		List<string> auxList = new List<string>(list);
		foreach (string item in auxList)
		{
			if (item[0] == letter)
			{
				list.Remove(item);
			}
		}

		// Usando for
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i][0] == letter)
			{
				list.Remove(list[i]);
				i--; // Sem isso fica errado
			}
		}

		// De trás para frente
		for (int i = list.Count - 1; i >= 0; i--)
		{
			if (list[i][0] == letter)
			{
				list.Remove(list[i]);
			}
		}
	}
}
