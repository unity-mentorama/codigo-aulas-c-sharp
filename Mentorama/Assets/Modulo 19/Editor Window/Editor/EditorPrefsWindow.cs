using UnityEditor;
using UnityEngine;

namespace Modulo19
{
	public class EditorPrefsWindow : EditorWindow
	{
		private string _stringValueKey = "MyStringValue";
		private string _floatValueKey = "MyFloatValue";
		private string _intValueKey = "MyIntValue";

		private string _stringValue;
		private float _floatValue;
		private int _intValue;

		[MenuItem("Mentorama/EditorPrefsWindow", priority = 3)]
		public static void OpenWindow()
		{
			GetWindow(typeof(EditorPrefsWindow));
		}

		private void OnGUI()
		{
			GUILayout.Label("EditorPrefs Demonstration", EditorStyles.boldLabel);

			_stringValue = EditorGUILayout.TextField("String Value:", _stringValue);
			_floatValue = EditorGUILayout.FloatField("Float Value:", _floatValue);
			_intValue = EditorGUILayout.IntField("Int Value:", _intValue);

			if (GUILayout.Button("Save"))
			{
				SaveValues();
				Debug.Log("Values saved to EditorPrefs");
			}

			if (GUILayout.Button("Load"))
			{
				LoadValues();
				Debug.Log("Values loaded from EditorPrefs");

				// Limpa o focus para forçar os campos a atualizarem seus valores
				GUI.FocusControl("");
			}

			if (GUILayout.Button("Reset"))
			{
				ResetValues();
				Debug.Log("Values reset");

				// Limpa o focus para forçar os campos a atualizarem seus valores
				GUI.FocusControl("");
			}
		}

		private void SaveValues()
		{
			EditorPrefs.SetString(_stringValueKey, _stringValue);
			EditorPrefs.SetFloat(_floatValueKey, _floatValue);
			EditorPrefs.SetInt(_intValueKey, _intValue);
		}

		private void LoadValues()
		{
			_stringValue = EditorPrefs.GetString(_stringValueKey, "");
			_floatValue = EditorPrefs.GetFloat(_floatValueKey, 0f);
			_intValue = EditorPrefs.GetInt(_intValueKey, 0);
		}

		private void ResetValues()
		{
			_stringValue = "";
			_floatValue = 0f;
			_intValue = 0;
		}

		//private void OnFocus()
		//{
		//	LoadValues();
		//	Debug.Log("EditorWindow focused");
		//}

		//private void OnDestroy()
		//{
		//	SaveValues();
		//	Debug.Log("EditorWindow destroyed");
		//}
	}
}
