using UnityEngine;

namespace Modulo18
{
	public class Player : MonoBehaviour
	{
		public float WalkSpeed = 5f;
		public float RunSpeed = 10f;

		private Vector3 _moveDirection;
		private bool _isRunning;

		private void Update()
		{
			_moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
			_isRunning = Input.GetKey(KeyCode.LeftShift);
		}

		private void FixedUpdate()
		{
			var moveSpeed = _isRunning ? RunSpeed : WalkSpeed;
			transform.Translate(_moveDirection * moveSpeed * Time.fixedDeltaTime, Space.World);

			transform.LookAt(transform.position + _moveDirection);
		}
	}
}
