using System;
using UnityEngine;

[RequireComponent(typeof(Move))]
public partial class PatrolComponent : MonoBehaviour
{
	private enum PatrolState
	{
		Idle,
		PatrollingLeft,
		PatrollingRight
	}

	public Action OnStoppedMoving;
	public Action<bool> OnStartedMoving;

	private PatrolData _patrolData;

	private Move _moveComponent;

	private PatrolState _patrolState;
	private float _idleTimer;
	private float _moveTimer;
	private PatrolState _lastMoveDirection;
	private bool _patrolling;

	public void StartPatrol(PatrolData patrolData)
	{
		_patrolData = patrolData;
		_idleTimer = 0;
		_moveTimer = 0;
		_patrolState = PatrolState.Idle;
		_lastMoveDirection = PatrolState.PatrollingLeft;

		_moveComponent.Speed = _patrolData.moveSpeed;

		_patrolling = true;
	}

	public void StopPatrol()
	{
		_moveComponent.Direction = Vector3.zero;

		_patrolling = false;
	}

	private void Start()
	{
		_patrolling = false;

		_moveComponent = GetComponent<Move>();
	}

	private void Update()
	{
		if (!_patrolling) return;

		//if (_patrolState == PatrolState.Idle) return;

		//_patrolTimer += Time.deltaTime;

		//if (_patrolTimer > _patrolData.patrolDuration)
		//{
		//	_patrolState = PatrolState.Idle;
		//	OnPatrolEnded?.Invoke();
		//	return;
		//}

		switch (_patrolState)
		{
			default:
			case PatrolState.Idle:
				_idleTimer += Time.deltaTime;

				if (_idleTimer >= _patrolData.idleDuration)
				{
					if (_lastMoveDirection == PatrolState.PatrollingLeft)
					{
						StartMoving(PatrolState.PatrollingRight, Vector3.right);
					}
					else
					{
						StartMoving(PatrolState.PatrollingLeft, Vector3.left);
					}
				}

				break;

			case PatrolState.PatrollingLeft:
			case PatrolState.PatrollingRight:

				_moveTimer += Time.deltaTime;

				if (_moveTimer >= _patrolData.moveDuration)
				{
					_patrolState = PatrolState.Idle;
					_moveTimer = 0;

					_moveComponent.Direction = Vector3.zero;

					OnStoppedMoving?.Invoke();
				}

				break;
		}
	}

	private void StartMoving(PatrolState nextState, Vector3 direction)
	{
		_patrolState = nextState;
		_lastMoveDirection = nextState;
		_idleTimer = 0;

		_moveComponent.Direction = direction;

		OnStartedMoving?.Invoke(nextState == PatrolState.PatrollingRight);
	}
}
