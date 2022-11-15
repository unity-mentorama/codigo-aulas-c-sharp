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

		public void Awake()
		{
			Data = new CharacterData
			{
				WalkSpeed = Random.Range(1f, 3f),
				BodyColor = Random.ColorHSV(),
				HatColor = Random.ColorHSV()
			};

			UpdateMaterials();
		}

		public void SetMemento(CharacterMemento memento)
		{
			Data = memento.Data;

			UpdateMaterials();
		}

		public CharacterMemento CreateMemento()
		{
			return new CharacterMemento(Data);
		}

		private void UpdateMaterials()
		{
			Body.material.color = Data.BodyColor;
			Hat.material.color = Data.HatColor;
		}

		private void FixedUpdate()
		{
			transform.Translate(MoveDirection * Data.WalkSpeed * Time.fixedDeltaTime);
		}
	}
}
