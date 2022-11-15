using UnityEngine;

namespace Modulo18
{
	public abstract class AttackMachineState
	{
		public enum AttackState
		{
			Idle, Cooldown
		}

		protected enum Event
		{
			Enter, Update, Exit
		}

		public static float VisibleAngle = 30f;
		public static float AttackDistance = 2f;

		public AttackState Name;

		protected Event Stage;
		protected AttackAnimator AICharacterAttack;
		protected Transform Player;
		protected AttackMachineState NextState;

		public AttackMachineState(AttackAnimator aiCharacterAttack, Transform player)
		{
			AICharacterAttack = aiCharacterAttack;
			Player = player;
		}

		public virtual void Enter() { Stage = Event.Update; }
		public virtual void Update() { Stage = Event.Update; }
		public virtual void Exit() { Stage = Event.Enter; }

		public AttackMachineState Process()
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

		protected bool CanAttackPlayer()
		{
			Vector3 direction = Player.position - AICharacterAttack.transform.position;
			float angle = Vector3.Angle(direction, AICharacterAttack.transform.forward);

			if (direction.magnitude < AttackDistance && angle < VisibleAngle)
			{
				return true;
			}

			return false;
		}
	}

	public class AttackIdle : AttackMachineState
	{
		public AttackIdle(AttackAnimator aiCharacterAttack, Transform transform)
			: base(aiCharacterAttack, transform)
		{
			Name = AttackState.Idle;
		}

		public override void Enter()
		{
			Debug.Log("Enter Attack Idle");
			base.Enter();
		}

		public override void Update()
		{
			Debug.Log("Update Attack Idle");

			if (CanAttackPlayer())
			{
				AICharacterAttack.PlayAttackAnim();
				NextState = new AttackCooldown(AICharacterAttack, Player);
				Stage = Event.Exit;
			}
		}

		public override void Exit()
		{
			Debug.Log("Exit Attack Idle");
			base.Exit();
		}
	}

	public class AttackCooldown : AttackMachineState
	{
		private float _cooldownTimer;

		public AttackCooldown(AttackAnimator aiCharacterAttack, Transform transform)
			: base(aiCharacterAttack, transform)
		{
			Name = AttackState.Idle;
		}

		public override void Enter()
		{
			Debug.Log("Enter Attack Idle");
			_cooldownTimer = 1f;
			base.Enter();
		}

		public override void Update()
		{
			Debug.Log("Update Attack Idle");

			_cooldownTimer -= Time.deltaTime;

			if (_cooldownTimer <= 0)
			{
				NextState = new AttackIdle(AICharacterAttack, Player);
				Stage = Event.Exit;
			}
		}

		public override void Exit()
		{
			Debug.Log("Exit Attack Idle");
			base.Exit();
		}
	}
}