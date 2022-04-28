using UnityEngine;

namespace Modulo13
{
	public class GenericsExample : MonoBehaviour
	{
		private void Start()
		{
			Bag<int> intBag = new Bag<int>(10);

			intBag.Add(0, 42);
			int first = intBag.First;
		}
	}

	public class Bag<T>
	{
		private T _lastItemAdded;

		private T[] _items;

		public int Capacity { get => _items.Length; }
		public T First { get => _items[0]; }
		public T Last { get => _items[_items.Length - 1]; }
		public T LastItemAdded { get => _lastItemAdded; }

		public Bag(int capacity)
		{
			_items = new T[capacity];
		}

		public void Add(int index, T newItem)
		{
			_items[index] = newItem;
			_lastItemAdded = newItem;
		}

		public T GetItem(int index)
		{
			var item = _items[index];
			_items[index] = default(T);
			return item;
		}
	}
}