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

		private MovementMachineState _currentMovementMachineState;
		private AttackMachineState _currentAttackMachineState;

		private void Start()
		{
			_characterMotor = GetComponent<AICharacterMotor>();
			_attackAnimator = GetComponent<AttackAnimator>();

			// Inicializar states
			_currentMovementMachineState = new MovementIdle(_characterMotor, Player, new Stack<MovementMachineState>());
			_currentAttackMachineState = new AttackIdle(_attackAnimator, Player);
		}

		private void Update()
		{
			// Atualizar states
			_currentMovementMachineState = _currentMovementMachineState.Handle();
			_currentAttackMachineState = _currentAttackMachineState.Handle();
		}
	}
}
