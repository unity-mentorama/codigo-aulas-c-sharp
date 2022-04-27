using UnityEngine;

namespace Modulo10
{
	public class HealthComponent : MonoBehaviour
	{
		public int MaxHealth { get; set; }

		public int CurrentHealth { get; set; }

		// Construtores n�o s�o utilizados.
		public HealthComponent(int max, int current)
		{
			MaxHealth = max;
			CurrentHealth = current;
		}

		public void Initialize(int max, int current)
		{
			MaxHealth = max;
			CurrentHealth = current;
		}

		private void Update()
		{
			// enabled
			Debug.Log($"{name}: {CurrentHealth}/{MaxHealth}");
		}
	}
}