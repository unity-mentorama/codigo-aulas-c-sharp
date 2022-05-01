using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modulo15
{
	public class SortableObjects : MonoBehaviour
	{
		private void Start()
		{
			SortListIntExample();

			SortListItemExample();

			SortListComparableItemExample();

			EqualityExample();

			OperatorOverloadingExample();
		}

		private void SortListIntExample()
		{
			List<int> list = new List<int>();

			list.Add(4);
			list.Add(1);
			list.Add(2);

			Helper.UnityLogCollection(list);

			Debug.Log("Ordenando lista...");
			list.Sort();

			Helper.UnityLogCollection(list);
		}

		private void SortListItemExample()
		{
			List<Item> items = new List<Item>();

			items.Add(new Item() { Value = 4, Weight = 10 }); // 0
			items.Add(new Item() { Value = 1, Weight = 20 }); // 1
			items.Add(new Item() { Value = 2, Weight = 15 }); // 2
			items.Add(new Item() { Value = 4, Weight = 15 }); // 3
			items.Add(new Item() { Value = 2, Weight = 17 }); // 4

			Helper.UnityLogCollection(items);

			//items.Sort(); // Não implementa IComparable
			//Helper.UnityLogCollection(items);

			Debug.Log("Ordenando lista DescendingComparer");
			items.Sort(new DescendingComparer());
			Helper.UnityLogCollection(items);

			Debug.Log("Ordenando lista WeightComparer");
			items.Sort(new WeightComparer());
			Helper.UnityLogCollection(items);
		}

		private void SortListComparableItemExample()
		{
			List<ComparableItem> items = new List<ComparableItem>();

			items.Add(new ComparableItem() { Value = 4, Weight = 10 }); // 0
			items.Add(new ComparableItem() { Value = 1, Weight = 15 }); // 1
			items.Add(new ComparableItem() { Value = 2, Weight = 17 }); // 2
			items.Add(new ComparableItem() { Value = 4, Weight = 15 }); // 3
			items.Add(new ComparableItem() { Value = 2, Weight = 17 }); // 4

			Helper.UnityLogCollection(items);

			Debug.Log("Ordenando lista com Sort()");
			items.Sort();
			Helper.UnityLogCollection(items);

			Debug.Log("Ordenando lista DescendingComparer");
			items.Sort(new DescendingComparer());
			Helper.UnityLogCollection(items);

			Debug.Log("Ordenando lista WeightComparer");
			items.Sort(new WeightComparer());
			Helper.UnityLogCollection(items);
		}

		private void EqualityExample()
		{
			List<EquatableItem> items = new List<EquatableItem>();

			items.Add(new EquatableItem() { Value = 4, Weight = 10 }); // 0
			items.Add(new EquatableItem() { Value = 1, Weight = 15 }); // 1
			items.Add(new EquatableItem() { Value = 2, Weight = 17 }); // 2
			items.Add(new EquatableItem() { Value = 4, Weight = 15 }); // 3
			items.Add(new EquatableItem() { Value = 2, Weight = 17 }); // 4

			Helper.UnityLogCollection(items);

			Debug.Log($"{items[0]} == {items[3]}: {items[0].Equals(items[3])}");
			Debug.Log($"{items[1]} == {items[3]}: {items[1].Equals(items[3])}");
			Debug.Log($"{items[2]} == {items[4]}: {items[2].Equals(items[4])}");
		}

		private void OperatorOverloadingExample()
		{
			List<OperatorOverloading> items = new List<OperatorOverloading>();

			items.Add(new OperatorOverloading() { Value = 4, Weight = 10 });
			items.Add(new OperatorOverloading() { Value = 1, Weight = 15 });
			items.Add(new OperatorOverloading() { Value = 2, Weight = 17 });
			items.Add(new OperatorOverloading() { Value = 4, Weight = 15 });
			items.Add(new OperatorOverloading() { Value = 2, Weight = 17 });

			Helper.UnityLogCollection(items);

			Debug.Log($"{items[0]} == {items[3]}: {items[0] == items[3]}");
			Debug.Log($"{items[1]} == {items[3]}: {items[1] == items[3]}");
			Debug.Log($"{items[2]} == {items[4]}: {items[2] == items[4]}");
		}

		private class Item
		{
			public float Value { get; set; }

			public float Weight { get; set; }

			public override string ToString()
			{
				return $"Item (Value: {Value}, Weight: {Weight})";
			}
		}

		private class ComparableItem : Item, IComparable<ComparableItem>
		{
			public int CompareTo(ComparableItem otherItem)
			{
				return Value.CompareTo(otherItem.Value);
			}
		}

		private class DescendingComparer : IComparer<Item>
		{
			public int Compare(Item item1, Item item2)
			{
				var status = (item1.Value > item2.Value) ? -1 : ((item1.Value == item2.Value) ? 0 : 1);
				return status;
			}
		}

		private class WeightComparer : IComparer<Item>
		{
			public int Compare(Item item1, Item item2)
			{
				return item1.Weight.CompareTo(item2.Weight);
			}
		}

		private class EquatableItem : Item, IEquatable<Item>
		{
			public bool Equals(Item other)
			{
				return Value == other.Value && Weight == other.Weight;
			}
		}

#pragma warning disable 0660, 0661 // Este código retira os warning
		private class OperatorOverloading : ComparableItem, IEquatable<Item>
		{
#pragma warning restore 0660, 0661 // Este código restaura os warning
			public bool Equals(Item other)
			{
				return Value == other.Value && Weight == other.Weight;
			}

			public static bool operator ==(OperatorOverloading lhs, OperatorOverloading rhs)
			{
				return lhs.Equals(rhs);
			}

			public static bool operator !=(OperatorOverloading lhs, OperatorOverloading rhs)
			{
				return !lhs.Equals(rhs);
			}

			// x + y
			// x - y
			// x * y
			// x / y
			// x % y
			// x & y
			// x | y
			// x ^ y
			// x << y
			// x >> y
			// x == y
			// x != y
			// x < y
			// x > y
			// x <= y
			// x >= y
			// +x
			// -x
			// !x
			// ~x
			// ++
			// --
			// true
			// false
		}
	}
}
