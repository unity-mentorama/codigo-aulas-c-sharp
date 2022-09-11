using System;
using UnityEngine;

namespace Modulo16
{
	// Anonymous Functions = Anonymous Methods + Lambda Expressions
	public class LambdaExpressions : MonoBehaviour
	{
		private event Action _myEvent;

		private event Action<int> _myEventWithIntParameter;

		private void Start()
		{
			// parameter-list => body
			// (a, b, c) => { };

			_myEvent += () =>
			{
				Debug.Log("Método sem nome!");
			};

			_myEvent += () => Debug.Log("Método sem nome!");

			_myEvent?.Invoke();

			_myEventWithIntParameter += (int value) =>
			// statement bodies
			{
				Debug.Log($"Método sem nome e com parâmetro int: {value}!");
			};

			// expression bodies
			_myEventWithIntParameter += (int value) => Debug.Log($"Método sem nome e com parâmetro int: {value}!");
			_myEventWithIntParameter += (value) => Debug.Log($"Método sem nome e com parâmetro int: {value}!");
			_myEventWithIntParameter += value => Debug.Log($"Método sem nome e com parâmetro int: {value}!");

			_myEventWithIntParameter?.Invoke(42);

			Func<string, int> squareLengh = (string text) =>
			{
				int lengh = text.Length;
				return lengh * lengh;
			};

			squareLengh = (text) =>
			{
				int lengh = text.Length;
				return lengh * lengh;
			};

			squareLengh = text =>
			{
				int lengh = text.Length;
				return lengh * lengh;
			};

			squareLengh = text => text.Length * text.Length;

			squareLengh?.Invoke("Lex");

			//
			Func<int, int, int> multiply = (int x, int y) => { return x * y; };
			multiply = (int x, int y) => x * y;
			multiply = (x, y) => x * y;

			multiply?.Invoke(7, 13);
		}
	}
}