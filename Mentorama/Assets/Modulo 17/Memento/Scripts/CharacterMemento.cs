namespace Modulo17.Memento
{
	// Memento
	public class CharacterMemento
	{
		public CharacterData Data { get; protected set; }

		public CharacterMemento(CharacterData characterData)
		{
			Data = characterData;
		}
	}
}