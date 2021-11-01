using System.Collections.Generic;
using UnityEngine;

public class Lists : MonoBehaviour
{
	List<string> names = new List<string>(new string[] { "Lex", "Jorge", "Lucas", "Laura", "Jones", "Camila" });

	void Start()
	{
		List<int> intList = new List<int>();

		intList.Add(42);
		intList.AddRange(new int[] { 10, 11, 12 });
		intList.Remove(42);
		intList.RemoveAt(0);
		intList.Clear();
		//intList.Sort()

		List<List<int>> intMatrix = new List<List<int>>();

		//intMatrix[0][0] = 1;

		//PrintList(names);
		//Debug.Log("============");
		//RemoveNamesStartingWithLetter(names, 'L');
		//PrintList(names);

		//IsPalindrome("ama");
		//IsPalindrome("arara");
		//IsPalindrome("ararar");
		//IsPalindrome("ararar2");
	}

	void PrintList(List<string> list)
	{
		foreach (string item in list)
		{
			Debug.Log(item);
		}
	}

	void RemoveNamesStartingWithLetter(List<string> list, char letter)
	{
		//foreach (string item in list)
		//{
		//	if (item[0] == letter)
		//	{
		//		list.Remove(item);
		//	}
		//}

		//List<string> auxList = new List<string>(list);
		//foreach (string item in auxList)
		//{
		//	if (item[0] == letter)
		//	{
		//		list.Remove(item);
		//	}
		//}

		//for (int i = 0; i < list.Count; i++)
		//{
		//	if (list[i][0] == letter)
		//	{
		//		list.Remove(list[i]);
		//		i--;
		//	}
		//}

		for (int i = list.Count - 1; i >= 0; i--)
		{
			if (list[i][0] == letter)
			{
				list.Remove(list[i]);
			}
		}
	}

	bool IsPalindrome(string word)
	{
		// [0][1][2][3][4][5]
		//        |
		// 6 / 2 = 3;
		// [0][1][2][3][4]
		//     |
		// 5 / 2 = 2;
		for (int i = 0; i < word.Length / 2; i++)
		{
			if (word[i] != word[word.Length - 1 - i])
			{
				Debug.Log($"{word} is not a palindrome.");
				return false;
			}
		}

		Debug.Log($"{word} is a palindrome.");

		return false;
	}
}
