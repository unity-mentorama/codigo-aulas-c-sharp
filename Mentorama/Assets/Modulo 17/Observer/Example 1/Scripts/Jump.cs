using UnityEngine;

namespace Modulo17.Observer.Example1
{
	// ConcreteObserver
	public class Jump : MonoBehaviour, IObserver
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
			GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 0));
		}
	}
}
