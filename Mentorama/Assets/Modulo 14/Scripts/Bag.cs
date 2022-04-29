using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modulo14
{
	public class Bag<T> : IEnumerable<T>
	{
		private T _lastItemAdded;

		private T[] _items;

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= _items.Length)
				{
					//throw new IndexOutOfRangeException();
					Debug.LogError("Index com valor inválido.");
					return default(T);
				}

				return _items[index];
			}

			set
			{
				if (index < 0 || index >= _items.Length)
				{
					//throw new IndexOutOfRangeException();
					Debug.LogError("Index com valor inválido.");
					return;
				}

				_items[index] = value;
			}
		}

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

		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)_items).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _items.GetEnumerator();
		}
	}
}