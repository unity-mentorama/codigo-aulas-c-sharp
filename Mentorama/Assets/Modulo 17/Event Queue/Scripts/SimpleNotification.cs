using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modulo17.EventQueue
{
	public class SimpleNotification : MonoBehaviour
	{
		public TextMeshProUGUI NotificationText;

		public Image BackgroundImage;

		public EventQueue EventQueue;

		private Coroutine _endNotificationCoroutine;

		private void Start()
		{
			EventQueue.DispatchEvent += StartNotification;
		}

		public void StartNotification(IEvent @event)
		{
			if (@event is Notification notification)
			{
				NotificationText.text = $"{notification.Message}\nDuration: {notification.Duration:0.00}s";
				BackgroundImage.gameObject.SetActive(true);

				if (_endNotificationCoroutine != null)
				{
					StopCoroutine(_endNotificationCoroutine);
				}

				_endNotificationCoroutine = StartCoroutine(EndNotification(notification.Duration));
			}
		}

		private IEnumerator EndNotification(float duration)
		{
			// Subtraindo 0.1 do tempo da UI para dar uma piscada
			// e deixar evidente a atualização da interface
			yield return new WaitForSeconds(duration - 0.1f);
			BackgroundImage.gameObject.SetActive(false);
		}
	}
}
