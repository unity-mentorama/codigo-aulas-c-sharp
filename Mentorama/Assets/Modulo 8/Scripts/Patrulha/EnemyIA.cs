using UnityEngine;

namespace Modulo8
{
	public class EnemyIA : MonoBehaviour
	{
		private enum EnemyState
		{
			Stopped,
			PatrollingRoute1,
			PatrollingRoute2
		}

		public PatrolComponent PatrolComponent;

		[SerializeField]
		private PatrolData _patrolData1;

		[SerializeField]
		private PatrolData _patrolData2;

		private EnemyState currentState;

		private void Start()
		{
			currentState = EnemyState.Stopped;
		}

		private void Update()
		{
			switch (currentState)
			{
				default:
				case EnemyState.Stopped:

					if (Input.GetKeyDown(KeyCode.Alpha1))
					{
						PatrolComponent.StartPatrol(_patrolData1);

						currentState = EnemyState.PatrollingRoute1;
					}
					else if (Input.GetKeyDown(KeyCode.Alpha2))
					{
						PatrolComponent.StartPatrol(_patrolData2);

						currentState = EnemyState.PatrollingRoute2;
					}

					break;

				case EnemyState.PatrollingRoute1:
				case EnemyState.PatrollingRoute2:

					if (Input.GetKeyDown(KeyCode.Space))
					{
						PatrolComponent.StopPatrol();

						currentState = EnemyState.Stopped;
					}

					break;
			}
		}
	}
}