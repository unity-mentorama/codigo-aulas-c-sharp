using UnityEngine;

namespace Modulo18
{
	public class AttackCooldown : AttackMachineState
	{
		private float _cooldownTimer;

		public AttackCooldown(AttackAnimator attackAnimator, Transform player)
			: base(attackAnimator, player)
		{
			Name = AttackState.Cooldown;
		}

		public override void Enter()
		{
			Debug.Log("Enter AttackCooldown");
			_cooldownTimer = 1f;
			base.Enter();
		}

		public override void Update()
		{
			Debug.Log("Update AttackCooldown");

			_cooldownTimer -= Time.deltaTime;

			if (_cooldownTimer <= 0)
			{
				NextState = new AttackIdle(AttackAnimator, Player);
				Stage = Event.Exit;
			}
		}

		public override void Exit()
		{
			Debug.Log("Exit AttackCooldown");
			base.Exit();
		}
	}
}
