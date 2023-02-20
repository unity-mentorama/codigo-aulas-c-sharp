using UnityEditor;
using UnityEngine;

namespace Modulo19
{
	//[CustomEditor(typeof(Light))]
	public class LightEditor : Editor
	{
		private void OnSceneGUI()
		{
			//DrawDefaultInspector();

			// Pega o componentte Light alvo.
			Light light = (Light)target;

			if (light.type == LightType.Point)
			{
				// Desenha um circulo na Scene para representar o alcance da luz.
				Handles.color = Color.white;
				Handles.DrawWireDisc(light.transform.position, Vector3.up, light.range);
			}
		}
	}
}
