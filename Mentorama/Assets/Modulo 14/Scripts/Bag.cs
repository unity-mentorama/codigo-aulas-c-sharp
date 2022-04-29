using System;
using System.Collections;
using System.Collections.Generic;

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
					throw new IndexOutOfRangeException();
				}

				return _items[index];
			}

			set
			{
				if (index < 0 || index >= _items.Length)
				{
					throw new IndexOutOfRangeException();
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
			for (int i = 0; i < _items.Length; i++)
			{
				yield return _items[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _items.GetEnumerator();
		}
	}
}