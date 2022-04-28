using System;
using UnityEngine;

namespace Modulo13
{
	public class Interfaces : MonoBehaviour
	{
		void Start()
		{
			// Interfaces não podem ser instanciadas com new
			//IExample example = new IExample();
			IExample example = new MyClass();

			example.Show();
			var value = example.IntValue;
			example.MyEvent += Example_MyEvent;
		}

		private void Example_MyEvent(int obj)
		{
			throw new NotImplementedException();
		}
	}

	public interface IExample
	{
		// + Métodos abstratos
		// + Propriedades
		// + Indexes
		// + Eventos

		// - Métodos não abstratos
		// - Campos de dados
		// - Construtores
		// - Destrutores
		//public Action<int> Delegate;
		//public int IntValue;

		// Public por padrão
		// Não pode ser sealed

		public event Action<int> MyEvent;

		public int IntValue { get; }

		public void Show();
	}

	public class MyClass : IExample
	{
		public int IntValue { get; }

		public event Action<int> MyEvent;

		public void Show()
		{
			Debug.Log("Show");
			MyEvent?.Invoke(0);
		}
	}
}