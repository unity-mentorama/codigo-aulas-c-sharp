using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modulo15
{
	public class ArrayListsAndLinkedList : MonoBehaviour
	{
		private void Start()
		{
			object[] objArray = new object[10];
			int[] intArray = new int[10];

			ArrayList objectList = new ArrayList();
			List<int> intList = new List<int>(10);

			ArrayListExample();

			// Não possui versão não-Generic
			LinkedList<int> linkedList = new LinkedList<int>();
			LinkedListExample();
		}

		private void ArrayListExample()
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add(42);
			arrayList.Add('A');
			arrayList.Add(9.75f);
			arrayList.Add("Lex");

			Helper.UnityLogCollection(arrayList);
		}

		private void LinkedListExample()
		{
			LinkedList<string> linkedList = new LinkedList<string>();

			linkedList.AddLast("Mercúrio");
			linkedList.AddLast("Vênus");
			linkedList.AddLast("Terra");
			linkedList.AddLast("Júpiter");
			linkedList.AddLast("Saturno");
			linkedList.AddLast("Urano");
			linkedList.AddLast("Netuno");
			linkedList.AddLast("Plutão");

			Helper.UnityLogCollection(linkedList);

			Debug.Log("Removendo planetas.");

			linkedList.Remove(linkedList.Last);
			linkedList.Remove("Saturno");
			linkedList.RemoveFirst();
			linkedList.RemoveLast();

			Helper.UnityLogCollection(linkedList);

			Debug.Log("Adicionando Marte depois da Terra.");

			LinkedListNode<string> terra = linkedList.Find("Terra");
			linkedList.AddAfter(terra, "Marte");

			Helper.UnityLogCollection(linkedList);

			Debug.Log($"Lua está na lista? {linkedList.Contains("Lua")}");

			Debug.Log($"Limpando sistema solar.");

			linkedList.Clear();
			Helper.UnityLogCollection(linkedList);
		}
	}
}
