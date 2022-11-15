using System.Collections.Generic;
using UnityEngine;

namespace Modulo18
{
	public abstract class MoveMachineState
	{
		public enum MovementState
		{
			Idle, Patrol, Pursue, Attack, Sleep
		}

		protected enum Event
		{
			Enter, Update, Exit
		}

		public static float VisibleDistance = 5f;
		public static float VisibleAngle = 30f;
		public static float AttackDistance = 1.5f;

		public MovementState Name;

		protected Event Stage;
		protected AICharacterMotor AICharacterMotor;
		protected Transform Player;
		protected MoveMachineState NextState;
		protected Stack<MoveMachineState> PreviousStates;

		public MoveMachineState(AICharacterMotor aiCharacterMotor, Transform player, Stack<MoveMachineState> previousStates)
		{
			AICharacterMotor = aiCharacterMotor;
			Player = player;
			PreviousStates = previousStates;
		}

		public virtual void Enter() { Stage = Event.Update; }
		public virtual void Update() { Stage = Event.Update; }
		public virtual void Exit() { Stage = Event.Enter; }

		public MoveMachineState Process()
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

			if (direction.magnitude < VisibleDistance && angle < VisibleAngle)
			{
				return true;
			}

			return false;
		}

		protected bool CanAttackPlayer()
		{
			Vector3 direction = Player.position - AICharacterMotor.transform.position;
			if (direction.magnitude < AttackDistance)
			{
				return true;
			}

			return false;
		}
	}

	public abstract class Detecting : MoveMachineState
	{
		public Detecting(AICharacterMotor aiCharacterMotor, Transform transform, Stack<MoveMachineState> previousStates)
			: base(aiCharacterMotor, transform, previousStates)
		{

		}

		public override void Enter()
		{
			Debug.Log("Enter Move Detecting");
			base.Enter();
		}

		public override void Update()
		{
			Debug.Log("Update Move Detecting");

			if (CanSeePlayer())
			{
				NextState = new Pursue(AICharacterMotor, Player, PreviousStates);
				Stage = Event.Exit;
			}
		}

		public override void Exit()
		{
			Debug.Log("Exit Move Detecting");
			base.Exit();
		}
	}

	public class Idle : Detecting
	{
		private float _idleTimer;

		public Idle(AICharacterMotor aiCharacterMotor, Transform transform, Stack<MoveMachineState> previousStates)
			: base(aiCharacterMotor, transform, previousStates)
		{
			Name = MovementState.Idle;
		}

		public override void Enter()
		{
			Debug.Log("Enter Move Idle");
			_idleTimer = Random.Range(3f, 5f);
			base.Enter();
		}

		public override void Update()
		{
			Debug.Log("Update Move Idle");

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
			Debug.Log("Exit Move Idle");
			base.Exit();
		}
	}

	public class Patrol : Detecting
	{
		private readonly Vector3[] _patrolPositions =
			new Vector3[]
			{
				new Vector3(-4, 0, 4),
				new Vector3(4, 0, 4),
				new Vector3(4, 0, -4),
				new Vector3(-4, 0, -4),
				new Vector3(-4, 0, 4)
			};

		private int _currentIndex = 0;

		public Patrol(AICharacterMotor aiCharacterMotor, Transform player, Stack<MoveMachineState> previousStates)
			: base(aiCharacterMotor, player, previousStates)
		{
			Name = MovementState.Patrol;
			_currentIndex = 0;
		}

		public override void Enter()
		{
			Debug.Log("Enter Move Patrol");
			AICharacterMotor.MoveSpeed = 3;

			AICharacterMotor.TargetPosition = _patrolPositions[_currentIndex];
			base.Enter();
		}

		public override void Update()
		{
			Debug.Log("Update Move Patrol");

			if (Vector3.Distance(AICharacterMotor.transform.position, _patrolPositions[_currentIndex]) <= 0.1f)
			{
				_currentIndex++;

				if (_currentIndex >= _patrolPositions.Length)
				{
					NextState = new Idle(AICharacterMotor, Player, PreviousStates);
					Stage = Event.Exit;
				}
				else
				{
					AICharacterMotor.TargetPosition = _patrolPositions[_currentIndex];
				}
			}
			else
			{
				base.Update();
			}
		}

		public override void Exit()
		{
			if (CanSeePlayer())
			{
				PreviousStates.Push(this);
			}

			Debug.Log("Exit Move Patrol");
			base.Exit();
		}
	}

	public class Pursue : MoveMachineState
	{
		public Pursue(AICharacterMotor aiCharacterMotor, Transform player, Stack<MoveMachineState> previousStates)
			: base(aiCharacterMotor, player, previousStates)
		{
			Name = MovementState.Pursue;
			AICharacterMotor.MoveSpeed = 5;
		}

		public override void Enter()
		{
			Debug.Log("Enter Move Pursue");
			AICharacterMotor.TargetPosition = Player.position;
			base.Enter();
		}

		public override void Update()
		{
			Debug.Log("Update Move Pursue");

			AICharacterMotor.TargetPosition = Player.position;

			if (CanAttackPlayer())
			{
				AICharacterMotor.TargetPosition = AICharacterMotor.transform.position;
			}
			else if (!CanSeePlayer())
			{
				NextState = new Idle(AICharacterMotor, Player, PreviousStates);
				Stage = Event.Exit;
			}
		}

		public override void Exit()
		{
			Debug.Log("Exit Move Pursue");
			base.Exit();
		}
	}
}