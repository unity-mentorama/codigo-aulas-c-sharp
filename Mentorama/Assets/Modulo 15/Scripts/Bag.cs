using System;
using System.Collections;
using System.Collections.Generic;

namespace Modulo15
{
	public class Bag<T> : ICollection, IEnumerable<T> where T : Item
	{
		private T _lastItemAdded;

		private T[] _items;

		private int _count;

		public int TotalCapacity { get => _items.Length; }

		public int RemainingCapacity { get => _items.Length - _count; }

		public T LastItemAdded { get => _lastItemAdded; }

		public int Count => _count;

		public bool IsSynchronized => _items.IsSynchronized;

		public object SyncRoot => _items.SyncRoot;

		public Bag(int totalCapacity)
		{
			_items = new T[totalCapacity];
			_count = 0;
		}

		public void Put(int index, T newItem)
		{
			// Não pode colocar null na Bag.
			// Não pode ter um item no lugar.

			_items[index] = newItem;
			_lastItemAdded = newItem;
			_count++;
		}

		public T Take(int index)
		{
			// Tem que existir um item no lugar.
			// Index tem que ser válido.

			var item = _items[index];
			_items[index] = default(T);
			_count--;
			return item;
		}

		public T Take(T item)
		{
			// O item tem que estar na bag.

			// Tirar o item da bag.
			_count--;
			return item;
		}

		public bool CheckIfInside(T item)
		{
			// return false;
			return true;
		}

		public T Peek(int index)
		{
			return _items[index];
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < _items.Length; i++)
			{
				if (_items[i] != null)
				{
					yield return _items[i];
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _items.GetEnumerator();
		}

		public void CopyTo(Array array, int index)
		{
			_items.CopyTo(array, index);
		}
	}

	public abstract class Item
	{
		float Value { get; }
	}
}