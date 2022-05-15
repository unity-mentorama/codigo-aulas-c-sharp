using System;
using System.Collections;
using System.Collections.Generic;

namespace Modulo15
{
	public class Inventory<T> : ICollection, IEnumerable<T> where T : Item
	{
		private T[] _bagSlots;

		private List<T> _itemsAddedInSequence;

		private int _count;

		public T this[int index]
		{
			get
			{
				return Peek(index);
			}

			set
			{
				Put(value, index);
			}
		}

		public int TotalCapacity { get => _bagSlots.Length; }

		public int RemainingCapacity { get => _bagSlots.Length - _count; }

		public T LastItemAdded
		{
			get
			{
				if (_itemsAddedInSequence.Count == 0)
				{
					return null;
				}

				return _itemsAddedInSequence[_itemsAddedInSequence.Count - 1];
			}
		}

		public int Count => _count;

		public bool IsSynchronized => _bagSlots.IsSynchronized;

		public object SyncRoot => _bagSlots.SyncRoot;

		public Inventory(int totalCapacity)
		{
			_bagSlots = new T[totalCapacity];
			_itemsAddedInSequence = new List<T>();
			_count = 0;
		}

		public void Put(T newItem, int index)
		{
			// Não pode colocar null na Bag.
			if (newItem == null)
			{
				throw new ArgumentNullException("Can't put 'null' item in the bag.");
			}

			// Index tem que ser válido.
			if (index < 0 || index >= _bagSlots.Length)
			{
				throw new IndexOutOfRangeException();
			}

			// Não pode ter um item no lugar.
			if (_bagSlots[index] != null)
			{
				throw new Exception($"There's alredy an item at position {index}");
			}

			AddItemAtIndex(index, newItem);
		}

		public bool Put(T newItem)
		{
			// Não pode colocar null na Bag.
			if (newItem == null)
			{
				throw new ArgumentNullException("Can't put 'null' item in the bag.");
			}

			// Não pode estar cheia.
			if (RemainingCapacity <= 0)
			{
				return false;
			}

			// Encontra o primeiro index vazio e coloca o item nele.
			for (int i = 0; i < _bagSlots.Length; i++)
			{
				if (_bagSlots[i] == null)
				{
					AddItemAtIndex(i, newItem);
					return true;
				}
			}

			return false;
		}

		public T Take(int index)
		{
			// Index tem que ser válido.
			if (index < 0 || index >= _bagSlots.Length)
			{
				throw new IndexOutOfRangeException();
			}

			// Tem que existir um item no lugar.
			if (_bagSlots[index] == null)
			{
				throw new Exception($"There's no item at position {index}");
			}

			TakeItemAtIndex(index, out var item);
			return item;
		}

		public bool TryTake(ItemType itemType, out T item)
		{
			for (int i = 0; i < _bagSlots.Length; i++)
			{
				if (_bagSlots[i] != null && _bagSlots[i].ItemType == itemType)
				{
					TakeItemAtIndex(i, out item);
					return true;
				}
			}

			item = null;
			return false;
		}

		public void Swap(int index1, int index2)
		{
			var auxItem = _bagSlots[index1];
			_bagSlots[index1] = _bagSlots[index2];
			_bagSlots[index2] = auxItem;
		}

		public bool Contains(T item)
		{
			foreach (var bagItem in _bagSlots)
			{
				if (bagItem.Equals(item))
				{
					return true;
				}
			}

			return false;
		}

		public bool Contains(ItemType itemType)
		{
			foreach (var bagItem in _bagSlots)
			{
				if (bagItem != null && bagItem.ItemType == itemType)
				{
					return true;
				}
			}

			return false;
		}

		public T Peek(int index)
		{
			return _bagSlots[index];
		}

		public void Clear()
		{
			for (int i = 0; i < _bagSlots.Length; i++)
			{
				_bagSlots[i] = null;
			}

			_itemsAddedInSequence.Clear();

			_count = 0;
		}

		public IEnumerator<T> GetEnumerator()
		{
			// Itera somente sobre os itens que existem na bag, pulando slots vazios.
			foreach (var bagItem in _bagSlots)
			{
				if (bagItem != null)
				{
					yield return bagItem;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			// Podemos usar o GetEnumerator generic como valor de retorno deste GetEnumerator.
			return GetEnumerator();
		}

		public void CopyTo(Array array, int index)
		{
			_bagSlots.CopyTo(array, index);
		}

		private void AddItemAtIndex(int index, T item)
		{
			_bagSlots[index] = item;
			_itemsAddedInSequence.Add(item);
			_count++;
		}

		private void TakeItemAtIndex(int index, out T item)
		{
			item = _bagSlots[index];
			_bagSlots[index] = null;

			for (int i = _itemsAddedInSequence.Count - 1; i >= 0; i--)
			{
				if (_itemsAddedInSequence[i].Equals(item))
				{
					_itemsAddedInSequence.Remove(item);
				}
			}

			_count--;
		}
	}
}