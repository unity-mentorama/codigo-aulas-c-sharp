using System;
using UnityEngine;

namespace Modulo16
{
	public class AnonymousMethods : MonoBehaviour
	{
		private event Action _myEvent;

		private event Action<int> _myEventWithIntParameter;

		private event Func<float, int> _myEventWithReturnValue;

		private void Start()
		{
			_myEvent += Method1;
			_myEventWithIntParameter += Method2;
			_myEventWithReturnValue += Method3;

			_myEvent?.Invoke();
			_myEventWithIntParameter?.Invoke(42);
			_myEventWithReturnValue?.Invoke(9.75f);

			_myEvent -= Method1;
			_myEventWithIntParameter -= Method2;
			_myEventWithReturnValue -= Method3;

			_myEvent += delegate
			{
				Debug.Log("Método sem nome!");
			};

			_myEventWithIntParameter += delegate (int value)
			{
				Debug.Log($"Método sem nome e com parâmetro int: {value}!");
			};

			_myEventWithReturnValue += delegate (float value)
			{
				Debug.Log($"Método sem nome, com parâmetro e valor de retorno");
				return (int)value;
			};

			_myEvent?.Invoke();
			_myEventWithIntParameter?.Invoke(42);
			_myEventWithReturnValue?.Invoke(9.75f);
		}

		private void Method1()
		{
			Debug.Log($"Method1()");
		}

		private void Method2(int value)
		{
			Debug.Log($"Method2({value})");
		}

		private int Method3(float value)
		{
			Debug.Log($"{(int)value}=Method3({value})");
			return (int)value;
		}
	}
}
