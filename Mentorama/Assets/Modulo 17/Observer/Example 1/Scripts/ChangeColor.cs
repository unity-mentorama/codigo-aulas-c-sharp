using UnityEngine;

namespace Modulo17.Observer.Example1
{
	// ConcreteObserver
	public class ChangeColor : MonoBehaviour, IObserver
	{
		public InputHandler InputHandler;

		private void Start()
		{
			InputHandler.RegisterObserver(this);
		}

		private void OnDestroy()
		{
			InputHandler.UnregisterObserver(this);
		}

		public void Notify()
		{
			GetComponent<Renderer>().material.color = Random.ColorHSV();
		}
	}
}