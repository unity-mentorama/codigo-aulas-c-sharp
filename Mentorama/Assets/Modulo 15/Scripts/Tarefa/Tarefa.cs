using System.Text;
using UnityEngine;

namespace Modulo15
{
	public class Tarefa : MonoBehaviour
	{
		private void Start()
		{
			Inventory<Item> mainBag = new Inventory<Item>(10);

			// Outros exemplos de inventários que podemos ter.
			Inventory<Potion> potionBag = new Inventory<Potion>(4);
			Inventory<Armor> armorSlot = new Inventory<Armor>(1);
			Inventory<Weapon> weaponSlot = new Inventory<Weapon>(1);

			// Criando alguns itens para testar nosso código.
			Potion minorHealthPotion = MakeMinorHealthPotion();
			Potion majorHealthPotion = MakeMajorHealthPotion();
			Armor chainArmor = MakeChainArmor();
			Armor leatherArmor = MakeLeatherArmor();
			Weapon dagger = MakeDagger();
			Weapon sword = MakeSword();

			PrintInventoryItems(mainBag);

			// Testando colocar itens na bag de formas variadas.
			Debug.Log($"Put({dagger.Name})");
			mainBag.Put(dagger);
			PrintInventoryItems(mainBag);

			int auxPosition = 3;
			Debug.Log($"Put({sword.Name}, {auxPosition})");
			mainBag.Put(sword, auxPosition);
			PrintInventoryItems(mainBag);

			auxPosition = 4;
			Debug.Log($"mainBag[{auxPosition}] = {chainArmor.Name}");
			mainBag[auxPosition] = chainArmor;
			PrintInventoryItems(mainBag);

			Debug.Log($"Put({leatherArmor.Name})");
			mainBag.Put(leatherArmor);
			PrintInventoryItems(mainBag);

			Debug.Log($"Put({majorHealthPotion.Name})");
			mainBag.Put(majorHealthPotion);
			PrintInventoryItems(mainBag);

			Debug.Log($"Put({minorHealthPotion.Name})");
			mainBag.Put(minorHealthPotion);
			PrintInventoryItems(mainBag);

			// Testando pegar itens da bag.
			auxPosition = 5;
			Debug.Log($"Take({auxPosition}): {mainBag.Take(auxPosition).Name}");
			PrintInventoryItems(mainBag);

			// Tentando pegar item que já foi removido.
			var auxItemType = ItemType.MinorHealthPotion;
			Debug.Log($"TryTake({auxItemType})");
			if (mainBag.TryTake(auxItemType, out var itemTaken))
			{
				Debug.Log($"Pegou: {itemTaken})");
			}
			else
			{
				Debug.Log($"Não conseguiu pegar item do tipo: {auxItemType}");
			}
			PrintInventoryItems(mainBag);

			// Trocando itens de lugar.
			var index1 = 2;
			var index2 = 4;
			Debug.Log($"Swap({index1}, {index2})");
			mainBag.Swap(index1, index2);
			PrintInventoryItems(mainBag);

			// Trocando item com slot vazio.
			index1 = 1;
			index2 = 9;
			Debug.Log($"Swap({index1}, {index2})");
			mainBag.Swap(index1, index2);
			PrintInventoryItems(mainBag);

			// Checando se contém itens.
			auxItemType = ItemType.MinorHealthPotion;
			Debug.Log($"Contains({auxItemType})");
			if (mainBag.Contains(auxItemType))
			{
				Debug.Log($"Bag contém: {auxItemType}");
			}
			else
			{
				Debug.Log($"Bag não contém: {auxItemType}");
			}
			PrintInventoryItems(mainBag);

			auxItemType = ItemType.LeatherArmor;
			Debug.Log($"Contains({auxItemType})");
			if (mainBag.Contains(auxItemType))
			{
				Debug.Log($"Bag contém: {auxItemType}");
			}
			else
			{
				Debug.Log($"Bag não contém: {auxItemType}");
			}
			PrintInventoryItems(mainBag);

			// Contains usando Equals.
			var newDagger = MakeDagger();
			Debug.Log($"Contains({newDagger.Name})");
			if (mainBag.Contains(newDagger))
			{
				Debug.Log($"Bag contém: {newDagger.Name}");
			}
			else
			{
				Debug.Log($"Bag não contém: {newDagger.Name}");
			}
			PrintInventoryItems(mainBag);

			// Verificando qual item está numa certa posição de formas diferentes.
			auxPosition = 0;
			Debug.Log($"Peek({auxPosition})");
			// Cuidado, pode causar exception ao tentar pegar o .Name caso não haja item na posição.
			Debug.Log($"Item na posição {auxPosition}: {mainBag.Peek(auxPosition).Name}");
			PrintInventoryItems(mainBag);

			auxPosition = 3;
			Debug.Log($"mainBag[{auxPosition}]");
			// Cuidado, pode causar exception ao tentar pegar o .Name caso não haja item na posição.
			Debug.Log($"Item na posição {auxPosition}: {mainBag[auxPosition].Name}");
			PrintInventoryItems(mainBag);

			// Limpando a bag.
			Debug.Log($"Clear()");
			mainBag.Clear();
			PrintInventoryItems(mainBag);
		}

		private void PrintInventoryItems(Inventory<Item> inventory)
		{
			StringBuilder stringBuilder = new StringBuilder();

			for (int i = 0; i < inventory.TotalCapacity; i++)
			{
				var item = inventory.Peek(i);
				if (item != null)
				{
					stringBuilder.AppendLine($"[{i}]: {inventory.Peek(i).Name}");
				}
				else
				{
					stringBuilder.AppendLine($"[{i}]: -");
				}
			}

			stringBuilder.AppendLine("================");

			foreach (var item in inventory)
			{
				stringBuilder.AppendLine($"{item.Name}");
			}

			stringBuilder.AppendLine("================");
			stringBuilder.AppendLine($"Total Capacity: {inventory.TotalCapacity}");
			stringBuilder.AppendLine($"Item Count: {inventory.Count}");
			stringBuilder.AppendLine($"Free Slots: {inventory.RemainingCapacity}");

			if (inventory.LastItemAdded != null)
			{
				stringBuilder.AppendLine($"Last Item Added: {inventory.LastItemAdded.Name}");
			}
			else
			{
				stringBuilder.AppendLine($"Last Item Added: -");
			}

			Debug.Log(stringBuilder.ToString());
		}

		private Potion MakeMinorHealthPotion()
		{
			return new Potion(ItemType.MinorHealthPotion, "Minor Health Potion", 1f, 0.1f, 10);
		}

		private Potion MakeMajorHealthPotion()
		{
			return new Potion(ItemType.MajorHealthPotion, "Major Health Potion", 2.5f, 0.1f, 30);
		}

		private Armor MakeChainArmor()
		{
			return new Armor(ItemType.ChainArmor, "Chain Mail", 4f, 5f, 5);
		}

		private Armor MakeLeatherArmor()
		{
			return new Armor(ItemType.LeatherArmor, "Leather Armor", 2f, 3f, 3);
		}

		private Weapon MakeDagger()
		{
			return new Weapon(ItemType.Dagger, "Dagger", 3f, 0.5f, 8);
		}

		private Weapon MakeSword()
		{
			return new Weapon(ItemType.Sword, "Sword", 4f, 1f, 10);
		}
	}
}