using UnityEngine;

namespace Modulo17.Flyweight.Example2
{
	// Client
	public class SoldierGameObject : MonoBehaviour
	{
		// ExtrinsicState
		public int Health = 0;

		private ISoldierFlyweight _soldier = null;

		private bool _mouseOver = false;
		private InfoPanel _infoPanel;

		public void Initialize(WeaponType weaponType, InfoPanel infoPanel)
		{
			_soldier = SoldierFlyweightFactory.Soldier(weaponType);
			gameObject.AddComponent<BoxCollider>();
			_infoPanel = infoPanel;
		}

		public string GetSolderClassName()
		{
			return _soldier.GetType().Name;
		}

		private void OnMouseOver()
		{
			if (_soldier != null)
			{
				// Level up na instância flyweight
				if (Input.GetMouseButtonDown(1))
				{
					_soldier.LevelUp();
					UpdatePanel();
					Debug.LogFormat($"Leveling up all {GetSolderClassName()} to level {_soldier.Stats.Level}");
				}
				// Dano na instância única
				else if (Input.GetMouseButtonDown(0))
				{
					Health -= 5;

					if (Health <= 0)
					{
						Destroy(gameObject);
						HidePanel();
						return;
					}
					else
					{
						gameObject.GetComponent<MeshRenderer>().material.color = _soldier.GetColor(Health);
						UpdatePanel();
					}
				}

				if (!_mouseOver)
				{
					UpdatePanel();
					_mouseOver = true;
				}
			}
		}

		private void OnMouseExit()
		{
			if (_mouseOver)
			{
				HidePanel();
			}
		}

		private void UpdatePanel()
		{
			string soldierInfo =
				$"Weapon: {_soldier.Weapon}\n" +
				$"Level: {_soldier.Stats.Level}\n" +
				$"Attack: {_soldier.Stats.Attack}\n" +
				$"Dexterity: {_soldier.Stats.Dexterity}\n" +
				$"Defense: {_soldier.Stats.Defense}\n" +
				$"Health: {Health}/{_soldier.Stats.MaxHealth}";

			_infoPanel.ShowPanel(soldierInfo);
		}

		private void HidePanel()
		{
			_infoPanel.HidePanel();
			_mouseOver = false;
		}
	}
}
