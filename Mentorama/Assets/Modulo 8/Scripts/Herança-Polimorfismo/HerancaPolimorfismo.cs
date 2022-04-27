using UnityEngine;

namespace Modulo8
{
	public class HerancaPolimorfismo : MonoBehaviour
	{
		private void Start()
		{
			Car myCar = new Car();
			myCar.Honk();

			Debug.Log($"{myCar.Brand} - {myCar.Model}");

			Animal myAnimal = new Animal();  // Create a Animal object
			Animal myPig = new Pig();  // Create a Pig object
			Animal myDog = new Dog();  // Create a Dog object

			myAnimal.AnimalSound();
			myPig.AnimalSound();
			myDog.AnimalSound();
		}
	}

	// ================================

	public /*sealed*/ class Vehicle
	{
		public string Brand = "Ford";
		//private protected

		public void Honk()
		{
			Debug.Log("FOM FOM!");
		}
	}

	class Car : Vehicle
	{
		public string Model = "Mustang";
	}

	class Truck : Car
	{
		public int Axels = 3;
	}

	// ================================

	class Animal
	{
		public virtual void AnimalSound()
		{
			Debug.Log("The animal makes a sound");
		}
	}

	class Pig : Animal
	{
		public override void AnimalSound()
		{
			Debug.Log("The pig says: wee wee");
		}
	}

	class Dog : Animal
	{
		public override void AnimalSound()
		{
			Debug.Log("The dog says: bow wow");
		}
	}

	// ================================

	// Abstract class
	abstract class Animal2
	{
		// Abstract method (does not have a body)
		public abstract void AnimalSound();
		// Regular method
		public void Sleep()
		{
			Debug.Log("Zzz");
		}
	}

	// Derived class (inherit from Animal)
	class Pig2 : Animal2
	{
		public override void AnimalSound()
		{
			// The body of animalSound() is provided here
			Debug.Log("The pig says: wee wee");
		}

		//public new void Sleep()
		//{
		//	Debug.Log("Zzz");
		//}
	}
}