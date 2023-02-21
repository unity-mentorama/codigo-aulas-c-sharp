using UnityEditor;
using UnityEngine;

namespace Modulo19
{
	[CustomEditor(typeof(LookAtPoint))]
	[CanEditMultipleObjects]
	public class LookAtPointEditor : Editor
	{
		private SerializedProperty _lookPosition;
		private LookAtPoint _lookAtPoint;

		void OnEnable()
		{
			_lookAtPoint = target as LookAtPoint;

			_lookPosition = serializedObject.FindProperty("LookPosition");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			EditorGUILayout.PropertyField(_lookPosition);
			serializedObject.ApplyModifiedProperties();

			//_lookAtPoint.LookPosition = EditorGUILayout.Vector3Field(new GUIContent("Look Position"), _lookAtPoint.LookPosition, null);
			_lookAtPoint.Update();

			EditorGUILayout.Separator();

			if (_lookPosition.vector3Value.y > (target as LookAtPoint).transform.position.y)
			{
				EditorGUILayout.LabelField("(Above this object)");
			}

			if (_lookPosition.vector3Value.y < (target as LookAtPoint).transform.position.y)
			{
				EditorGUILayout.LabelField("(Below this object)");
			}
		}

		public void OnSceneGUI()
		{
			EditorGUI.BeginChangeCheck();
			Vector3 position = Handles.PositionHandle(_lookAtPoint.LookPosition, Quaternion.identity);
			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(target, "Move point");
				_lookAtPoint.LookPosition = position;
				_lookAtPoint.Update();
			}
		}
	}
}
