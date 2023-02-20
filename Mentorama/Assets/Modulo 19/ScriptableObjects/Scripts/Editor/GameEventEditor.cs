using UnityEditor;
using UnityEngine;

namespace Modulo19
{
	[CustomEditor(typeof(GameEvent))]
	public class GameEventEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			var gameEvent = (GameEvent)target;

			if (GUILayout.Button("Raise Event"))
			{
				gameEvent.Raise();
			}
		}
	}
}
