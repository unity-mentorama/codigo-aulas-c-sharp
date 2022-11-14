using UnityEngine;

namespace Modulo17.Memento
{
	// Originator
	public class Character : MonoBehaviour
	{
		public MeshRenderer Body;
		public MeshRenderer Hat;

		public Vector3 MoveDirection;

		public CharacterData Data { get; protected set; }

		public void SetMemento(CharacterData data)
		{
			Data = data;

			Body.material.color = Data.BodyColor;
			Hat.material.color = Data.HatColor;
		}

		public CharacterMemento CreateMemento()
		{
			return new CharacterMemento(Data);
		}

		public CharacterData RestoreFromMemento(CharacterMemento memento)
		{
			SetMemento(memento.Data);
			return Data;
		}

		private void FixedUpdate()
		{
			transform.Translate(MoveDirection * Data.WalkSpeed * Time.fixedDeltaTime);
		}
	}
}
