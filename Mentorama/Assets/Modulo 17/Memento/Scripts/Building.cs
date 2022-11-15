using System.Collections.Generic;
using UnityEngine;

namespace Modulo17.Memento
{
	// Caretaker
	public class Building : MonoBehaviour
	{
		public Character CharacterPrefab;
		public Entrance Entrance;
		public Transform ExitSpot;

		readonly Queue<CharacterMemento> _savedMementos = new Queue<CharacterMemento>();

		private void Start()
		{
			Entrance.OnCharacterEntered += Entrance_OnCharacterEntered;
		}

		private void Entrance_OnCharacterEntered(Character character)
		{
			_savedMementos.Enqueue(character.CreateMemento());
			Destroy(character.gameObject);
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				if (_savedMementos.Count > 0)
				{
					var oldCharacter = Instantiate(CharacterPrefab, ExitSpot.position, Quaternion.identity);

					oldCharacter.SetMemento(_savedMementos.Dequeue());

					oldCharacter.MoveDirection = new Vector3(0, 0, -1);
				}
			}
		}
	}
}
