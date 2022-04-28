using UnityEngine;

namespace Modulo13
{
	public class Generics : MonoBehaviour
	{
		private void Start()
		{
			DataStore<string> strStore = new DataStore<string>();
			strStore.Data = "Hello World!";
			//strStore.Data = 123; // Erro de compilação

			DataStore<int> intStore = new DataStore<int>();
			intStore.Data = 100;
			//intStore.Data = "Hello World!"; // Erro de compilação

			KeyValuePair<int, string> kvp1 = new KeyValuePair<int, string>();
			kvp1.Key = 100;
			kvp1.Value = "Cem";

			KeyValuePair<string, string> kvp2 = new KeyValuePair<string, string>();
			kvp2.Key = "Lex";
			kvp2.Value = "Alexandre Melotti";
		}

		public static T Convert<T>(object obj)
		{
			return (T)obj;
		}
	}

	//class DataStore<T> where T : class
	//class DataStore<T> where T : class?
	//class DataStore<T> where T : struct
	//class DataStore<T> where T : new()
	//class DataStore<T> where T : notnull
	//class DataStore<T> where T : unmanaged
	//class DataStore<T> where T : MonoBehaviour
	//class DataStore<T> where T : IExample
	class DataStore<T>
	{
		public T Data { get; set; }
	}

	//class KeyValuePair<TKey, TValue> where TKey : TValue
	class KeyValuePair<TKey, TValue>
	{
		public TKey Key { get; set; }
		public TValue Value { get; set; }
	}

	public delegate void SimpleDelegate<T>(T n);
}