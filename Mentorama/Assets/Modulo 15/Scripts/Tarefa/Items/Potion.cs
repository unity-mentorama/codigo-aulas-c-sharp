namespace Modulo15
{
	public class Potion : Item
	{
		public int Power { get; set; }

		public Potion(ItemType itemType,
			string name,
			float value,
			float weight,
			int power) : base(itemType,
							name,
							value,
							weight)
		{
			Power = power;
		}
	}
}