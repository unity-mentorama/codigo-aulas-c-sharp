using System;
using UnityEngine;

namespace Modulo17.Memento
{
	public class Entrance : MonoBehaviour
	{
		public event Action<Character> OnCharacterEntered;

		private void OnTriggerEnter(Collider other)
		{
			var character = other.GetComponent<Character>();

			if (character != null)
			{
				OnCharacterEntered?.Invoke(character);
			}
		}
	}
}
