using UnityEditor;
using UnityEngine;

namespace Modulo19
{
	public class DoUndoEditor : EditorWindow
	{
		private Vector3 _cubePosition;
		private GameObject _cube;

		[MenuItem("Mentorama/Do Undo", priority = 4)]
		private static void OpenWindow()
		{
			GetWindow<DoUndoEditor>().Show();
		}

		private void OnGUI()
		{
			EditorGUILayout.LabelField("Custom Editor Tools", EditorStyles.boldLabel);
			_cubePosition = EditorGUILayout.Vector3Field("Cube Position", _cubePosition);

			if (GUILayout.Button("Create Cube"))
			{
				CreateCube();
			}

			if (GUILayout.Button("Move Cube"))
			{
				MoveCube();
			}

			if (GUILayout.Button("Add Rigidbody Component"))
			{
				AddRigidbodyComponent();
			}

			if (GUILayout.Button("Destroy Cube"))
			{
				DestroyCube();
			}
		}

		private void CreateCube()
		{
			_cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			_cube.transform.position = _cubePosition;
			Undo.RegisterCreatedObjectUndo(_cube, "Create Cube");
		}

		private void MoveCube()
		{
			if (_cube != null)
			{
				Undo.RecordObject(_cube.transform, "Move Cube");
				_cube.transform.position = _cubePosition;
			}
		}

		private void AddRigidbodyComponent()
		{
			if (_cube != null)
			{
				Undo.AddComponent<Rigidbody>(_cube);
			}
		}

		private void DestroyCube()
		{
			if (_cube != null)
			{
				Undo.DestroyObjectImmediate(_cube);
			}
		}
	}
}
