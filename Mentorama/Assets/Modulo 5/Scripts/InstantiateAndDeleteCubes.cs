using System.Collections.Generic;
using UnityEngine;

public class InstantiateAndDeleteCubes : MonoBehaviour
{
	[SerializeField]
	GameObject _cubePrefab;

	List<GameObject> _allCubes = new List<GameObject>();

	void Start()
	{
		for (int x = 0; x < 10; x++)
		{
			for (int z = 0; z < 10; z++)
			{
				int edge = 0;
				if (x == 0 || x == 9 || z == 0 || z == 9)
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
			for (int i = 0; i < _allCubes.Count; i++)
			{
				Destroy(_allCubes[i]);
			}
		}
	}
}
