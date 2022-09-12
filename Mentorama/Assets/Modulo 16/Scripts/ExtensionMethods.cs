using UnityEngine;

namespace Modulo16
{
	public class ExtensionMethods : MonoBehaviour
	{
		void Start()
		{
			gameObject.MoveUp();
			GameObjectExtensions.MoveUp(gameObject);

			gameObject.MoveUp(5);
			GameObjectExtensions.MoveUp(gameObject, 5);

			gameObject.MoveUpChained(2).MoveUpChained(10).MoveUp();
			var newGameObject = GameObjectExtensions.MoveUpChained(gameObject, 2);
			newGameObject = GameObjectExtensions.MoveUpChained(gameObject, 10);
			newGameObject.MoveUp();
		}
	}

	public static class GameObjectExtensions
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