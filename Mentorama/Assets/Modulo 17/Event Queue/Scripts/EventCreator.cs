using UnityEngine;

namespace Modulo17.EventQueue
{
	public class EventCreator : MonoBehaviour
	{
		public EventQueue NotificationManager;

		private int _count;

		private void Start()
		{
			NotificationManager.DispatchEvent += NotificationManager_DispatchEvent;
		}

		private void NotificationManager_DispatchEvent(IEvent obj)
		{
			Debug.Log($"Event: {obj.Message}");
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				NotificationManager.EnqueueEvent(new Notification
				{
					Message = $"Message {++_count}",
					Duration = Random.Range(0f, 5f)
				});
			}
		}
	}
}
