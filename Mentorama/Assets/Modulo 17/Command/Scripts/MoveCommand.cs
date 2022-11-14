using UnityEngine;

namespace Modulo17.Command
{
	public enum MoveDirection
	{
		Up,
		Down,
		Left,
		Right
	};

	// State
	public struct MoveCommandState
	{
		public GameObject GameObject;
		public MoveDirection Direction;
		public float Distance;
	}

	// ConcreteCommand
	public class MoveCommand : ICommand
	{
		private readonly MoveCommandReceiver _receiver;
		private readonly MoveCommandState _state;

		public MoveCommand(MoveCommandReceiver reciever, MoveCommandState state)
		{
			_receiver = reciever;
			_state = state;
		}

		public void Execute()
		{
			_receiver.MoveOperation(_state);
		}

		public void UnExecute()
		{
			var inverseState = _state;
			inverseState.Direction = InverseDirection(_state.Direction);

			_receiver.MoveOperation(inverseState);
		}

		private MoveDirection InverseDirection(MoveDirection direction)
		{
			switch (direction)
			{
				case MoveDirection.Up:
					return MoveDirection.Down;

				case MoveDirection.Down:
					return MoveDirection.Up;

				case MoveDirection.Left:
					return MoveDirection.Right;

				case MoveDirection.Right:
					return MoveDirection.Left;

				default:
					Debug.LogError("Direção desconhecida.");
					return MoveDirection.Up;
			}
		}

		public override string ToString()
		{
			return $"{_state.Direction} : {_state.Distance}";
		}
	}
}
