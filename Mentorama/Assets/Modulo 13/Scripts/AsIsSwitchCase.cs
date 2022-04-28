using UnityEngine;

namespace Modulo13
{
	public class AsIsSwitchCase : MonoBehaviour
	{
		private void Start()
		{
			Item item = new Potion();
			//Item item = new Armor();
			//Item item = new Weapon();

			IEquippable equip;

			// Causa exception caso não seja um cast válido
			equip = (IEquippable)item;

			equip = item as IEquippable;
			if (equip != null)
			{
				//
			}

			if (item is IEquippable)
			{
				equip = (IEquippable)item;
			}

			if (item is IEquippable auxEquip)
			{
				// auxEquip...
			}

			switch (equip)
			{
				case ISheathable sheath:
					break;

				case Bag<Item> itemBag:
					break;

				case Bag<IEquippable> equippableBag:
					break;

				case Item auxItem when auxItem.Value > 10:
					break;

				case Item auxItem:
					break;

				case null:
					break;

				default:
				case IEquippable equip2:
					break;
			}
		}

		private abstract class Item
		{
			public float Value { get; set; }
		}

		private interface IEquippable { }

		private interface ISheathable { }

		private class Potion : Item { }
		private class Armor : Item, IEquippable { }
		private class Weapon : Item, IEquippable, ISheathable { }
	}
}