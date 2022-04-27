using System;
using UnityEngine;

namespace Modulo6
{
	public class Patrol : MonoBehaviour
	{
		enum EnemyState
		{
			Stopped,
			PatrollingRoute1,
			PatrollingRoute2
		}

		enum PatrolState
		{
			PatrollingLeft,
			PatrollingRight
		}

		[Serializable]
		struct PatrolData
		{
			public float patrolDuration;
			public float moveSpeed;
			public float moveDuration;
		}

		[SerializeField]
		PatrolData patrolData1;

		[SerializeField]
		PatrolData patrolData2;

		[SerializeField]
		EnemyState currentState;


		float startPatrolTime;

		float patrolStateChangeTime;

		PatrolState patrolState;

		private void Start()
		{
			patrolState = PatrolState.PatrollingLeft;
			currentState = EnemyState.Stopped;
			patrolStateChangeTime = 0;
		}

		void Update()
		{
			switch (currentState)
			{
				default:
				case EnemyState.Stopped:

					if (Input.GetKeyDown(KeyCode.Alpha1))
					{
						currentState = EnemyState.PatrollingRoute1;
						startPatrolTime = Time.time;
					}

					break;

				case EnemyState.PatrollingRoute1:

					if (Time.time > startPatrolTime + patrolData1.patrolDuration)
					{
						currentState = EnemyState.PatrollingRoute2;
						startPatrolTime = Time.time;
					}

					PatrolRoutine(patrolData1);

					break;

				case EnemyState.PatrollingRoute2:

					if (Time.time > startPatrolTime + patrolData2.patrolDuration)
					{
						currentState = EnemyState.Stopped;
					}

					PatrolRoutine(patrolData2);

					break;
			}
		}

		void PatrolRoutine(PatrolData patrolData)
		{
			patrolStateChangeTime += Time.deltaTime;

			switch (patrolState)
			{
				case PatrolState.PatrollingLeft:

					Translate(new Vector3(-patrolData.moveSpeed * Time.deltaTime, 0, 0));

					ChangePatrolState(patrolData, PatrolState.PatrollingRight);

					break;

				case PatrolState.PatrollingRight:

					Translate(new Vector3(patrolData.moveSpeed * Time.deltaTime, 0, 0));

					ChangePatrolState(patrolData, PatrolState.PatrollingLeft);

					break;
			}
		}

		void ChangePatrolState(PatrolData patrolData, PatrolState patrolState)
		{
			if (patrolStateChangeTime > patrolData.moveDuration)
			{
				this.patrolState = patrolState;
				patrolStateChangeTime = 0;
			}
		}

		void Translate(Vector3 movementTranslation)
		{
			transform.position = transform.position + movementTranslation;
		}
	}
}