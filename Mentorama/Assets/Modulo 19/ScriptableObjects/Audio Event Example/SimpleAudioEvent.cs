using UnityEngine;

namespace Modulo19
{
	[CreateAssetMenu(menuName = "ScriptableObjects/Audio Event")]
	public class SimpleAudioEvent : ScriptableObject
	{
		public AudioClip[] Clips;

		public Vector2 Volume;

		public Vector2 Pitch;

		public void Play(AudioSource source)
		{
			if (Clips.Length == 0) return;

			source.volume = Random.Range(Volume.x, Volume.y);
			source.pitch = Random.Range(Pitch.x, Pitch.y);
			source.PlayOneShot(Clips[Random.Range(0, Clips.Length)]);
		}
	}
}
