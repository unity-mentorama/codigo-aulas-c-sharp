using System.Collections.Generic;
using UnityEngine;

namespace Modulo18
{
	public abstract class MovementMachineState
	{
		public enum MovementState
		{
			Idle, Patrol, Pursue, Attack
		}

		protected enum Event
		{
			Enter, Update, Exit
		}

		public static float VisibleDistance = 5f;
		public static float VisibaleAngle = 30;
		public static float AttackDistance = 1.5f;

		public MovementState Name;

		protected Event Stage;
		protected AICharacterMotor AICharacterMotor;
		protected Transform Player;
		protected MovementMachineState NextState;
		protected Stack<MovementMachineState> PreviousStates;

		public MovementMachineState(AICharacterMotor aiCharacterMotor, Transform player, Stack<MovementMachineState> previousStates)
		{
			AICharacterMotor = aiCharacterMotor;
			Player = player;
			PreviousStates = previousStates;
		}

		public virtual void Enter() { Stage = Event.Update; }
		public virtual void Update() { Stage = Event.Update; }
		public virtual void Exit() { Stage = Event.Enter; }

		public MovementMachineState Handle()
		{
			switch (Stage)
			{
				case Event.Enter:
					Enter();
					break;

				case Event.Update:
					Update();
					break;

				case Event.Exit:
					Exit();
					return NextState;
			}

			return this;
		}

		protected bool CanSeePlayer()
		{
			Vector3 direction = Player.position - AICharacterMotor.transform.position;
			float angle = Vector3.Angle(direction, AICharacterMotor.transform.forward);

			if (direction.magnitude <= VisibleDistance && angle <= VisibaleAngle)
			{
				return true;
			}

			return false;
		}

		protected bool CanAttackPlayer()
		{
			Vector3 direction = Player.position - AICharacterMotor.transform.position;
			if (direction.magnitude <= AttackDistance)
			{
				return true;
			}

			return false;
		}
	}
}
