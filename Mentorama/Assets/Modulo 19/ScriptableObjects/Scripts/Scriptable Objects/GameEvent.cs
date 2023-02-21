using System.Collections.Generic;
using UnityEngine;

namespace Modulo19
{
	[CreateAssetMenu(fileName = "New GameEvent", menuName = "ScriptableObjects/Game Event")]
	public class GameEvent : ScriptableObject
	{
		private List<GameEventListener> _listeners = new List<GameEventListener>();

		[ContextMenu("Raise Event")]
		public void Raise()
		{
			for (int i = _listeners.Count - 1; i >= 0; i--)
			{
				_listeners[i].OnEventRaised();
			}
		}

		public void RegisterListener(GameEventListener listener)
		{
			_listeners.Add(listener);
		}

		public void UnregisterListener(GameEventListener listener)
		{
			_listeners.Remove(listener);
		}
	}
}
