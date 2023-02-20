using UnityEditor;
using UnityEngine;

namespace Modulo19
{
	//[CustomEditor(typeof(Transform))]
	public class TransformEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			// Pega o componentte Transform alvo.
			Transform transform = (Transform)target;

			// Desenha os campos de position, rotation e scale.
			GUI.color = Color.red;
			transform.position = EditorGUILayout.Vector3Field("Position", transform.position);
			GUI.color = Color.green;
			transform.rotation = Quaternion.Euler(EditorGUILayout.Vector3Field("Rotation", transform.rotation.eulerAngles));
			GUI.color = Color.blue;
			transform.localScale = EditorGUILayout.Vector3Field("Scale", transform.localScale);
		}
	}
}
