using UnityEditor;
using UnityEngine;

namespace Modulo19
{
	public class CustomEditorTools : EditorWindow
	{
		[MenuItem("Tools/Do Something", priority = 1)]
		private static void DoSomething()
		{
			Debug.Log("Performed custom action!");
		}

		[MenuItem("Mentorama/Custom Editor Tools", priority = 1)]
		private static void OpenWindow()
		{
			// Algumas implementações mais antigas fazem assim:
			//CustomEditorTools window = (CustomEditorTools)EditorWindow.GetWindow(typeof(CustomEditorTools));
			//window.Show();

			// Mas pode ser simplificado assim:
			GetWindow<CustomEditorTools>();
		}

		private void OnGUI()
		{
			EditorGUILayout.LabelField("Custom Editor Tools", EditorStyles.boldLabel);

			if (GUILayout.Button("Do Something"))
			{
				DoSomething();
			}
		}

		[MenuItem("Assets/Do Something", false, 1)]
		private static void DoSomethingWithSelectedAsset()
		{
			Debug.Log("Performou ação no objeto selecionado: " + Selection.activeObject.name);
		}

		[MenuItem("Assets/Do Something", true)]
		private static bool ValidateDoSomething()
		{
			//Debug.Log("Performed validation");
			return Selection.activeObject != null;
		}
	}
}
