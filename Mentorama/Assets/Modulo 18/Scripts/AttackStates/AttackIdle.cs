using UnityEngine;

namespace Modulo18
{
	public class AttackIdle : AttackMachineState
	{
		public AttackIdle(AttackAnimator attackAnimator, Transform player)
			: base(attackAnimator, player)
		{
			Name = AttackState.Idle;
		}

		public override void Enter()
		{
			Debug.Log("Enter Attack");
			base.Enter();
		}

		public override void Update()
		{
			Debug.Log("Update Attack");

			if (CanAttackPlayer())
			{
				AttackAnimator.PlayAttackAnim();
				NextState = new AttackCooldown(AttackAnimator, Player);
				Stage = Event.Exit;
			}
		}

		public override void Exit()
		{
			Debug.Log("Exit Attack");
			base.Exit();
		}
	}
}
