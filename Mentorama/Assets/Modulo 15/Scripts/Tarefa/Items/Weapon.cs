namespace Modulo15
{
	public class Weapon : Item
	{
		public int Damage { get; set; }

		public Weapon(ItemType itemType,
			string name,
			float value,
			float weight,
			int damage) : base(itemType,
							name,
							value,
							weight)
		{
			Damage = damage;
		}
	}
}