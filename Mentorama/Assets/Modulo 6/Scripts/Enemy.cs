using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	enum EnemyState
	{
		Stopped,
		PatrollRoute1,
		PatrollRoute2
	}

	enum PatrolDirection
	{
		Left,
		Right
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

	float directionChangeTime;

	PatrolDirection patrolState;

	private void Start()
	{
		patrolState = PatrolDirection.Left;
		currentState = EnemyState.Stopped;
		directionChangeTime = 0;
	}

	void Update()
	{
		switch (currentState)
		{
			default:
			case EnemyState.Stopped:

				if (Input.GetKeyDown(KeyCode.Alpha1))
				{
					currentState = EnemyState.PatrollRoute1;
					startPatrolTime = Time.time;
				}

				break;

			case EnemyState.PatrollRoute1:

				if (Time.time > startPatrolTime + patrolData1.patrolDuration)
				{
					currentState = EnemyState.PatrollRoute2;
					startPatrolTime = Time.time;
				}

				PatrolRoutine(patrolData1);

				break;

			case EnemyState.PatrollRoute2:

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
		directionChangeTime += Time.deltaTime;

		switch (patrolState)
		{
			case PatrolDirection.Left:

				Translate(new Vector3(-patrolData.moveSpeed * Time.deltaTime, 0, 0));

				ChangePatrolDirection(patrolData, PatrolDirection.Right);

				break;

			case PatrolDirection.Right:

				Translate(new Vector3(patrolData.moveSpeed * Time.deltaTime, 0, 0));

				ChangePatrolDirection(patrolData, PatrolDirection.Left);

				break;
		}
	}

	void ChangePatrolDirection(PatrolData patrolData, PatrolDirection direction)
	{
		if (directionChangeTime > patrolData.moveDuration)
		{
			patrolState = direction;
			directionChangeTime = 0;
		}
	}

	void Translate(Vector3 movementTranslation)
	{
		transform.position = transform.position + movementTranslation;
	}
}
