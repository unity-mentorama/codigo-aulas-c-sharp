using UnityEngine;

public class Enums : MonoBehaviour
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
		gameState = GameState.GameOver;

		Debug.Log($"gameState: {((int)gameState)}");

		if (gameState == GameState.InGame)
		{
			//
		}
		else if (gameState == GameState.GameOver)
		{
			//
		}
	}
}
