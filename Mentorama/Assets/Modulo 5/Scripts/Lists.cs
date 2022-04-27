using System.Collections.Generic;
using UnityEngine;

namespace Modulo5
{
	public class Lists : MonoBehaviour
	{
		[SerializeField]
		List<string> names = new List<string>(new string[] { "Lex", "Jorge", "Lucas", "Laura", "Jones", "Camila" });

		void Start()
		{
			List<int> intList = new List<int>();

			intList.Add(42);
			PrintList(intList);
			intList.AddRange(new int[] { 10, 11, 12 });
			PrintList(intList);
			intList.Sort();
			PrintList(intList);
			intList.Remove(42);
			PrintList(intList);
			intList.RemoveAt(0);
			PrintList(intList);
			intList.Clear();
			PrintList(intList);

			List<List<int>> intMatrix = new List<List<int>>();

			intMatrix[0][0] = 1;

			IsPalindrome("ama");
			IsPalindrome("arara");
			IsPalindrome("ararar");
			IsPalindrome("ararar2");
		}
		void PrintList(List<int> list)
		{
			string output = "";

			for (int i = 0; i < list.Count; i++)
			{
				output += $"{list[i]}, ";
			}

			Debug.Log(output);
		}

		// Strings são "listas", possível acessar index
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
}