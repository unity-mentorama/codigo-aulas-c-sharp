using UnityEngine;

namespace Modulo6
{
	public class SwitchCase : MonoBehaviour
	{
		enum GameState
		{
			Starting = 0,   // 0
			InGame = 1,     // 1
			GameOver = 2    // 2
		}

		[SerializeField]
		GameState gameState;

		void Start()
		{
			int value = 0;

			switch (value)
			{
				case 0:
					break;

				case 1:
					break;

				case 2:
					break;
			}

			string myString = "Hello World";

			switch (myString)
			{
				case "Hello":
					Debug.Log(1);
					break;

				case "World":
					Debug.Log(2);
					break;

				case "Hello World":
					Debug.Log(3);
					break;
			}

			gameState = GameState.GameOver;

			switch (gameState)
			{
				case GameState.Starting:
					break;

				case GameState.InGame:
					break;

				case GameState.GameOver:
					break;
			}

			switch (gameState)
			{
				case GameState.Starting:
				case GameState.InGame:
					Debug.Log("InGame");
					break;

				case GameState.GameOver:
					break;
			}

			switch (gameState)
			{
				case GameState.Starting:
					break;

				default:
					break;
			}
		}
	}
}