using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modulo17.EventQueue
{
	// EventQueue
	public class EventQueue : MonoBehaviour
	{
		private readonly Queue<IEvent> _eventQueue = new Queue<IEvent>();

		private bool _playingEvent;
		private float _currentEventTimer = 0;

		public event Action<IEvent> DispatchEvent;

		public void EnqueueEvent(IEvent @event)
		{
			_eventQueue.Enqueue(@event);

			if (!_playingEvent)
			{
				DispatchNextEvent();
			}
		}

		private void DispatchNextEvent()
		{
			var @event = _eventQueue.Dequeue();
			_currentEventTimer += @event.Duration;
			DispatchEvent?.Invoke(@event);
			_playingEvent = true;
		}

		public void Update()
		{
			if (_playingEvent)
			{
				_currentEventTimer -= Time.deltaTime;

				if (_currentEventTimer <= 0)
				{
					if (_eventQueue.Count > 0)
					{
						DispatchNextEvent();
					}
					else
					{
						_playingEvent = false;
					}
				}
			}
		}
	}
}
