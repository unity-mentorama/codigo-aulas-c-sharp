using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modulo17.Singleton.Example2
{
	public class InputHandler : MonoBehaviour
	{
		public GameObject ScorePanelPrefab;
		public Transform AllScorePanels;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				ScoreManager.Instance.AddScore(5);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				var newPanel = Instantiate(ScorePanelPrefab);
				newPanel.transform.SetParent(AllScorePanels);
			}
			else if (Input.GetKeyDown(KeyCode.Escape))
			{
				SceneManager.LoadScene("Singleton - Example 2 - Scene 2");
			}
		}
	}
}
