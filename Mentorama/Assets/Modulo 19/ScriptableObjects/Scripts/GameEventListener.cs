using UnityEngine;

namespace Modulo19
{
	public class GameEventListener : MonoBehaviour
	{
		public GameEvent Event;

		private void OnEnable()
		{
			Event.RegisterListener(this);
		}

		private void OnDisable()
		{
			Event.UnregisterListener(this);
		}

		public void OnEventRaised()
		{
			Debug.Log("Evento disparado!");
		}
	}
}
