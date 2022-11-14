namespace Modulo17.EventQueue
{
	public interface IEvent
	{
		string Message { get; set; }
		float Duration { get; set; }
	}
}
