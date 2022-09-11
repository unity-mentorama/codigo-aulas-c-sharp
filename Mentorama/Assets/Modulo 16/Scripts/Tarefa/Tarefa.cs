using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Modulo16
{
	public class Tarefa : MonoBehaviour
	{
		private void Start()
		{
			var mainBag = new Inventory<Item>(10);

			// Adicionando um item de cada na bag
			mainBag.Put(MakeMinorHealthPotion());
			mainBag.Put(MakeMajorHealthPotion());
			mainBag.Put(MakeChainArmor());
			mainBag.Put(MakeLeatherArmor());
			mainBag.Put(MakeDagger());
			mainBag.Put(MakeSword());

			PrintInventoryItems(mainBag);

			// Peso total da bag.
			Debug.Log($"total weight: {mainBag.Sum(item => item.Weight)}");

			// Peso total dos itens que valem 3 ou mais.
			Debug.Log($"valuables weight: {mainBag.Where(item => item.Value >= 3).Sum(item => item.Weight)}");

			// Lista de nome dos itens que valem 3 ou mais.
			List<string> names = mainBag.Where(item => item.Value >= 3).Select(item => item.Name).ToList();

			foreach (var itemName in names)
			{
				Debug.Log($"item: {itemName}");
			}
		}

		private void PrintInventoryItems(Inventory<Item> inventory)
		{
			var stringBuilder = new StringBuilder();

			for (int i = 0; i < inventory.TotalCapacity; i++)
			{
				var item = inventory.Peek(i);
				if (item != null)
				{
					stringBuilder.AppendLine($"[{i}]: {item.Name} [value: {item.Value} - weight: {item.Weight}]");
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
