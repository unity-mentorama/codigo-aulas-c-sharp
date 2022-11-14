using TMPro;
using UnityEngine;

namespace Modulo17.Flyweight.Example2
{
	public class InfoPanel : MonoBehaviour
	{
		public GameObject Panel;
		public TextMeshProUGUI PanelText;

		private void Start()
		{
			HidePanel();
		}

		public void ShowPanel(string text)
		{
			Panel.SetActive(true);
			PanelText.text = text;
		}

		public void HidePanel()
		{
			Panel.SetActive(false);
		}
	}
}
