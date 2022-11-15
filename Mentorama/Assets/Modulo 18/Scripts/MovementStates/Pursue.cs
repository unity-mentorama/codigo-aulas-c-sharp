using System.Collections.Generic;
using UnityEngine;

namespace Modulo18
{
	public class Pursue : MovementMachineState
	{
		public Pursue(AICharacterMotor aiCharacterMotor, Transform player, Stack<MovementMachineState> previousStates)
			: base(aiCharacterMotor, player, previousStates)
		{
			Name = MovementState.Pursue;
		}

		public override void Enter()
		{
			Debug.Log("Enter Pursue");
			AICharacterMotor.TargetPosition = Player.position;
			AICharacterMotor.MoveSpeed = 5f;
			base.Enter();
		}

		public override void Update()
		{
			Debug.Log("Update Pursue");

			AICharacterMotor.TargetPosition = Player.position;

			if (CanAttackPlayer())
			{
				AICharacterMotor.TargetPosition = AICharacterMotor.transform.position;
			}
			else if (!CanSeePlayer())
			{
				NextState = new MovementIdle(AICharacterMotor, Player, PreviousStates);
				Stage = Event.Exit;
			}
		}

		public override void Exit()
		{
			Debug.Log("Exit Pursue");
			base.Exit();
		}
	}
}
