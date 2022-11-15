using System.Collections.Generic;
using UnityEngine;

namespace Modulo18
{
	public class MovementIdle : Detecting
	{
		private float _idleTimer;

		public MovementIdle(AICharacterMotor aiCharacterMotor, Transform player, Stack<MovementMachineState> previousStates)
			: base(aiCharacterMotor, player, previousStates)
		{
			Name = MovementState.Idle;
		}

		public override void Enter()
		{
			Debug.Log("Enter Idle");
			_idleTimer = Random.Range(3f, 5f);
			base.Enter();
		}

		public override void Update()
		{
			Debug.Log("Update Idle");

			_idleTimer -= Time.deltaTime;

			if (_idleTimer <= 0)
			{
				if (PreviousStates.Count > 0)
				{
					NextState = PreviousStates.Pop();
				}
				else
				{
					NextState = new Patrol(AICharacterMotor, Player, PreviousStates);
				}

				Stage = Event.Exit;
			}
			else
			{
				base.Update();
			}
		}

		public override void Exit()
		{
			Debug.Log("Exit Idle");
			base.Exit();
		}
	}
}
