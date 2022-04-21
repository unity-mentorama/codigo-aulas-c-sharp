
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAndDeleteCubes : MonoBehaviour
{
	[SerializeField]
	GameObject _cubePrefab;

	[SerializeField]
	int mapSize;

	List<GameObject> _allCubes = new List<GameObject>();

	void Start()
	{
		for (int x = 0; x < mapSize; x++)
		{
			for (int z = 0; z < mapSize; z++)
			{
				int edge = 0;
				if (x == 0 || x == mapSize - 1 || z == 0 || z == mapSize - 1)
				{
					edge = 2;
				}

				int columnHeight = Random.Range(1, 3) + edge;

				for (int y = 0; y < columnHeight; y++)
				{
					_allCubes.Add(Instantiate(_cubePrefab, new Vector3(x, y, z), Quaternion.identity));
				}
			}
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			// Deletar todos

			for (int i = 0; i < _allCubes.Count; i++)
			{
				Destroy(_allCubes[i]);
			}

			// Deletar o último da lista
			Destroy(_allCubes[_allCubes.Count - 1]);
			_allCubes.RemoveAt(_allCubes.Count - 1);


			// Deletar o primeiro da lista
			Destroy(_allCubes[0]);
			_allCubes.RemoveAt(0);

			// Tarefa - Deletar todos com maior altura
			List<GameObject> highestCubes = new List<GameObject>();
			float highestHeight = 0f;

			for (int i = 0; i < _allCubes.Count; i++)
			{
				if (_allCubes[i].transform.position.y > highestHeight)
				{
					highestHeight = _allCubes[i].transform.position.y;
					highestCubes.Clear();
				}

				if (_allCubes[i].transform.position.y == highestHeight)
				{
					highestCubes.Add(_allCubes[i]);
				}
			}

			for (int i = 0; i < highestCubes.Count; i++)
			{
				Destroy(highestCubes[i]);
				_allCubes.Remove(highestCubes[i]);
			}
		}
	}
}