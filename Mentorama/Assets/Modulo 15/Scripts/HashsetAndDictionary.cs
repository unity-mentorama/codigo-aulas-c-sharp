using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modulo15
{
	public class HashsetAndDictionary : MonoBehaviour
	{
		private void Start()
		{
			// Não possui versão não-Generic
			HashSet<int> hashSet = new HashSet<int>();
			HashSetExample();

			// "Dictionary" de objects
			Hashtable hashtable = new Hashtable();
			HashtableExample();

			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			DictionaryExample();
		}

		private void HashSetExample()
		{
			HashSet<int> hashSet = new HashSet<int>();
			hashSet.Add(42);
			hashSet.Add('A'); // 65
			hashSet.Add(13);
			hashSet.Add(7);

			Helper.UnityLogGenericCollection(hashSet);

			Debug.Log("Adicionando o 65 novamente.");
			hashSet.Add(65);

			Helper.UnityLogGenericCollection(hashSet);

			Debug.Log("Removendo o 7.");
			hashSet.Remove(7);
			Helper.UnityLogGenericCollection(hashSet);

			Debug.Log($"O valor 42 está no set: {hashSet.Contains(42)}");

			// Operações de teoria de conjuntos

			HashSet<int> secondHashSet = new HashSet<int>();
			hashSet.Add(42);
			hashSet.Add('B'); // 66

			hashSet.UnionWith(secondHashSet);
			hashSet.ExceptWith(secondHashSet);
			hashSet.IntersectWith(secondHashSet);
			hashSet.IsSubsetOf(secondHashSet);
			hashSet.IsSupersetOf(secondHashSet);
			// E outros...
		}

		private void HashtableExample()
		{
			Hashtable hashTable = new Hashtable();

			hashTable.Add("Mercúrio", 42);
			hashTable.Add("Vênus", 'A');
			hashTable.Add("Terra", 9.75f);
			hashTable.Add("Marte", "Lex");

			Helper.UnityLogDictionary(hashTable);

			Debug.Log($"Terra: {hashTable["Terra"]}");
			Debug.Log($"Marte: {hashTable["Marte"]}");
			Debug.Log($"Lua: {hashTable["Lua"]}");

			Debug.Log("Mudando o valor de Marte.");
			hashTable["Marte"] = true;

			Helper.UnityLogDictionary(hashTable);
		}

		private void DictionaryExample()
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();

			dictionary.Add("Mercúrio", 4878);
			dictionary.Add("Vênus", 12100);
			dictionary.Add("Terra", 12756);
			dictionary.Add("Marte", 6786);
			dictionary.Add("Júpiter", 122984);
			dictionary.Add("Saturno", 120536);
			dictionary.Add("Urano", 51108);
			dictionary.Add("Netuno", 49538);

			// Os casos seguintes causam erro
			//dictionary.Add(10, 1024); // Chave deve ser string
			//dictionary.Add("Terra", 0); // Chave duplicada
			//dictionary.Add(null, 49538); // Chave não pode ser null

			Helper.UnityLogGenericCollection(dictionary);

			Debug.Log("Removendo Saturno.");

			dictionary.Remove("Saturno");
			Helper.UnityLogGenericCollection(dictionary);

			Debug.Log($"Terra: {dictionary["Terra"]}");
			Debug.Log($"Marte: {dictionary["Marte"]}");
			//Debug.Log($"Lua: {dictionary["Lua"]}"); // Chave inexistente
			dictionary["Lua"] = 3476;

			if (dictionary.TryGetValue("Lua", out var value))
			{
				Debug.Log($"Lua: {value}");
			}

			Helper.UnityLogGenericCollection(dictionary);

			Debug.Log("Mudando o valor de Terra.");
			dictionary["Terra"] = 0;

			Helper.UnityLogGenericCollection(dictionary);
		}
	}
}