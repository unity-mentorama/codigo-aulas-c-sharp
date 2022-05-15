namespace Modulo15
{
	public class Armor : Item
	{
		public int Defense { get; set; }

		public Armor(ItemType itemType,
			string name,
			float value,
			float weight,
			int defense) : base(itemType,
							name,
							value,
							weight)
		{
			Defense = defense;
		}
	}
}