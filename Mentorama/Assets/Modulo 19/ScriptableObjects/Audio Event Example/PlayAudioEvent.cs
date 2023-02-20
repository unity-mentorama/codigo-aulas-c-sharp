using UnityEngine;

namespace Modulo19
{
	public class PlayAudioEvent : MonoBehaviour
	{
		public AudioSource AudioSource;
		public SimpleAudioEvent AudioEvent;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				AudioEvent.Play(AudioSource);
			}
		}
	}
}
