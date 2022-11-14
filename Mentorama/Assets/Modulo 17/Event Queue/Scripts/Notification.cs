namespace Modulo17.EventQueue
{
	// Event
	public struct Notification : IEvent
	{
		public string Message { get; set; }
		public float Duration { get; set; }
	}
}
