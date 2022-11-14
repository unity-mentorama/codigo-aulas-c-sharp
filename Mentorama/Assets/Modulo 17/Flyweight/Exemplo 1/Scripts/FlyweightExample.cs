using System.Collections.Generic;
using UnityEngine;


namespace Modulo17.Flyweight.Example1
{
	public class FlyweightExample : MonoBehaviour
	{
		public GameObject CubePrefab;
		public int FieldSize;

		private readonly List<GameObject> _objectList = new List<GameObject>();

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				InstantiateMap(false);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				InstantiateMap(true);
			}
			else if (Input.GetKeyDown(KeyCode.Delete))
			{
				DeleteAllObjects();
			}
		}

		private void InstantiateMap(bool usePrefab)
		{
			for (int x = 0; x < FieldSize; x++)
			{
				for (int z = 0; z < FieldSize; z++)
				{
					var position = new Vector3(x,
						Mathf.PerlinNoise(x * 0.2f, z * 0.2f) * 3,
						z);

					if (usePrefab)
					{
						InstanteWithPrefab(position);
					}
					else
					{
						InstantiateWithCreateCube(position);
					}
				}
			}
		}

		private void InstantiateWithCreateCube(Vector3 position)
		{
			var cube = CreateCubeMesh.CreateCube();
			cube.transform.position = position;
			_objectList.Add(cube);
		}

		private void InstanteWithPrefab(Vector3 position)
		{
			var newObject = Instantiate(CubePrefab, position, Quaternion.identity);
			_objectList.Add(newObject);
		}

		private void DeleteAllObjects()
		{
			foreach (GameObject gameObject in _objectList)
			{
				Destroy(gameObject);
			}

			_objectList.Clear();

			// Unload manually created meshes from memory
			Resources.UnloadUnusedAssets();
		}
	}
}