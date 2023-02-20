using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modulo19
{
	public class ScoreUI : MonoBehaviour
	{
		public TextMeshProUGUI ScoreText;
		public FloatVariable ScoreValue;

		private void Start()
		{
			UpdateScoreText();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				ScoreValue.Value++;
				UpdateScoreText();
			}

			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				SceneManager.LoadScene("Modulo 19 - Scriptable Objects - Scene 2");
			}
		}

		private void UpdateScoreText()
		{
			ScoreText.text = $"Score: {ScoreValue.Value}";
		}
	}
}
