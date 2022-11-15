using System.Collections.Generic;
using UnityEngine;

namespace Modulo18
{
	public class EnemyAI : MonoBehaviour
	{
		public Transform Player;
		public SpriteMask SpriteMask;
		private AICharacterMotor _characterMotor;
		private AttackAnimator _attackAnimator;
		private MoveMachineState _currentMoveState;
		private AttackMachineState _currentAttackState;

		private void Start()
		{
			_characterMotor = GetComponent<AICharacterMotor>();
			_attackAnimator = GetComponent<AttackAnimator>();
			_currentMoveState = new Idle(_characterMotor, Player, new Stack<MoveMachineState>());
			_currentAttackState = new AttackIdle(_attackAnimator, Player);

			SpriteMask.transform.localScale = new Vector3(MoveMachineState.VisibleDistance * 2, MoveMachineState.VisibleDistance * 2, 1f);
			SpriteMask.transform.localEulerAngles = new Vector3(90, -MoveMachineState.VisibleAngle, 0);
			SpriteMask.alphaCutoff = 1 - (MoveMachineState.VisibleAngle * 2 / 360f);
		}

		private void Update()
		{
			_currentMoveState = _currentMoveState.Process();
			_currentAttackState = _currentAttackState.Process();
		}
	}
}
