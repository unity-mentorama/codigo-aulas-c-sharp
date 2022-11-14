using System.Collections;
using UnityEngine;

namespace Modulo17.Singleton.Example2
{
	// Singleton
	public class ScoreManager : MonoSingleton<ScoreManager>
	{
		public int Score { get; private set; }

		private IEnumerator Start()
		{
			while (true)
			{
				yield return new WaitForSeconds(1f);
				Score++;
			}
		}

		public void AddScore(int score)
		{
			Score += score;
		}
	}
}
