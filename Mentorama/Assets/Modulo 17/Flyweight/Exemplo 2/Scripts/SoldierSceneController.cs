using UnityEngine;

namespace Modulo17.Flyweight.Example2
{
	// Client
	public class SoldierSceneController : MonoBehaviour
	{
		public int NumberOfSoldiersToCreate = 99;
		public Vector2 MinPosition;
		public Vector2 MaxPosition;

		public SoldierGameObject SoldierPrefab;
		public InfoPanel InfoPanel;

		void Start()
		{
			int weaponType = 0;
			for (int i = 0; i < NumberOfSoldiersToCreate; i++)
			{
				var weapon = (WeaponType)weaponType;

				// Cria Flyweight não compartilhado
				var newSoldier = Instantiate(SoldierPrefab);
				newSoldier.Initialize(weapon, InfoPanel);
				newSoldier.name = newSoldier.GetSolderClassName();

				// Inicializa health com base no valor compartilhado do Flyweight
				int startHealth = SoldierFlyweightFactory.Soldier(weapon).Stats.MaxHealth;
				newSoldier.Health = startHealth;

				// Inicializa cor com base no valor compartilhado do Flyweight
				newSoldier.GetComponent<MeshRenderer>().material.color = SoldierFlyweightFactory.Soldier(weapon).GetColor(startHealth);

				// Posiciona aleatoriamente na scene
				float x = Random.Range(MinPosition.x, MaxPosition.x);
				float z = Random.Range(MinPosition.y, MaxPosition.y);

				newSoldier.transform.position = new Vector3(x, 0.5f, z);

				// Calcula próxima weaponType
				weaponType = (weaponType + 1) % 3;
			}
		}
	}
}
