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

		public static float VisibaleAngle = 30;
		public static float AttackDistance = 2f;

		public AttackState Name;

		protected Event Stage;
		protected AttackAnimator AttackAnimator;
		protected Transform Player;
		protected AttackMachineState NextState;

		public AttackMachineState(AttackAnimator attackAnimator, Transform player)
		{
			AttackAnimator = attackAnimator;
			Player = player;
		}

		public virtual void Enter() { Stage = Event.Update; }
		public virtual void Update() { Stage = Event.Update; }
		public virtual void Exit() { Stage = Event.Exit; }

		public AttackMachineState Handle()
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
			Vector3 direction = Player.position - AttackAnimator.transform.position;
			float angle = Vector3.Angle(direction, AttackAnimator.transform.forward);

			if (direction.magnitude <= AttackDistance && angle <= VisibaleAngle)
			{
				return true;
			}

			return false;
		}
	}
}
