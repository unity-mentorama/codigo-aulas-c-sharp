using UnityEngine;

namespace Modulo14
{
	public class Indexers : MonoBehaviour
	{
		public void Start()
		{
			IndexableClass indexableClass = new IndexableClass();

			indexableClass[0] = 42;
			Debug.Log(indexableClass[12]);
			Debug.Log(indexableClass["Lex"]);
			Debug.Log(indexableClass[5, 6]);

			Bag<string> bag = new Bag<string>(10);

			//bag[-1] = "oi"; // Causa exception
			bag[0] = "zero";
			bag[1] = "um";
			bag[2] = "dois";
			bag[3] = "três";

			for (int i = 0; i < bag.Capacity; i++)
			{
				Debug.Log(bag[i]);
			}
		}
	}

	public class IndexableClass
	{
		public int this[int key]
		{
			get
			{
				return key;
			}

			set
			{
				Debug.Log($"key[{key}] = value {value}");
			}
		}

		public string this[string key]
		{
			get
			{
				return key;
			}
		}

		public string this[int x, int y]
		{
			get
			{
				return $"({x}, {y})";
			}
		}
	}
}