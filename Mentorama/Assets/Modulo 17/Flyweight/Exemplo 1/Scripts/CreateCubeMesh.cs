using UnityEngine;

namespace Modulo17.Flyweight.Example1
{
	public class CreateCubeMesh : MonoBehaviour
	{
		private enum Cubeside { BOTTOM, TOP, LEFT, RIGHT, FRONT, BACK };

		private static int _cubeCount = 0;

		public static GameObject CreateCube()
		{
			var cube = new GameObject();
			cube.AddComponent<MeshFilter>();
			cube.AddComponent<MeshRenderer>();
			CreateQuad(Cubeside.FRONT, cube);
			CreateQuad(Cubeside.BACK, cube);
			CreateQuad(Cubeside.TOP, cube);
			CreateQuad(Cubeside.BOTTOM, cube);
			CreateQuad(Cubeside.LEFT, cube);
			CreateQuad(Cubeside.RIGHT, cube);

			var meshFilters = cube.GetComponentsInChildren<MeshFilter>();
			var combine = new CombineInstance[meshFilters.Length];

			int i = 0;
			while (i < meshFilters.Length)
			{
				combine[i].mesh = meshFilters[i].sharedMesh;
				combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
				meshFilters[i].gameObject.SetActive(false);

				i++;
			}

			foreach (Transform T in cube.transform)
			{
				Destroy(T.gameObject);
			}

			cube.GetComponent<MeshFilter>().mesh = new Mesh();
			cube.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
			cube.GetComponent<MeshFilter>().mesh.name = $"CreatedCube_{++_cubeCount}";
			MeshRenderer rend = cube.GetComponent<MeshRenderer>();
			rend.material = new Material(Shader.Find("Standard"));
			cube.gameObject.SetActive(true);
			return cube;
		}

		private static void CreateQuad(Cubeside side, GameObject parent)
		{
			var mesh = new Mesh
			{
				name = "ScriptedMesh" + side.ToString()
			};

			var vertices = new Vector3[4];
			var normals = new Vector3[4];
			var uvs = new Vector2[4];
			int[] triangles = new int[6];

			// All possible UVs
			var uv00 = new Vector2(0f, 0f);
			var uv10 = new Vector2(1f, 0f);
			var uv01 = new Vector2(0f, 1f);
			var uv11 = new Vector2(1f, 1f);

			// All possible vertices 
			var p0 = new Vector3(-0.5f, -0.5f, 0.5f);
			var p1 = new Vector3(0.5f, -0.5f, 0.5f);
			var p2 = new Vector3(0.5f, -0.5f, -0.5f);
			var p3 = new Vector3(-0.5f, -0.5f, -0.5f);
			var p4 = new Vector3(-0.5f, 0.5f, 0.5f);
			var p5 = new Vector3(0.5f, 0.5f, 0.5f);
			var p6 = new Vector3(0.5f, 0.5f, -0.5f);
			var p7 = new Vector3(-0.5f, 0.5f, -0.5f);

			switch (side)
			{
				case Cubeside.BOTTOM:
					vertices = new Vector3[] { p0, p1, p2, p3 };
					normals = new Vector3[] {Vector3.down, Vector3.down,
											Vector3.down, Vector3.down};
					uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
					triangles = new int[] { 3, 1, 0, 3, 2, 1 };
					break;
				case Cubeside.TOP:
					vertices = new Vector3[] { p7, p6, p5, p4 };
					normals = new Vector3[] {Vector3.up, Vector3.up,
											Vector3.up, Vector3.up};
					uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
					triangles = new int[] { 3, 1, 0, 3, 2, 1 };
					break;
				case Cubeside.LEFT:
					vertices = new Vector3[] { p7, p4, p0, p3 };
					normals = new Vector3[] {Vector3.left, Vector3.left,
											Vector3.left, Vector3.left};
					uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
					triangles = new int[] { 3, 1, 0, 3, 2, 1 };
					break;
				case Cubeside.RIGHT:
					vertices = new Vector3[] { p5, p6, p2, p1 };
					normals = new Vector3[] {Vector3.right, Vector3.right,
											Vector3.right, Vector3.right};
					uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
					triangles = new int[] { 3, 1, 0, 3, 2, 1 };
					break;
				case Cubeside.FRONT:
					vertices = new Vector3[] { p4, p5, p1, p0 };
					normals = new Vector3[] {Vector3.forward, Vector3.forward,
											Vector3.forward, Vector3.forward};
					uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
					triangles = new int[] { 3, 1, 0, 3, 2, 1 };
					break;
				case Cubeside.BACK:
					vertices = new Vector3[] { p6, p7, p3, p2 };
					normals = new Vector3[] {Vector3.back, Vector3.back,
											Vector3.back, Vector3.back};
					uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
					triangles = new int[] { 3, 1, 0, 3, 2, 1 };
					break;
			}

			mesh.vertices = vertices;
			mesh.normals = normals;
			mesh.uv = uvs;
			mesh.triangles = triangles;

			mesh.RecalculateBounds();

			var quad = new GameObject("Quad");
			quad.transform.parent = parent.transform;
			MeshFilter meshFilter = quad.AddComponent<MeshFilter>();
			meshFilter.mesh = mesh;
		}
	}
}
