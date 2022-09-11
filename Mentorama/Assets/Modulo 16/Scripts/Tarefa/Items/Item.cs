using System;

namespace Modulo16
{
	public abstract class Item : IEquatable<Item>
	{
		public Item(
			ItemType itemType,
			string name,
			float value,
			float weight)
		{
			ItemType = itemType;
			Name = name;
			Value = value;
			Weight = weight;
		}

		public ItemType ItemType { get; }

		public string Name { get; }

		public float Value { get; }

		public float Weight { get; }

		public bool Equals(Item other)
		{
			return ItemType == other.ItemType;
		}
	}
}