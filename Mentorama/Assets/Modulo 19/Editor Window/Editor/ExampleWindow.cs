using UnityEditor;
using UnityEngine;

namespace Modulo19
{
	public class ExampleWindow : EditorWindow
	{
		private string _myString = "Hello World";
		private string _myPassword = "1234";
		private bool _groupEnabled;
		private bool _myBool = true;
		private float _myFloat = 1.23f;

		private GameObject _gameObject;
		private Editor _gameObjectEditor;

		[MenuItem("Mentorama/Example Window", priority = 2)]
		private static void OpenWindow()
		{
			GetWindow<ExampleWindow>(false, "Example Window", false);
		}

		private void OnGUI()
		{
			GUILayout.Label("Base Settings", EditorStyles.boldLabel);

			_myString = EditorGUILayout.TextField("Text Field", _myString);

			// Grupo ativa/desativa.
			_groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", _groupEnabled);

			// Grupo horizontal.
			EditorGUILayout.BeginHorizontal();
			_myBool = EditorGUILayout.Toggle("Toggle", _myBool);
			_myFloat = EditorGUILayout.Slider("Slider", _myFloat, -3, 3);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.EndToggleGroup();

			// Ainda é possível utilizar EditorGUI se quiser, mas é preciso configurar o Rect manualmente
			_myPassword = EditorGUI.PasswordField(
				new Rect(3, 79, EditorGUIUtility.currentViewWidth - 6, EditorGUIUtility.singleLineHeight),
				"Password",
				_myPassword);
			// E se quiser usar EditorGUILayout em seguida vai precisar adicionar um espaço manualmente
			EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);

			//_myPassword = EditorGUILayout.PasswordField(_myPassword);

			if (GUILayout.Button("Do it"))
			{
				Debug.Log("Do it!");
			}

			EditorGUI.BeginChangeCheck();

			_gameObject = (GameObject)EditorGUILayout.ObjectField(_gameObject, typeof(GameObject), true);

			if (EditorGUI.EndChangeCheck())
			{
				//_gameObjectEditor = Editor.CreateEditor(_gameObject, null);
				Editor.CreateCachedEditor(_gameObject, null, ref _gameObjectEditor);
			}

			if (_gameObjectEditor != null)
			{
				_gameObjectEditor.OnPreviewGUI(GUILayoutUtility.GetRect(300, 300), EditorStyles.whiteLabel);
				//_gameObjectEditor.OnInteractivePreviewGUI(GUILayoutUtility.GetRect(300, 300), EditorStyles.whiteLabel);

				//GUIStyle bgColor = new GUIStyle();
				//bgColor.normal.background = EditorGUIUtility.whiteTexture;
				//_gameObjectEditor.OnPreviewGUI(GUILayoutUtility.GetRect(300, 300), bgColor);
			}
		}
	}
}
