using System.Collections.Generic;
using UnityEngine;

namespace Modulo17.ObjectPool
{
	// ObjectPool
	public class ObjectPool
	{
		private readonly Stack<GameObject> _pool;
		private readonly GameObject _gameObjectPrefab;

		public ObjectPool(GameObject prefab, int initialPoolSize = 10)
		{
			_gameObjectPrefab = prefab;
			_pool = new Stack<GameObject>();

			for (int i = 0; i < initialPoolSize; i++)
			{
				AddObjectToPool(NewObjectInstance());
			}
		}

		public GameObject NextAvailableObject(Vector3 position, Quaternion rotation)
		{
			GameObject gameObject;

			if (_pool.Count > 0)
			{
				gameObject = _pool.Pop();
				gameObject.SetActive(true);
			}
			else
			{
				gameObject = NewObjectInstance();
			}

			gameObject.transform.position = position;
			gameObject.transform.rotation = rotation;

			return gameObject;

		}

		public void ReturnObjectToPool(GameObject gameObject)
		{
			AddObjectToPool(gameObject);
		}

		private GameObject NewObjectInstance()
		{
			return GameObject.Instantiate(_gameObjectPrefab);
		}

		private void AddObjectToPool(GameObject newInstance)
		{
			newInstance.SetActive(false);
			_pool.Push(newInstance);
		}
	}
}
