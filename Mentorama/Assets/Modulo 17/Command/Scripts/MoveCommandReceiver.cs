using UnityEngine;

namespace Modulo17.Command
{
	// Receiver
	public class MoveCommandReceiver
	{
		public void MoveOperation(MoveCommandState state)
		{
			switch (state.Direction)
			{
				case MoveDirection.Up:
					MoveY(state.GameObject, state.Distance);
					break;

				case MoveDirection.Down:
					MoveY(state.GameObject, -state.Distance);
					break;

				case MoveDirection.Left:
					MoveX(state.GameObject, -state.Distance);
					break;

				case MoveDirection.Right:
					MoveX(state.GameObject, state.Distance);
					break;
			}
		}

		private void MoveY(GameObject gameObjectToMove, float distance)
		{
			Vector3 newPosition = gameObjectToMove.transform.position;
			newPosition.y += distance;
			gameObjectToMove.transform.position = newPosition;
		}

		private void MoveX(GameObject gameObjectToMove, float distance)
		{
			Vector3 newPosition = gameObjectToMove.transform.position;
			newPosition.x += distance;
			gameObjectToMove.transform.position = newPosition;
		}
	}
}
