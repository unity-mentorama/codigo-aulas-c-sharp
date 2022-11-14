using UnityEngine;

namespace Modulo17.Observer.Example2
{
	// ConcreteObserver
	public class Jump : MonoBehaviour
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
			GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 0));
		}
	}
}
