using UnityEditor;
using UnityEngine;

namespace Modulo19
{
	public class ItemEditorWindow : EditorWindow
	{
		private Item _selectedItem;
		private Vector2 _scrollPosition;

		private string _newItemName = "";

		private string _tempItemName = "";
		private ItemType _tempItemType;
		private float _tempValue;
		private float _tempWeight;

		[MenuItem("Window/Item Editor")]
		public static void OpenWindow()
		{
			ItemEditorWindow window = GetWindow<ItemEditorWindow>();
			window.titleContent = new GUIContent("Item Editor");
		}

		private void OnGUI()
		{
			EditorGUILayout.BeginHorizontal();

			// Painel Lateral Esquerdo - Lista de Itens e Botão de Criar Item
			EditorGUILayout.BeginVertical(GUI.skin.box, GUILayout.Width(position.width * 0.4f));

			EditorGUILayout.LabelField("Items", EditorStyles.boldLabel);

			_scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);

			// Pega todos assets do tipo Item do projeto
			Item[] items = Resources.FindObjectsOfTypeAll<Item>();

			foreach (Item item in items)
			{
				if (GUILayout.Button(item.Name, GUILayout.ExpandWidth(true)))
				{
					GUI.FocusControl(null);
					_selectedItem = item;
					LoadItemDetails();
				}
			}

			EditorGUILayout.EndScrollView();

			// Cria a sessão para a criação de novos itens
			EditorGUILayout.Space();
			EditorGUILayout.LabelField("Create New Item", EditorStyles.boldLabel);
			_newItemName = EditorGUILayout.TextField("Item Name", _newItemName);

			if (GUILayout.Button("Create") && !string.IsNullOrEmpty(_newItemName))
			{
				CreateItem();
			}

			EditorGUILayout.EndVertical();

			// Painel direito - Detalhes do item selecionado
			EditorGUILayout.BeginVertical(GUI.skin.box, GUILayout.ExpandWidth(true));
			EditorGUILayout.LabelField("Selected Item", EditorStyles.boldLabel);

			if (_selectedItem != null)
			{
				EditorGUILayout.LabelField("Name", _selectedItem.Name);
				_tempItemType = (ItemType)EditorGUILayout.EnumPopup("Type", _tempItemType);
				_tempValue = EditorGUILayout.FloatField("Value", _tempValue);
				_tempWeight = EditorGUILayout.FloatField("Weight", _tempWeight);

				EditorGUILayout.Space();

				if (GUILayout.Button("Save"))
				{
					SaveItemChanges();
				}

				if (GUILayout.Button("Delete"))
				{
					DeleteItem();
				}
			}
			else
			{
				EditorGUILayout.HelpBox("Select an item from the list.", MessageType.Info);
			}

			EditorGUILayout.EndVertical();

			EditorGUILayout.EndHorizontal();
		}

		private void CreateItem()
		{
			if (ItemExists(_newItemName))
			{
				Debug.LogWarning("An item with the same name already exists.");
				return;
			}

			Item newItem = CreateInstance<Item>();
			newItem.Name = _newItemName;
			AssetDatabase.CreateAsset(newItem, $"Assets/Modulo 19/Tarefa/Items/{_newItemName}.asset");
			AssetDatabase.SaveAssets();
			_selectedItem = newItem;
			LoadItemDetails();
		}

		private bool ItemExists(string itemName)
		{
			Item[] items = Resources.FindObjectsOfTypeAll<Item>();

			foreach (Item item in items)
			{
				if (item.Name == itemName)
				{
					return true;
				}
			}

			return false;
		}

		private void LoadItemDetails()
		{
			_tempItemName = _selectedItem.Name;
			_tempItemType = _selectedItem.ItemType;
			_tempValue = _selectedItem.Value;
			_tempWeight = _selectedItem.Weight;
		}

		private void SaveItemChanges()
		{
			_selectedItem.Name = _tempItemName;
			_selectedItem.ItemType = _tempItemType;
			_selectedItem.Value = _tempValue;
			_selectedItem.Weight = _tempWeight;

			EditorUtility.SetDirty(_selectedItem);
			AssetDatabase.SaveAssets();
		}

		private void DeleteItem()
		{
			if (EditorUtility.DisplayDialog("Delete Item", "Are you sure you want to delete this item?", "Delete", "Cancel"))
			{
				AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(_selectedItem));
				AssetDatabase.SaveAssets();
				_selectedItem = null;
				ResetTempItemDetails();
			}
		}

		private void ResetTempItemDetails()
		{
			_tempItemName = "";
			_tempItemType = ItemType.Armor;
			_tempValue = 0f;
			_tempWeight = 0f;
		}
	}
}

