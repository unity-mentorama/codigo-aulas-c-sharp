using UnityEngine;

namespace Modulo17.Observer.Example2
{
	// ConcreteObserver
	public class ChangeColor : MonoBehaviour
	{
		public InputHandler InputHandler;

		private void Start()
		{
			InputHandler.Notify += Notify;
		}

		private void OnDestroy()
		{
			InputHandler.Notify -= Notify;
		}

		private void Notify()
		{
			GetComponent<Renderer>().material.color = Random.ColorHSV();
		}
	}
}