using UnityEngine;

namespace Modulo4
{
	public class InstantiateCubes : MonoBehaviour
	{
		[SerializeField]
		GameObject _cubePrefab;

		void Start()
		{
			// Instanciando objetos

			//for (int x = 0; x < 10; x++)
			//{
			//	for (int z = 0; z < 10; z++)
			//	{
			//		int columnHeight = Random.Range(1, 5);

			//		for (int y = 0; y < columnHeight; y++)
			//		{
			//			Instantiate(_cubePrefab, new Vector3(x, y, z), Quaternion.identity);
			//		}
			//	}
			//}

			// Feito com while

			int x = 0;
			while (x < 10)
			{
				int z = 0;
				while (z < 10)
				{
					int y = 0;
					int columnHeight = Random.Range(1, 5);
					while (y < columnHeight)
					{
						Instantiate(_cubePrefab, new Vector3(x, y, z), Quaternion.identity);
						y++;
					}
					z++;
				}
				x++;
			}

			// Lição de casa

			//for (int x = 0; x < 10; x++)
			//{
			//	for (int z = 0; z < 10; z++)
			//	{
			//		int edge = 0;
			//		if (x == 0 || x == 9 || z == 0 || z == 9)
			//		{
			//			edge = 2;
			//		}

			//		int columnHeight = Random.Range(1, 3) + edge;

			//		for (int y = 0; y < columnHeight; y++)
			//		{
			//			Instantiate(_cubePrefab, new Vector3(x, y, z), Quaternion.identity);
			//		}
			//	}
			//}
		}
	}
}