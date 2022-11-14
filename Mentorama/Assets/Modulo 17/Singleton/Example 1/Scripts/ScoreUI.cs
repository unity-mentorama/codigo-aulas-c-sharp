using TMPro;
using UnityEngine;

namespace Modulo17.Singleton.Example1
{
	public class ScoreUI : MonoBehaviour
	{
		public TextMeshProUGUI ScoreText;

		private void Start()
		{
			UpdateScoreText();
		}

		private void Update()
		{
			UpdateScoreText();
		}

		private void UpdateScoreText()
		{
			ScoreText.text = $"Score: {ScoreManager.Instance.Score}";
		}
	}
}

