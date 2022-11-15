using UnityEngine;

namespace Modulo17.Memento
{
	public class Spawner : MonoBehaviour
	{
		public Character CharacterPrefab;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				var newCharacter = Instantiate(CharacterPrefab, transform.position, Quaternion.identity);
				newCharacter.MoveDirection = new Vector3(0, 0, 1);
			}
		}
	}
}
