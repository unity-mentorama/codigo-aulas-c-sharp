using Modulo8;
using TMPro;
using UnityEngine;

namespace Modulo9
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class PatrolStateView : MonoBehaviour
	{
		public PatrolComponent PatrolComponent;
		private TextMeshProUGUI _text;

		private void Start()
		{
			_text = GetComponent<TextMeshProUGUI>();
			_text.text = "Idle";
			PatrolComponent.OnStartedMoving += StartedMovingHandler;
			PatrolComponent.OnStoppedMoving += StoppedMovingHandler;
		}

		private void StartedMovingHandler(bool isRight)
		{
			_text.text = isRight ? "Right" : "Left";
		}

		private void StoppedMovingHandler()
		{
			_text.text = "Idle";
		}
	}
}