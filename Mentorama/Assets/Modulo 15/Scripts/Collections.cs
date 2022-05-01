using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modulo15
{
	public class Collections : MonoBehaviour
	{
		private void Start()
		{
			MyCollection collection = new MyCollection();

			MyGenericCollection<int> genericCollection = new MyGenericCollection<int>();
		}

		private class MyCollection : ICollection
		{
			public int Count => throw new NotImplementedException();

			public bool IsSynchronized => throw new NotImplementedException();

			public object SyncRoot => throw new NotImplementedException();

			public void CopyTo(Array array, int index)
			{
				throw new NotImplementedException();
			}

			public IEnumerator GetEnumerator() // Duck Typing
			{
				throw new NotImplementedException();
			}
		}

		private class MyGenericCollection<T> : ICollection<T>
		{
			public int Count => throw new NotImplementedException();

			public bool IsReadOnly => throw new NotImplementedException();

			public void Add(T item)
			{
				throw new NotImplementedException();
			}

			public void Clear()
			{
				throw new NotImplementedException();
			}

			public bool Contains(T item)
			{
				throw new NotImplementedException();
			}

			public void CopyTo(T[] array, int arrayIndex)
			{
				throw new NotImplementedException();
			}

			public IEnumerator<T> GetEnumerator()
			{
				throw new NotImplementedException();
			}

			public bool Remove(T item)
			{
				throw new NotImplementedException();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				throw new NotImplementedException();
			}
		}
	}
}
