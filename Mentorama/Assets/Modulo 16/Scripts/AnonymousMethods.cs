using System;
using UnityEngine;

namespace Modulo16
{
	public class AnonymousMethods : MonoBehaviour
	{
		private event Action _myEvent;

		private event Action<int> _myEventWithIntParameter;

		private void Start()
		{
			_myEvent += Method1;
			_myEventWithIntParameter += Method2;

			_myEvent?.Invoke();
			_myEventWithIntParameter?.Invoke(42);

			_myEvent += delegate
			{
				Debug.Log("Método sem nome!");
			};

			_myEventWithIntParameter += delegate (int value)
			{
				Debug.Log($"M�todo sem nome e com parâmetro int: {value}!");
			};

			_myEvent?.Invoke();
			_myEventWithIntParameter?.Invoke(42);
		}

		private void Method1()
		{
			Debug.Log($"Method1()");
		}

		private void Method2(int value)
		{
			Debug.Log($"Method2({value})");
		}
	}
}
