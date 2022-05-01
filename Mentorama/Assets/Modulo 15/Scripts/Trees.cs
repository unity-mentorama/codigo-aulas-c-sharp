using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modulo15
{
	public class Trees : MonoBehaviour
	{
		private void Start()
		{
			// HashSet
			// Implementado como uma Tree por baixo dos panos
			SortedSet<int> sortedSet = new SortedSet<int>();
			SortedSetExample();

			// Hashtable
			SortedList objToObjSortedDictionary = new SortedList();

			// Dictionary + List
			// Usa menos memória que o SortedDictionary
			// Mais rápido em recuperar os dados após ordenado
			SortedList<int, string> sortedList = new SortedList<int, string>();
			SortedListExample();

			// Dictionary
			// Implementado como uma Tree por baixo dos panos
			// Mais rápido em inserir e remover pares de chave-valor
			SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
			SortedDictionaryExample();
		}

		private void SortedSetExample()
		{
			SortedSet<int> sortedSet = new SortedSet<int>();

			sortedSet.Add(42);
			sortedSet.Add('A'); //65
			sortedSet.Add(13);
			sortedSet.Add(7);

			Helper.UnityLogGenericCollection(sortedSet);

			Debug.Log("Adicionando o 65 novamente.");
			sortedSet.Add(65);

			Helper.UnityLogGenericCollection(sortedSet);

			Debug.Log("Removendo o 7.");
			sortedSet.Remove(7);
			Helper.UnityLogGenericCollection(sortedSet);

			Debug.Log($"O valor 42 está no set: {sortedSet.Contains(42)}");
		}

		private void SortedListExample()
		{
			// Ordenado pela Key
			SortedList<int, string> sortedList =
				new SortedList<int, string>()
				{
					{3, "Três"},
					{5, "Cinco"},
					{1, "Um"}
				};

			Helper.UnityLogGenericCollection(sortedList);

			Debug.Log("Adicionando mais itens.");
			sortedList.Add(2, "Dois");
			sortedList.Add(4, null);
			sortedList.Add(10, "Dez");

			Helper.UnityLogGenericCollection(sortedList);

			Debug.Log("Removendo alguns itens.");
			sortedList.Remove(1);
			sortedList.Remove(10);

			sortedList.RemoveAt(0);
			//sortedList.RemoveAt(10); // ArgumentOutOfRangeException

			Helper.UnityLogGenericCollection(sortedList);
		}

		private void SortedDictionaryExample()
		{
			// Ordenado pela Key
			SortedDictionary<int, string> sortedDictionary =
				new SortedDictionary<int, string>()
				{
					{3, "Três"},
					{5, "Cinco"},
					{1, "Um"}
				};

			Helper.UnityLogGenericCollection(sortedDictionary);

			Debug.Log("Adicionando mais itens.");
			sortedDictionary.Add(2, "Dois");
			sortedDictionary.Add(4, null);
			sortedDictionary.Add(10, "Dez");

			Helper.UnityLogGenericCollection(sortedDictionary);

			Debug.Log("Removendo alguns itens.");
			sortedDictionary.Remove(1);
			sortedDictionary.Remove(10);

			//sortedDictionary.RemoveAt(0); // Dictionary não tem RemoveAt

			Helper.UnityLogGenericCollection(sortedDictionary);
		}
	}
}