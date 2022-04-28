using UnityEngine;

namespace Modulo13
{
	public class Generics : MonoBehaviour
	{
		private void Start()
		{
			Bag<int> intBag = new Bag<int>(10);

			intBag.Add(0, 42);
			int first = intBag.First;
		}
	}

	public delegate void SimpleDelegate<T>(T n);

	//class Bag<T> where T : class
	//class Bag<T> where T : class?
	//class Bag<T> where T : struct
	//class Bag<T> where T : new()
	//class Bag<T> where T : notnull
	//class Bag<T> where T : unmanaged
	//class Bag<T> where T : MonoBehaviour
	//class Bag<T> where T : IExample
	//class Bag<T, U> where T : U
	public class Bag<T>
	{
		private T _lastAddedItem;

		private T[] _items;

		public int Capacity { get => _items.Length; }
		public T First { get => _items[0]; }
		public T Last { get => _items[_items.Length - 1]; }
		public T LastAdded { get => _lastAddedItem; }


		public event SimpleDelegate<T> OnItemAdded;

		public Bag(int capacity)
		{
			_items = new T[capacity];
		}

		public void Add(int index, T newItem)
		{
			_items[index] = newItem;
			_lastAddedItem = newItem;

			OnItemAdded?.Invoke(newItem);
		}

		public T GetItem(int index)
		{
			return _items[index];
		}

		public static T Convert<U>(U oi) where U : T
		{
			return (T)oi;
		}
	}
}