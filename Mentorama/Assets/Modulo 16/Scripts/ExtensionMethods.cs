using UnityEngine;

namespace Modulo16
{
	public class ExtensionMethods : MonoBehaviour
	{
		void Start()
		{
			gameObject.MoveUp();
			gameObject.MoveUp(5);
			gameObject.MoveUpChained(2).MoveUp();
		}
	}

	public static class ExampleClass
	{
		public static void MoveUp(this GameObject gameObject)
		{
			gameObject.transform.Translate(0, 1, 0);
		}

		public static void MoveUp(this GameObject gameObject, float ammount)
		{
			gameObject.transform.Translate(0, ammount, 0);
		}

		public static GameObject MoveUpChained(this GameObject gameObject, float ammount)
		{
			gameObject.transform.Translate(0, ammount, 0);
			return gameObject;
		}
	}
}