using System.Collections.Generic;
using UnityEngine;


namespace Modulo17.ObjectPool
{
	// Client
	public class ObjectPoolClient : MonoBehaviour
	{
		public GameObject CubePrefab;
		public int FieldSize;

		private ObjectPool _objectPool;
		private readonly List<GameObject> _objectList = new List<GameObject>();

		public void Start()
		{
			_objectPool = new ObjectPool(CubePrefab, FieldSize * FieldSize);
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				InstantiateMap(true);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				ReturnAllObjectToPool();
			}
			else if (Input.GetKeyDown(KeyCode.A))
			{
				InstantiateMap(false);
			}
			else if (Input.GetKeyDown(KeyCode.S))
			{
				DeleteAllObjects();
			}

		}

		private void InstantiateMap(bool useObjectPool)
		{
			var yScale = Random.Range(1, 4);
			var noiseScale = Random.Range(0.1f, 0.3f);

			for (int x = 0; x < FieldSize; x++)
			{
				for (int z = 0; z < FieldSize; z++)
				{
					var position = new Vector3(x,
						Mathf.PerlinNoise(x * noiseScale, z * noiseScale) * yScale,
						z);

					if (useObjectPool)
					{
						GetObjectFromPool(position);
					}
					else
					{
						InstanteNewObject(position);
					}
				}
			}
		}

		private void InstanteNewObject(Vector3 position)
		{
			var newObject = Instantiate(CubePrefab, position, Quaternion.identity);
			_objectList.Add(newObject);
		}

		private void GetObjectFromPool(Vector3 position)
		{
			var pooledObject = _objectPool.NextAvailableObject(position, Quaternion.identity);
			_objectList.Add(pooledObject);
		}

		private void ReturnOneObjectToPool()
		{
			if (_objectList.Count <= 0)
			{
				return;
			}

			_objectPool.ReturnObjectToPool(_objectList[0]);
			_objectList.Remove(_objectList[0]);
		}

		private void ReturnAllObjectToPool()
		{
			foreach (GameObject gameObject in _objectList)
			{
				_objectPool.ReturnObjectToPool(gameObject);
			}

			_objectList.Clear();
		}

		private void DeleteAllObjects()
		{
			foreach (GameObject gameObject in _objectList)
			{
				Destroy(gameObject);
			}

			_objectList.Clear();
		}
	}
}