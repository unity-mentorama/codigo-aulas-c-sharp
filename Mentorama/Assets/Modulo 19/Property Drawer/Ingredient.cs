using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Modulo19
{
	public enum IngredientUnit
	{
		Spoon,
		Cup,
		Bowl,
		Piece
	}

	[Serializable]
	public class Ingredient
	{
		public string Name;
		public int Amount = 1;
		public IngredientUnit Unit;
	}

#if UNITY_EDITOR
	[CustomPropertyDrawer(typeof(Ingredient))]
	public class IngredientDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			//label = new GUIContent("Label", Resources.Load<Texture2D>("Mentorama-icon"), "Tooltip");
			label.text = "Label";
			label.tooltip = "Tooltip";
			label.image = Resources.Load("Mentorama-icon") as Texture;
			//label.image = EditorGUIUtility.IconContent("Prefab Icon").image;

			// Desenha label de prefix
			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

			// Calcula os rects das posições
			var amountRect = new Rect(position.x, position.y, 30, position.height);
			var unitRect = new Rect(position.x + 35, position.y, 60, position.height);
			var nameRect = new Rect(position.x + 100, position.y, position.width - 100, position.height);

			// Desenha os campos passando GUIContent.none para que eles não desenhem label nenhuma
			EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("Amount"), GUIContent.none);
			EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("Unit"), GUIContent.none);
			EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("Name"), GUIContent.none);
		}
	}
#endif

#if UNITY_EDITOR
	//[CustomPropertyDrawer(typeof(Ingredient))]
	public class ManualIngredientDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			// Usando BeginProperty / EndProperty nós garantimos que lógica de override de prefabs
			// ainda vai funcionar
			EditorGUI.BeginProperty(position, label, property);

			// Desenha label de prefix
			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

			// Calcula os rects das posições
			var amountRect = new Rect(position.x, position.y, 30, position.height);
			var unitRect = new Rect(position.x + 35, position.y, 60, position.height);
			var nameRect = new Rect(position.x + 100, position.y, position.width - 100, position.height);

			// Encontra as properties filhas com base em seus nomes 
			var amountProperty = property.FindPropertyRelative("Amount");
			var unitProperty = property.FindPropertyRelative("Unit");
			var nameProperty = property.FindPropertyRelative("Name");

			// Inicia uma checagem de mudança. EndChangeCheck só irá retornar true se algum dos campos
			// entre essas duas chamadas tiver sofrido alguma alteração no inspector.
			EditorGUI.BeginChangeCheck();

			// Desenha os campos guardando os valores em variáveis locais
			var amount = EditorGUI.IntField(amountRect, amountProperty.intValue);
			var unit = EditorGUI.EnumPopup(unitRect, (IngredientUnit)unitProperty.enumValueIndex);
			var name = EditorGUI.TextField(nameRect, nameProperty.stringValue);

			// Somente aplica os valores devolta às propriedades se houveram mudanças feitas pelo usuário.
			// De outra forma um valor de um único elemento pode sobrescrever outros quando fazendo
			// edicão de múltiplos objetos mesmo sem o usuário ter feito nada.
			if (EditorGUI.EndChangeCheck())
			{
				amountProperty.intValue = amount;
				unitProperty.enumValueIndex = (int)(IngredientUnit)unit;
				nameProperty.stringValue = name;
			}

			EditorGUI.EndProperty();
		}
	}
#endif

#if UNITY_EDITOR
	//[CustomPropertyDrawer(typeof(Ingredient))]
	public class MimicOriginalIngredientDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			float lineHeight = EditorGUIUtility.singleLineHeight;
			float lineSpacing = EditorGUIUtility.standardVerticalSpacing;

			// Se não configurar fica com o tamanho expandido
			position.height = lineHeight;

			// Desenha o foldout para poder expandir e ver os valores internos do nosso Ingredient
			property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, label);

			var endProperty = property.GetEndProperty();

			// A primeira chamada precisa entrar nos children
			var enterChildren = true;

			// Se o foldout tiver sido expandido
			if (property.isExpanded)
			{
				// Aplica uma indentação
				EditorGUI.indentLevel = 1;

				while (property.NextVisible(enterChildren) && !SerializedProperty.EqualContents(property, endProperty))
				{
					// As chamadas seguintes não devem mais entrar nos children
					enterChildren = false;

					position = new Rect(position.x, position.y + lineHeight + lineSpacing, position.width, lineHeight);
					EditorGUI.PropertyField(position, property, true);
				}

				EditorGUI.indentLevel = 0;
			}
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			float lineHeight = EditorGUIUtility.singleLineHeight;
			float lineSpacing = EditorGUIUtility.standardVerticalSpacing;
			int visibleProperties = 1;

			if (property.isExpanded)
			{
				var endProperty = property.GetEndProperty();
				while (property.NextVisible(true) && !SerializedProperty.EqualContents(property, endProperty))
				{
					visibleProperties++;
				}
			}

			return (lineHeight + lineSpacing) * visibleProperties;
		}
	}
#endif
}
