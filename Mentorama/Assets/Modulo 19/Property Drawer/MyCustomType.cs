using System.Reflection;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Modulo19
{
	[System.Serializable]
	public class MyCustomType
	{
		public bool Toggle;
		public string TextField;
		public float FloatField;
		public int IntField;
		public int IntSelectableField;
		public Vector2 Vector2Field;
		public Vector3 Vector3Field;
		public Vector4 Vector4Field;
		public Bounds BoundsField;
		public Rect RectField;
		public AnimationCurve CurveField;
		public MyEnum EnumField;
		public LayerMask MaskField;
		public Color ColorField;
		public Gradient GradientField;
		public Object ObjectField;
	}

	public enum MyEnum
	{
		One,
		Two,
		Three
	}

#if UNITY_EDITOR
	//[CustomPropertyDrawer(typeof(MyCustomType))]
	public class MyCustomTypeDrawer : PropertyDrawer
	{
		private readonly float _lineHeight = EditorGUIUtility.singleLineHeight;
		private readonly GUIContent[] _guiContentArray =
			new GUIContent[]
			{
			new GUIContent("a1"),
			new GUIContent("b2"),
			new GUIContent("c3"),
			new GUIContent("d4"),
			new GUIContent("e5")
			};

		private int _elementLineCount;
		private bool _foldoutLevel1 = false;
		private bool _foldoutLevel2 = false;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			// Obtenndo os valores atuais das sub-propriedades da propriedade
			bool toggleValue = property.FindPropertyRelative("Toggle").boolValue;
			string textValue = property.FindPropertyRelative("TextField").stringValue;
			float floatValue = property.FindPropertyRelative("FloatField").floatValue;
			int intValue = property.FindPropertyRelative("IntField").intValue;
			int intSelectableField = property.FindPropertyRelative("IntSelectableField").intValue;
			Vector2 vector2Value = property.FindPropertyRelative("Vector2Field").vector2Value;
			Vector3 vector3Value = property.FindPropertyRelative("Vector3Field").vector3Value;
			Vector4 vector4Value = property.FindPropertyRelative("Vector4Field").vector4Value;
			Bounds boundsValue = property.FindPropertyRelative("BoundsField").boundsValue;
			Rect rectValue = property.FindPropertyRelative("RectField").rectValue;
			AnimationCurve curveValue = property.FindPropertyRelative("CurveField").animationCurveValue;
			MyEnum enumValue = (MyEnum)property.FindPropertyRelative("EnumField").enumValueIndex;
			LayerMask maskValue = property.FindPropertyRelative("MaskField").intValue;
			Color colorValue = property.FindPropertyRelative("ColorField").colorValue;
			Gradient gradientValue = GetGradient(property.FindPropertyRelative("GradientField"));
			Object objectValue = property.FindPropertyRelative("ObjectField").objectReferenceValue;

			// Variável de controle para o "número de linhas" que estamos consumindo
			_elementLineCount = 0;

			// Desenhando os controles

			// Labels
			EditorGUI.DropShadowLabel(GetNextRectPosition(position, ref _elementLineCount), "Drop Shadow Label");
			EditorGUI.LabelField(GetNextRectPosition(position, ref _elementLineCount), "Simple Label");
			EditorGUI.SelectableLabel(GetNextRectPosition(position, ref _elementLineCount), "Selectable Label");

			// Toggles
			toggleValue = EditorGUI.Toggle(GetNextRectPosition(position, ref _elementLineCount), toggleValue);
			toggleValue = EditorGUI.ToggleLeft(GetNextRectPosition(position, ref _elementLineCount), new GUIContent("Enable"), toggleValue);

			// Disable Groups utilizando os toggles
			EditorGUI.BeginDisabledGroup(!toggleValue);

			// Texto e Password
			textValue = EditorGUI.TextField(GetNextRectPosition(position, ref _elementLineCount), textValue);
			textValue = EditorGUI.PasswordField(GetNextRectPosition(position, ref _elementLineCount), textValue);

			// HelpBox
			if (string.IsNullOrEmpty(textValue))
			{
				EditorGUI.HelpBox(GetNextRectPosition(position, ref _elementLineCount), "Text field is empty", MessageType.Error);
			}
			else
			{
				EditorGUI.HelpBox(GetNextRectPosition(position, ref _elementLineCount), textValue, MessageType.Warning);
			}

			EditorGUI.EndDisabledGroup();

			// Numéricos
			floatValue = EditorGUI.Slider(GetNextRectPosition(position, ref _elementLineCount), floatValue, 0f, 100f);
			EditorGUI.ProgressBar(GetNextRectPosition(position, ref _elementLineCount), floatValue / 100f, "Progress Bar");
			intValue = EditorGUI.IntField(GetNextRectPosition(position, ref _elementLineCount), intValue);
			intSelectableField = EditorGUI.Popup(GetNextRectPosition(position, ref _elementLineCount), intSelectableField, _guiContentArray);
			vector2Value = EditorGUI.Vector2Field(GetNextRectPosition(position, ref _elementLineCount), "", vector2Value);
			vector3Value = EditorGUI.Vector3Field(GetNextRectPosition(position, ref _elementLineCount), "", vector3Value);
			vector4Value = EditorGUI.Vector4Field(GetNextRectPosition(position, ref _elementLineCount), "", vector4Value);
			boundsValue = EditorGUI.BoundsField(GetNextRectPosition(position, ref _elementLineCount, 2), boundsValue);
			rectValue = EditorGUI.RectField(GetNextRectPosition(position, ref _elementLineCount, 2), rectValue);
			curveValue = EditorGUI.CurveField(GetNextRectPosition(position, ref _elementLineCount), curveValue);

			// Enums e Masks
			enumValue = (MyEnum)EditorGUI.EnumPopup(GetNextRectPosition(position, ref _elementLineCount), enumValue);
			maskValue = EditorGUI.MaskField(GetNextRectPosition(position, ref _elementLineCount), "", maskValue, InternalEditorUtility.layers);

			// Cores
			colorValue = EditorGUI.ColorField(GetNextRectPosition(position, ref _elementLineCount), colorValue);
			gradientValue = EditorGUI.GradientField(GetNextRectPosition(position, ref _elementLineCount), gradientValue);

			// Objects
			objectValue = EditorGUI.ObjectField(GetNextRectPosition(position, ref _elementLineCount), objectValue, typeof(Texture2D), false);

			// Textures
			// Aqui vamos dar uma manupulada para reutilizar os rects e desenhar 3 Textures na mesma "linha"
			// Isso é feito reutilizando o textureRect mas cada vez movendo o x inicial mais para a direita
			var textureRect = GetNextRectPosition(position, ref _elementLineCount, 3);

			// Se uma Texture2D válida foi selecionada
			if (objectValue is Texture2D selectedTexture)
			{
				textureRect.width = textureRect.height;
				EditorGUI.DrawPreviewTexture(textureRect, selectedTexture);

				textureRect.x += textureRect.width + 23;
				EditorGUI.DrawTextureAlpha(textureRect, selectedTexture);
			}
			else
			{
				EditorGUI.HelpBox(textureRect, "No texture found", MessageType.Info);
			}

			// Fouldouts
			_foldoutLevel1 = EditorGUI.BeginFoldoutHeaderGroup(GetNextRectPosition(position, ref _elementLineCount), _foldoutLevel1, "Foldout header group");
			if (_foldoutLevel1)
			{
				// Brincando um pouco com a indentação
				EditorGUI.indentLevel++;

				// Utilizando um objeto selecionado
				if (Selection.activeTransform)
				{
					Selection.activeTransform.position =
						EditorGUI.Vector3Field(GetNextRectPosition(position, ref _elementLineCount), "Position", Selection.activeTransform.position);

					// Foldout interno
					_foldoutLevel2 = EditorGUI.Foldout(GetNextRectPosition(position, ref _elementLineCount), _foldoutLevel2, "Foldout");
					if (_foldoutLevel2)
					{
						EditorGUI.indentLevel++;
						Selection.activeTransform.eulerAngles =
							EditorGUI.Vector3Field(GetNextRectPosition(position, ref _elementLineCount), "Rotation", Selection.activeTransform.eulerAngles);
						EditorGUI.indentLevel--;
					}
				}
				else
				{
					EditorGUI.HelpBox(GetNextRectPosition(position, ref _elementLineCount), "Select a GameObject", MessageType.Error);
				}

				EditorGUI.indentLevel--;
			}

			// End the Foldout Header that we began above.
			EditorGUI.EndFoldoutHeaderGroup();

			// Configurando de volta os valores das sub-propriedades da propriedade
			property.FindPropertyRelative("Toggle").boolValue = toggleValue;
			property.FindPropertyRelative("TextField").stringValue = textValue;
			property.FindPropertyRelative("FloatField").floatValue = floatValue;
			property.FindPropertyRelative("IntField").intValue = intValue;
			property.FindPropertyRelative("IntSelectableField").intValue = intSelectableField;
			property.FindPropertyRelative("Vector2Field").vector2Value = vector2Value;
			property.FindPropertyRelative("Vector3Field").vector3Value = vector3Value;
			property.FindPropertyRelative("Vector4Field").vector4Value = vector4Value;
			property.FindPropertyRelative("BoundsField").boundsValue = boundsValue;
			property.FindPropertyRelative("RectField").rectValue = rectValue;
			property.FindPropertyRelative("CurveField").animationCurveValue = curveValue;
			property.FindPropertyRelative("EnumField").enumValueIndex = (int)enumValue;
			property.FindPropertyRelative("MaskField").intValue = maskValue;
			property.FindPropertyRelative("ColorField").colorValue = colorValue;
			SetGradient(property.FindPropertyRelative("GradientField"), gradientValue);
			property.FindPropertyRelative("ObjectField").objectReferenceValue = objectValue;
		}

		/// <summary>
		/// Calcula a altura total considerando o numero de itens.
		/// </summary>
		/// <param name="property"></param>
		/// <param name="label"></param>
		/// <returns></returns>
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return (_elementLineCount * _lineHeight) + ((_elementLineCount - 1) * EditorGUIUtility.standardVerticalSpacing);
		}

		/// <summary>
		/// Cada vez que esse método é chamado ele calcula qual seria o retângulo da posição do próximo item
		/// com base no número de items que já foram criados e salva o incremento desse número para a próxima
		/// chamada através da variável 'ref yPosition'.
		/// </summary>
		/// <param name="position"></param>
		/// <param name="yPosition"></param>
		/// <param name="propertyHeight"></param>
		/// <returns></returns>
		private Rect GetNextRectPosition(Rect position, ref int yPosition, int propertyHeight = 1)
		{
			var rect = new Rect(position.x,
				position.y + (yPosition * (_lineHeight + EditorGUIUtility.standardVerticalSpacing)),
				position.width,
				(propertyHeight * _lineHeight) + ((propertyHeight - 1) * EditorGUIUtility.standardVerticalSpacing));

			yPosition += propertyHeight;
			return rect;
		}

		/// <summary>
		/// Tivemos de usar Reflection para pegar o 'gradientValue' pois ele está configurado como internal,
		/// erro da Unity talvez?
		/// 
		/// Reflection é um tópico mais avançado que não cobrimos no curso, mas saibam que é algo que pode 
		/// ter impactos de performance, utilizem com moderação. Como isso aqui é um código de editor não
		/// tem tanto problema.
		/// </summary>
		/// <param name="gradientProperty"></param>
		/// <returns></returns>
		private Gradient GetGradient(SerializedProperty gradientProperty)
		{
			PropertyInfo propertyInfo = typeof(SerializedProperty).GetProperty("gradientValue",
				BindingFlags.Public |
				BindingFlags.NonPublic |
				BindingFlags.Instance);

			if (propertyInfo == null)
			{
				return null;
			}
			else
			{
				return propertyInfo.GetValue(gradientProperty, null) as Gradient;
			}
		}

		/// <summary>
		/// Aqui fazemos o contrário, usando Reflection para configurar o novo valor do 'gradientValue'.
		/// </summary>
		/// <param name="gradientProperty"></param>
		/// <param name="value"></param>
		private void SetGradient(SerializedProperty gradientProperty, Gradient value)
		{
			PropertyInfo propertyInfo = typeof(SerializedProperty).GetProperty("gradientValue",
				BindingFlags.Public |
				BindingFlags.NonPublic |
				BindingFlags.Instance);

			propertyInfo?.SetValue(gradientProperty, value);
		}
	}
#endif
}
