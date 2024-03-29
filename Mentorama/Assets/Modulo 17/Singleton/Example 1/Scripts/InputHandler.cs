using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modulo17.Singleton.Example1
{
	public class InputHandler : MonoBehaviour
	{
		public GameObject ScorePanelPrefab;
		public Transform AllScorePanels;

		public int IncrementScoreValue = 5;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				ScoreManager.Instance.AddScore(IncrementScoreValue);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				var newPanel = Instantiate(ScorePanelPrefab);
				newPanel.transform.SetParent(AllScorePanels);
			}
			else if (Input.GetKeyDown(KeyCode.Escape))
			{
				SceneManager.LoadScene("Singleton - Example 1 - Scene 2");
			}
		}
	}
}
