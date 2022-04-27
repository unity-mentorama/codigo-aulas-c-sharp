using System.Collections.Generic;
using UnityEngine;

namespace Modulo9
{
	delegate void SimpleDelegate();
	delegate string DoStuffDelegate(int a);

	public class Delegates : MonoBehaviour
	{
		//Func<int, int, float> IntParametersReturnFloat;
		//Action<int, int> IntParametersNoReturn;
		//Predicate<int> OneParameterRetornBool;

		event SimpleDelegate SimpleDelegate;

		void Start()
		{
			//SimpleDelegate = new SimpleDelegate(SimpleMethod1);

			//var simpleDelegate1 = new SimpleDelegate(SimpleMethod1);
			//simpleDelegate1();

			//var simpleDelegate2 = new SimpleDelegate(SimpleMethod2);
			//simpleDelegate2();

			//simpleDelegate1 = SimpleMethod2; // !!
			//simpleDelegate1.Invoke();

			//simpleDelegate1 = null;
			//simpleDelegate1?.Invoke();

			//Class myClass = new Class();
			//simpleDelegate1 = myClass.SimpleMethod;
			////myClass = null;
			//simpleDelegate1.Invoke();

			////System.GC.Collect();
			////SimpleDelegate = simpleDelegate1;

			//var simpleDelegate3 = simpleDelegate1 + simpleDelegate2;
			//simpleDelegate3();

			//var doStuffDelegate = new DoStuffDelegate(DoStuff);
			//var result = doStuffDelegate(5);
			//Debug.Log(result);

			////doStuffDelegate += myClass.DoStuff;

			//result = doStuffDelegate(25);
			//Debug.Log(result);

			////doStuffDelegate -= myClass.DoStuff;
			//result = doStuffDelegate(1);
			//Debug.Log(result);

			////doStuffDelegate -= myClass.DoStuff;
			//result = doStuffDelegate(2);
			//Debug.Log(result);

			//doStuffDelegate -= DoStuff;
			//result = doStuffDelegate?.Invoke(4);
			//Debug.Log(result); // result = null

			//// Delegates in a list Example

			//var vp = new VehicleProgram();
			//vp.Main();

			//// Events

			//myClass.SimpleDelegate(); // null ref, not defined

			//myClass.SimpleEvent += SimpleMethod1;
			//myClass.DoStuff(2);

			Main();
		}

		public delegate void OperationDelegate(int a, int b);

		public void Main()
		{
			ExecuteOperation(Add, 12, 30);
		}

		private void Add(int x, int y)
		{
			Debug.Log($"Sum = {x + y}");
		}

		void ExecuteOperation(OperationDelegate myDelegate, int a, int b)
		{
			myDelegate.Invoke(a, b);
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				SimpleDelegate();
			}
		}

		private void SimpleMethod1()
		{
			Debug.Log("My simple method 1.");
		}

		private void SimpleMethod2()
		{
			Debug.Log("My simple method 2.");
		}

		string DoStuff(int a)
		{
			Debug.Log("My DoStuff");
			return $"My DoStuff {a}";
		}
	}

	class Class
	{
		public SimpleDelegate SimpleDelegate;
		public event SimpleDelegate SimpleEvent;

		//~Class()
		//{
		//	Debug.Log("Class' destroy");
		//}

		public void SimpleMethod()
		{
			Debug.Log("Class' simple method");
		}

		public string DoStuff(int a)
		{
			Debug.Log("Class' DoStuff");

			SimpleEvent.Invoke();

			return $"Class' DoStuff {a + 1}";
		}
	}

	class VehicleProgram
	{
		//All vehicle classes implement their own engine starter method that has this signature
		delegate void StartEngine();
		public void Main()
		{
			//The Main doesn't know the details of starting an engine.
			//It delegates the responsibility to the concrete vehicle class
			foreach (StartEngine starter in GetVehicleStarters())
			{
				starter(); //Invoke the method
			}
		}

		List<StartEngine> GetVehicleStarters()
		{
			//Create a list of delegates that target the engine starter methods
			List<StartEngine> starters = new List<StartEngine>();

			var car = new Car();
			var motorcycle = new Motorcycle();
			var airplane = new Airplane();

			starters.Add(car.StartCar);
			starters.Add(motorcycle.StartMotorcycle);
			starters.Add(airplane.StartAirplane);

			return (starters);
		}

		class Car
		{
			public void StartCar()
			{
				Debug.Log("The car is starting.");
			}
		}

		class Motorcycle
		{
			public void StartMotorcycle()
			{
				Debug.Log("The motorcycle is starting.");
			}
		}

		class Airplane
		{
			public void StartAirplane()
			{
				Debug.Log("The airplane is starting.");
			}
		}
	}
}