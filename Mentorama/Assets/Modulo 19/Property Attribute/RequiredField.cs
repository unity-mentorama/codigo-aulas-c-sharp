using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Modulo19
{
	public enum FieldColor
	{
		Red,
		Green,
		Blue,
		Yellow
	}

	public class RequiredField : PropertyAttribute
	{
		public Color Color;

		public RequiredField(FieldColor _color = FieldColor.Red)
		{
			switch (_color)
			{
				case FieldColor.Red:
					Color = Color.red;
					break;
				case FieldColor.Green:
					Color = Color.green;
					break;
				case FieldColor.Blue:
					Color = Color.blue;
					break;
				case FieldColor.Yellow:
					Color = Color.yellow;
					break;
				default:
					Color = Color.red;
					break;
			}
		}
	}

#if UNITY_EDITOR
	[CustomPropertyDrawer(typeof(RequiredField))]
	public class RequiredFieldDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			RequiredField field = attribute as RequiredField;

			switch (property.propertyType)
			{
				case SerializedPropertyType.ObjectReference:

					if (property.objectReferenceValue == null)
					{
						GUI.color = field.Color;
						EditorGUI.PropertyField(position, property, label);
						GUI.color = Color.white;
					}
					else
					{
						EditorGUI.PropertyField(position, property, label);
					}

					break;

				case SerializedPropertyType.Generic:

					if (property.type == "Ingredient")
					{
						GUI.color = field.Color;

						var drawer = new IngredientDrawer();
						//var drawer = new MimicOriginalIngredientDrawer();
						drawer.OnGUI(position, property, label);

						GUI.color = Color.white;
						return;
					}

					break;

				default:
					EditorGUI.PropertyField(position, property, label, true);
					break;
			}
		}

		//public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		//{
		//	float lineHeight = EditorGUIUtility.singleLineHeight;
		//	float lineSpacing = EditorGUIUtility.standardVerticalSpacing;
		//	int visibleProperties = 1;

		//	if (property.isExpanded)
		//	{
		//		var endProperty = property.GetEndProperty();
		//		while (property.NextVisible(true) && !SerializedProperty.EqualContents(property, endProperty))
		//		{
		//			visibleProperties++;
		//		}
		//	}

		//	return (lineHeight + lineSpacing) * visibleProperties;
		//}
	}
#endif
}
