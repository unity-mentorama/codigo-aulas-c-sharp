using UnityEditor;
using UnityEngine;

namespace Modulo19
{
	[CustomPropertyDrawer(typeof(MyRangeAttribute))]
	public class MyRangeDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			// Pega e converte o Attribute para o nosso tipo.
			MyRangeAttribute range = (MyRangeAttribute)attribute;

			// Desenha a propriedade de forma diferente com base no seu tipo.
			switch (property.propertyType)
			{
				case SerializedPropertyType.Float:
					EditorGUI.Slider(position, property, range.Min, range.Max, label);
					break;

				case SerializedPropertyType.Integer:
					EditorGUI.IntSlider(position, property, (int)range.Min, (int)range.Max, label);
					break;

				default:
					position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
					EditorGUI.HelpBox(position, "Use MyRange with float or int.", MessageType.Error);
					break;
			}
		}
	}
}
