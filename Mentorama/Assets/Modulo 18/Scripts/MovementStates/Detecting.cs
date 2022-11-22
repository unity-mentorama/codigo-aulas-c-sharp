using System.Collections.Generic;
using UnityEngine;

namespace Modulo18
{
	public abstract class Detecting : MovementMachineState
	{
		public Detecting(AICharacterMotor aiCharacterMotor, Transform player, Stack<MovementMachineState> previousStates)
			: base(aiCharacterMotor, player, previousStates)
		{
			//
		}

		public override void Enter()
		{
			Debug.Log("Enter Detecting");
			base.Enter();
		}

		public override void Update()
		{
			Debug.Log("Update Detecting");

			if (CanSeePlayer())
			{
				NextState = new Pursue(AICharacterMotor, Player, PreviousStates);
				Stage = Event.Exit;
			}
		}

		public override void Exit()
		{
			Debug.Log("Exit Detecting");
			base.Exit();
		}
	}
}
