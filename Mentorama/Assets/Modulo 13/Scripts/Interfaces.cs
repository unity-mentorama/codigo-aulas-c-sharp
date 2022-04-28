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

			var example2 = (IExample2)example;
			example2.Value = 0;
		}

		private void Example_MyEvent(int obj)
		{
			throw new NotImplementedException();
		}
	}

	public interface IExample2
	{
		int Value { get; set; }
	}

	public interface IExample : IExample2
	{
		// + Métodos abstratos
		// + Propriedades
		// + Indexers
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

	public class MyClass : IExample, IExample2
	{
		public int IntValue { get; }
		int IExample2.Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public event Action<int> MyEvent;

		public void Show()
		{
			Debug.Log("Show");
			MyEvent?.Invoke(0);
		}

		public void Hide()
		{
			Debug.Log("Hide");
		}
	}
}