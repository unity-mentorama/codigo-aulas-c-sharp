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

				newCharacter.SetMemento(
					new CharacterData
					{
						WalkSpeed = Random.Range(1f, 3f),
						BodyColor = Random.ColorHSV(),
						HatColor = Random.ColorHSV()
					});

				newCharacter.MoveDirection = new Vector3(0, 0, 1);
			}
		}
	}
}
