using System.Collections.Generic;
using UnityEngine;

namespace Modulo17.Observer.Example1
{
	// Subject
	public class InputHandler : MonoBehaviour
	{
		private readonly List<IObserver> _observers = new List<IObserver>();

		public void RegisterObserver(IObserver observer)
		{
			_observers.Add(observer);
		}

		public void UnregisterObserver(IObserver observer)
		{
			_observers.Remove(observer);
		}

		public void NotifyObservers()
		{
			foreach (var observer in _observers)
			{
				observer.Notify();
			}
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				NotifyObservers();
			}
		}
	}
}
