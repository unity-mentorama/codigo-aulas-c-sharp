using System;
using UnityEngine;

namespace Modulo17.Observer.Example2
{
	// Subject
	public class InputHandler : MonoBehaviour
	{
		public event Action Notify;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Notify?.Invoke();
			}
		}
	}
}
